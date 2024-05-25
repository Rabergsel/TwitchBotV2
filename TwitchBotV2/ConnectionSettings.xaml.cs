using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TwitchBotV2
{
    /// <summary>
    /// Interaktionslogik für ConnectionSettings.xaml
    /// </summary>
    public partial class ConnectionSettings : Window
    {
        public ConnectionSettings()
        {
            InitializeComponent();
            TwitchClientID.Password = Globals.Settings.ClientID;
            TwitchAPIKey.Password = Globals.Settings.APIKey;
            OAuthToken.Password = Globals.Settings.OAuthToken;
            Username.Text = Globals.Settings.UserName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitchtokengenerator.com");
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Globals.Settings.ClientID = TwitchClientID.Password;
            Globals.SaveSettings();
            Globals.ReinitializeAPI();
        }

        private void TwitchAPIKey_LostFocus(object sender, RoutedEventArgs e)
        {
            Globals.Settings.APIKey = TwitchAPIKey.Password;
            Globals.SaveSettings();
            Globals.ReinitializeAPI();
        }

        private void OAuthToken_LostFocus(object sender, RoutedEventArgs e)
        {
            Globals.Settings.OAuthToken = OAuthToken.Password;
            Globals.SaveSettings();
            Globals.ReinitializeAPI();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitchapps.com/tmi/");
        }

        private void Username_LostFocus(object sender, RoutedEventArgs e)
        {
            Globals.Settings.UserName = Username.Text;
            Globals.SaveSettings();
        }
    }
}
