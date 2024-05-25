using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotV2.BotEvents
{
    internal class RegisterEvents
    {
        public static void Register()
        {
            OnMessage.RegisterEvents();
            OnConnected.RegisterEvents();
            
        }
    }
}
