using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PostalServerDotNet.v1.Model.Response;
using RestSharp;
using System;
using System.Net;

namespace PostalServerDotNet.v1
{
    public partial class Client
    {
        #region Properties

        /// <summary>
        /// The client
        /// </summary>
        private readonly IRestClient _client;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="baseUrl">The baseUrl for the API service.</param>
        /// <param name="apiKey">The API key.</param>
        public Client( string baseUrl, string apiKey )
        {
            _client = new RestClient( baseUrl );
            _client.AddDefaultHeader( "X-Server-API-Key", apiKey );
        }

        #endregion

        #region Method

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public T Execute<T>( RestRequest request ) where T : new()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = _client.Execute<T>( request );

            if ( response.Content.Contains( "error" ) )
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>( response.Content );
                var message = string.Format( "Error Code \"{0}\". {1}", errorResponse.Data.Code, errorResponse.Data.Message );
                var exception = new ApplicationException( message, response.ErrorException );
                throw exception;
            }
            return response.Data;
        }

        public RestRequest AddRequestJsonBody( RestRequest request, object bodyObject )
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomContractResolver();
            var jsonBody = JsonConvert.SerializeObject( bodyObject, Formatting.Indented, settings );
            request.AddParameter( "application/json", jsonBody, ParameterType.RequestBody );
            return request;
        }

        public class CustomContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName( string propertyName )
            {
                propertyName = propertyName.ToLower();
                switch ( propertyName )
                {
                    case "expansions":
                        propertyName = "_" + propertyName;
                        break;
                    case "plainbody":
                        propertyName = "plain_body";
                        break;
                    case "htmlbody":
                        propertyName = "html_body";
                        break;
                    case "contenttype":
                        propertyName = "content_type";
                        break;
                    case "mailfrom":
                        propertyName = "mail_from";
                        break;
                    case "rcptto":
                        propertyName = "rcpt_to";
                        break;
                    default:
                        break;
                }
                return propertyName;
            }
        }

        public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );
            dateTime = dateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            return dateTime;
        }

        #endregion
    }
}
