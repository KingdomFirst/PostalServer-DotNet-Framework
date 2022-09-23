using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;

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
            var response = _client.Execute<T>( request );

            if ( response.ErrorException != null )
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException( message, response.ErrorException );
                throw exception;
            }
            return response.Data;
        }

        public RestRequest AddRequestJsonBody( RestRequest request, object bodyObject )
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            var jsonBody = JsonConvert.SerializeObject( bodyObject, Formatting.Indented, settings );
            request.AddParameter( "application/json", jsonBody, ParameterType.RequestBody );
            return request;
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName( string propertyName )
            {
                return propertyName.ToLower();
            }
        }

        #endregion
    }
}
