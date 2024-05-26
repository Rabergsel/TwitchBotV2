using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotV2.Models
{
    public class ChatCommand
    {
        public List<string> CommandNames { get; set; } = new List<string>();

        /*
         * SENDMSG = Send Message from Data
         */
         
        public string ActionName { get; set; } = "SENDMSG";
        public string Data { get; set; } = "";


        public void ExecuteCommand()
        {
            if(ActionName == "SENDMSG")
            {
                Globals.TwitchClient.SendMessage(Globals.Channel, Data);
            }
        }
    }
}
