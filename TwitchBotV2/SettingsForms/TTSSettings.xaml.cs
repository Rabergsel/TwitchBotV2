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

namespace TwitchBotV2.SettingsForms
{
    /// <summary>
    /// Interaktionslogik für TTSSettings.xaml
    /// </summary>
    public partial class TTSSettings : Window
    {
        public TTSSettings()
        {
            InitializeComponent();
            MinCutoff.Value = Globals.Settings.TTSMinCutoff;
            MaxCutoff.Value = Globals.Settings.TTSMaxCutoff;

            MinLabel.Content = Globals.Settings.TTSMaxCutoff + " characters";

            TTSall.IsChecked = Globals.Settings.TTSEveryone;
            TTSmod.IsChecked = Globals.Settings.TTSMod;
            TTSvip.IsChecked = Globals.Settings.TTSVIP;
        }

        private void MinCutoff_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.Settings.TTSMinCutoff = (int)MinCutoff.Value;
            Globals.SaveSettings();
            MinLabel.Content = Globals.Settings.TTSMinCutoff + " characters";
        }

        private void MaxCutoff_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.Settings.TTSMaxCutoff = (int)MaxCutoff.Value;
            Globals.SaveSettings();


        }

        private void TTSall_Checked(object sender, RoutedEventArgs e)
        {
            if (TTSall.IsChecked == true) Globals.Settings.TTSEveryone = true;
            else Globals.Settings.TTSEveryone = false;

            Globals.SaveSettings();

        }

        private void TTSmod_Checked(object sender, RoutedEventArgs e)
        {
            if (TTSmod.IsChecked == true) Globals.Settings.TTSMod = true;
            else Globals.Settings.TTSMod = false;
            Globals.SaveSettings();
        }

        private void TTSvip_Checked(object sender, RoutedEventArgs e)
        {
            if (TTSvip.IsChecked == true) Globals.Settings.TTSVIP = true;
            else Globals.Settings.TTSVIP = false;
            Globals.SaveSettings();
        }
    }
}
