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
using TwitchBotV2.Models;

namespace TwitchBotV2.SettingsForms
{
    /// <summary>
    /// Interaktionslogik für ChatCommands.xaml
    /// </summary>
    public partial class ChatCommands : Window
    {
        int index = 0;
        public ChatCommands()
        {
            InitializeComponent();
            LoadFromIndex();
        }

        public void LoadFromIndex()
        {
            ChatCommand cmd = new ChatCommand();
            
            if(index < Globals.Settings.Commands.Count)
            {
                cmd = Globals.Settings.Commands[index];
            }
            else
            {
                Globals.Settings.Commands.Add(cmd);
                cmd.CommandNames.Add("newcmd" + index);
                Globals.SaveSettings();
            }
            aliases.Text = "";
            foreach(var n in cmd.CommandNames)
            {
                aliases.Text += n + " ";
            }

            if (cmd.ActionName == "SENDMSG") sendmsg.IsSelected = true;

            data.Text = cmd.Data;
            try
            {
                CmdHeader.Content = prefix.Text + cmd.CommandNames[0];
            }
            catch
            {
                CmdHeader.Content = prefix.Text + "unknown";
            }
        }

        public void SaveToIndex()
        {
            Globals.Settings.Commands[index].CommandNames = aliases.Text.Split(' ').ToList();
            if (sendmsg.IsSelected) Globals.Settings.Commands[index].ActionName = "SENDMSG";
            Globals.Settings.Commands[index].Data = data.Text;
            Globals.SaveSettings();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveToIndex();
            index = Math.Min(Globals.Settings.Commands.Count, index + 1);
            LoadFromIndex();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveToIndex();
            index = Math.Max(0, index - 1);
            LoadFromIndex();
        }

        private void prefix_TextChanged(object sender, TextChangedEventArgs e)
        {
            Globals.Settings.Prefix = prefix.Text;
            Globals.SaveSettings();
        }
    }
}
