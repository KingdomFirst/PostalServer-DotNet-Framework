using Newtonsoft.Json;
using PostalServerDotNet.v1;
using PostalServerDotNet.v1.Model.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// Handles the Click event of the Get Message Details button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetMessageDetails_Click( object sender, RoutedEventArgs e )
        {
            Client api = GetApiClient();
            try
            {
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
                var message = api.GetMessageDetails( MessageId, Expansions: expansionList );
                DisplayMessageInfo( message: message );
            }
            catch ( Exception ex )
            {
                tbResponse.Text = ex.InnerException.Message;
                tbResponse.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// Handles the Click event of the Get Deliveries button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetDeliveries_Click( object sender, RoutedEventArgs e )
        {
            Client api = GetApiClient();
            try
            {
                var MessageId = 0;
                int.TryParse( tbMessageId.Text.Trim(), out MessageId );
                var messageDeliveries = api.GetMessageDeliveries( MessageId );
                DisplayMessageInfo( messageDeliveries: messageDeliveries );
            }
            catch ( Exception ex )
            {
                tbResponse.Text = ex.InnerException.Message;
                tbResponse.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// Handles the Click event of the UpdateAccountInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UpdateAccountInfo_Click( object sender, RoutedEventArgs e )
        {
            //var ApiKey = txtApiKey.Text.Trim();
            //var response = new Client( ApiKey );
            //var account = UpdateAccountInfo( response );
            //DisplayMessageInfo( account );
        }

        private Client GetApiClient()
        {
            var baseUrl = tbBaseUrl.Text.Trim();
            var ApiKey = tbApiKey.Text.Trim();
            var api = new Client( baseUrl, ApiKey );
            return api;
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayMessageInfo( MessageResponse message = null, MessageDeliveriesResponse messageDeliveries = null )
        {
            if ( message == null && messageDeliveries == null )
            {
                tbResponse.Text = "No response was received. Please check your API Key";
                tbResponse.Foreground = Brushes.Red;
                return;
            }
            if ( message?.Data != null )
            {
                tbResponse.Text = JsonConvert.SerializeObject( message, Formatting.Indented );
                tbResponse.Foreground = Brushes.Green;
            }
            else if ( messageDeliveries?.Data != null )
            {
                tbResponse.Text = JsonConvert.SerializeObject( messageDeliveries, Formatting.Indented );
                tbResponse.Foreground = Brushes.Green;
            }    
            else
            {
                tbResponse.Text = "Please check your API Key";
                tbResponse.Foreground = Brushes.Red;
                return;
            }

        }

        /// <summary>
        /// Updates the account information.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        //private AccountResponse UpdateAccountInfo( Client response )
        //{
        //    string newName = null;
        //    string newPhone = null;
        //    bool? allowEmail = null;

        //    if ( !string.IsNullOrWhiteSpace( txtNewName.Text ) )
        //    {
        //        newName = txtNewName.Text;
        //    }

        //    if ( !string.IsNullOrWhiteSpace( txtNewPhone.Text ) )
        //    {
        //        newPhone = txtNewPhone.Text;
        //    }

        //    if ( rbAllowEmailFalse.IsChecked == true )
        //    {
        //        allowEmail = false;
        //    }

        //    if ( rbAllowEmailTrue.IsChecked == true )
        //    {
        //        allowEmail = true;
        //    }

        //    return response.UpdateAccount( newName, newPhone, allowEmail );
        //}
        private void NumericText_PreviewTextInput( object sender, TextCompositionEventArgs e )
        {
            var val = 0;
            e.Handled = !int.TryParse( e.Text, out val );
        }
    }
}
