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

        public bool TTS { get; set; } = true;

    }
}
