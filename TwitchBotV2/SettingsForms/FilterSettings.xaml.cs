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
    /// Interaktionslogik für FilterSettings.xaml
    /// </summary>
    public partial class FilterSettings : Window
    {
        public FilterSettings()
        {
            InitializeComponent();
            string Text = "";
            foreach(var w in Globals.Settings.FilteredWords)
            {
                if (w.Trim().Length < 2)
                {
                    continue;
                }
                Text += w + "\n";
            }
            FilteredWords.Document.Blocks.Add(new Paragraph(new Run(Text)));
        }

        private void FilteredWords_LostFocus(object sender, RoutedEventArgs e)
        {
            var words = new TextRange(FilteredWords.Document.ContentStart, FilteredWords.Document.ContentEnd).Text.ToLower().Split('\n').ToList();
            Globals.Settings.FilteredWords = words;
            Globals.SaveSettings();
        }

        private void FilteredWords_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.SaveSettings();
            Close();
        }
    }
}
