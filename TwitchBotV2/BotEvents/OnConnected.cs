using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TwitchBotV2.BotEvents
{
    internal class OnConnected
    {
        public static void RegisterEvents()
        {
            TwitchClientConnectedMessage();
        }

        public static void TwitchClientConnectedMessage()
        {
            Globals.TwitchClient.OnConnected += async (s, e) =>
            {
                Globals.TwitchClient.SendMessage(Globals.Channel, "Bot connected to chat successfully!");
            };

            Globals.TwitchClient.OnConnectionError += async (s, e) =>
            {
                MessageBox.Show(e.Error.Message, "Error while connecting");
            };
        }
    }
}
