﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwitchBotV2.Models;

namespace TwitchBotV2
{
    public class Settings
    {

        public string ClientID { get; set; } = "";
        public string APIKey { get; set; } = "";
        public string OAuthToken { get; set; } = "";
        public string UserName { get; set; } = "";

        public bool DarkMode { get; set; } = true;


        public bool TTS { get; set; } = true;


        public int TTSMinCutoff { get; set; } = 2;
        public int TTSMaxCutoff { get; set; } = 100;
        public bool TTSEveryone { get; set; } = true;
        public bool TTSMod {  get; set; } = true;
        public bool TTSVIP { get; set; } = true;


        public bool ChatFilter { get; set; } = true;
        public List<string> FilteredWords { get; set; } = new List<string>();


        public bool Log { get;set; } = true;
        public string LoggingDirectory { get; set; } = "";

        
        public bool ChatCommands { get; set; } = true;
        public List<ChatCommand> Commands { get; set; } = new List<ChatCommand>();
        public string Prefix { get; set; } = "";

    }
}
