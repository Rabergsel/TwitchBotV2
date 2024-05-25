using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       


    }
}
