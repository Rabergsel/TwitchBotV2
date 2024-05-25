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

            if(Globals.Settings.TTS)
            {
                TTS.Background = Brushes.Green;
            }
            else
            {
                TTS.Background= Brushes.Red;
            }
        }
    }
}
