using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwitchLib;
using TwitchLib.Api;
using TwitchLib.Api.Core.HttpCallHandlers;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Interfaces;
using TwitchLib.Communication.Models;

namespace TwitchBotV2
{
    public class Globals
    {
        public static Settings Settings { get; set; } = new Settings();
        public static TwitchAPI TwitchAPI = new TwitchAPI();
        public static TwitchClient TwitchClient = new TwitchClient();

        [JsonIgnore]
        public static JoinedChannel Channel
        {
            get
            {
                return TwitchClient.JoinedChannels[0];
            }
            set
            {

            }
        }

        public static bool ConnectedToHelix = false;
        public static bool ConnectedToIRC = false;

        public static void ReinitializeAPI()
        {
            try
            {
                TwitchAPI = new TwitchAPI();
                TwitchAPI.Settings.ClientId = Settings.ClientID;
                TwitchAPI.Settings.AccessToken = Settings.APIKey;
                ConnectedToHelix = true;
            }
            catch
            {
                ConnectedToHelix = false;
            }

            try
            {
                TwitchClient = new TwitchClient();
                ConnectionCredentials credentials = new ConnectionCredentials(Settings.UserName, Settings.OAuthToken);
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                WebSocketClient customClient = new WebSocketClient(clientOptions);
                TwitchClient = new TwitchClient(customClient);
                TwitchClient.Initialize(credentials, Settings.UserName);
                TwitchClient.Connect();
                ConnectedToIRC = true;
            }
            catch
            {
                ConnectedToIRC = false;
            }

            BotEvents.RegisterEvents.Register();

        }

        public static void SaveSettings()
        {
            File.WriteAllText("settings.json", System.Text.Json.JsonSerializer.Serialize(Settings));
        }

        public static void LoadSettings()
        {
            Settings = System.Text.Json.JsonSerializer.Deserialize<Settings>(File.ReadAllText("settings.json"));
        }

    }
}
