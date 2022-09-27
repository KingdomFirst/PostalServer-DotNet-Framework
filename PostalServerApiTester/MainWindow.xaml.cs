using Newtonsoft.Json;
using PostalServerDotNet.v1;
using PostalServerDotNet.v1.Model.Object;
using PostalServerDotNet.v1.Model.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static PostalServerDotNet.Enum;

namespace PostalServerApiTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var expansions = new List<string>();
            foreach ( var expansion in Enum.GetNames( typeof( MessageExpansion ) ) )
            {
                expansions.Add( expansion );
            }
            lbExpansions.ItemsSource = expansions;
        }

        /// <summary>
        /// Get an instance of api client.
        /// </summary>
        /// <returns></returns>
        private Client GetApiClient()
        {
            var baseUrl = tbBaseUrl.Text.Trim();
            var ApiKey = tbApiKey.Text.Trim();
            var api = new Client( baseUrl, ApiKey );
            return api;
        }

        /// <summary>
        /// Handles the Click event of the Get Message Details button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetMessageDetails_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var MessageId = 0;
                int.TryParse( tbMessageId.Text.Trim(), out MessageId );
                var expansionList = new List<MessageExpansion>();
                foreach ( var item in lbExpansions.SelectedItems )
                {
                    MessageExpansion expansionEnum;
                    if ( Enum.TryParse( item.ToString(), out expansionEnum ) )
                    {
                        expansionList.Add( expansionEnum );
                    }
                }
                if ( expansionList.Count == 0 )
                {
                    expansionList = null;
                }
                var response = api.GetMessageDetails( MessageId, Expansions: expansionList );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Get Deliveries button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetDeliveries_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var MessageId = 0;
                int.TryParse( tbMessageId.Text.Trim(), out MessageId );
                var response = api.GetMessageDeliveries( MessageId );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Send Message button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SendMessage_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var toList = tbTo.Text.Trim().Split( ',' ).ToList();
                var ccList = tbCc.Text.Trim().Split( ',' ).ToList();
                var bccList = tbBcc.Text.Trim().Split( ',' ).ToList();
                List<MessageAttachment> attachments = null;
                if ( !string.IsNullOrWhiteSpace( tbAttName.Text.Trim() ) && !string.IsNullOrWhiteSpace( tbAttContentType.Text.Trim() ) && !string.IsNullOrWhiteSpace( tbAttData.Text.Trim() ) )
                {
                    attachments = new List<MessageAttachment>();
                    attachments.Add( new MessageAttachment
                    {
                        Name = tbAttName.Text.Trim(),
                        Content_Type = tbAttContentType.Text.Trim(),
                        Data = tbAttData.Text
                    } );
                }
                var response = api.SendMessage(
                    tbFrom.Text.Trim(),
                    toList,
                    ccList,
                    bccList,
                    tbSender.Text.Trim(),
                    tbSubject.Text.Trim(),
                    tbTag.Text.Trim(),
                    tbReplyTo.Text.Trim(),
                    tbPlainBody.Text.Trim(),
                    tbHtmlBody.Text.Trim(),
                    attachments );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Send Raw Message button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SendRawMessage_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var toList = tbRawRcptTo.Text.Trim().Split( ',' ).ToList();
                var response = api.SendRawMessage(
                    tbRawFrom.Text.Trim(),
                    toList,
                    tbRawData.Text );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayMessageInfo( Object response )
        {
            var responseType = response.GetType();
            var hasData = false;
            if ( responseType == typeof( MessageResponse ) )
            {
                var messageResponse = ( MessageResponse ) response;
                if ( messageResponse.Data != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( messageResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( MessageDeliveriesResponse ) )
            {
                var messageDeliveriesResponse = ( MessageDeliveriesResponse ) response;
                if ( messageDeliveriesResponse.Data != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( messageDeliveriesResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( SendResponse ) )
            {
                var sendResponse = ( SendResponse ) response;
                if ( sendResponse.Data != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( sendResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            if ( !hasData )
            {
                tbResponse.Text = "Please check your API Key";
                tbResponse.Foreground = Brushes.Red;
                return;
            }
            tbResponse.Focus();
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayException( Exception exception )
        {
            var sb = new StringBuilder();
            sb.AppendLine( exception.Message );
            if ( exception.InnerException != null )
            {
                sb.AppendLine( exception.InnerException.Message );
            }
            tbResponse.Text = sb.ToString();
            tbResponse.Foreground = Brushes.Red;
            tbResponse.Focus();
        }


        private void NumericText_PreviewTextInput( object sender, TextCompositionEventArgs e )
        {
            var val = 0;
            e.Handled = !int.TryParse( e.Text, out val );
        }
    }
}
