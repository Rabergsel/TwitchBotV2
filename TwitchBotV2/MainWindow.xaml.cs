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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwitchBotV2.SettingsForms;

namespace TwitchBotV2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Globals.LoadSettings();
            Globals.ReinitializeAPI();
            UpdateConnectionMessages();
            UpdateFunctionalityTable();
            if(Globals.Settings.DarkMode)
            {
                Background = Brushes.DarkGray;
                DarkModeToggle.Header = "Light Mode";
            }

        }

        private void UpdateConnectionMessages()
        {

            ConnectedHelix.Foreground = GetColorFromBool(Globals.ConnectedToHelix);
            ConnectedIRC.Foreground = GetColorFromBool(Globals.ConnectedToIRC);
            ConnectedUser.Foreground = GetColorFromBool(Globals.ConnectedToIRC);

            if (Globals.ConnectedToHelix) ConnectedHelix.Content = "Connected to Helix";
            else ConnectedHelix.Content = "Not connected to Helix";

            if (Globals.ConnectedToIRC) ConnectedIRC.Content = "Connected to Chat";
            else ConnectedHelix.Content = "Not connected to Helix";

            if(Globals.ConnectedToIRC)
            {
                if(Globals.Settings.UserName != "") ConnectedUser.Content = "Connected to: " + Globals.Settings.UserName;
                else
                {
                    ConnectedUser.Content = "No user specified";
                    ConnectedUser.Foreground = Brushes.DarkGray;
                }
            }
            else
            {
                ConnectedUser.Content = "Not connected to a user";
            }


        }

        private Brush GetColorFromBool(bool value)
        {
            if (Globals.Settings.DarkMode)
            {
                if (value) return Brushes.DarkGreen;
                else return Brushes.DarkRed;
            }
            else
            {
                if (value) return Brushes.Green;
                else return Brushes.Red;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var connection = new ConnectionSettings();
            connection.ShowDialog();
        }

        private void TTS_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Globals.Settings.TTS = !Globals.Settings.TTS;
            Globals.SaveSettings();
            UpdateFunctionalityTable();
        }

        private void UpdateFunctionalityTable()
        {
            TTS.Background = GetColorFromBool(Globals.Settings.TTS);
            TTSSettingsButton.Background = GetColorFromBool(Globals.Settings.TTS);

            Filter.Background = GetColorFromBool(Globals.Settings.ChatFilter);
            FilterSettingsButton.Background = GetColorFromBool((bool)Globals.Settings.ChatFilter);
        }

        private void DarkModeToggle_Click(object sender, RoutedEventArgs e)
        {
            Globals.Settings.DarkMode = !Globals.Settings.DarkMode;
            Globals.SaveSettings();

            if(Globals.Settings.DarkMode)
            {
                this.Background = Brushes.DarkGray;
                DarkModeToggle.Header = "Light Mode";
            }
            else
            {
                this.Background = Brushes.WhiteSmoke;
                DarkModeToggle.Header = "Dark Mode";
            }

            UpdateConnectionMessages();
            UpdateFunctionalityTable();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateConnectionMessages();
        }

        private void TTSSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var tts = new TTSSettings();
            tts.ShowDialog();
        }

        private void FilterSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var filtersettings = new FilterSettings();
            filtersettings.ShowDialog();
        }

        private void Filter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Globals.Settings.ChatFilter = !Globals.Settings.ChatFilter;
            UpdateFunctionalityTable();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Twitch Bot by Raphael Raberger\nPlease report bugs immediatly\n\nDo you want to help me? Go and buy me a cofee:\n https://buymeacoffee.com/raphaelraberger \n\nGithub: https://github.com/Rabergsel \nTwitter/X: https://x.com/RabergerRaphael\n\n©2024, yet open source: Change it as you want, but please cite me",
                "Info");
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twitch Bot by Raphael Raberger\nPlease report bugs immediatly\n\nDo you want to help me? Go and buy me a cofee:\n https://buymeacoffee.com/raphaelraberger \n\nGithub: https://github.com/Rabergsel \nTwitter/X: https://x.com/RabergerRaphael\n\n©2024, yet open source: Change it as you want, but please cite me",
                "Info");
        }
    }
}
