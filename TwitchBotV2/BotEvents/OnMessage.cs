using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.Windows;

namespace TwitchBotV2.BotEvents
{
    public class OnMessage
    {

        internal static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public static void RegisterEvents()
        {
            TTSOutput();
        }


        public static void TTSOutput()
        {
            synthesizer.SetOutputToDefaultAudioDevice();
            
            Globals.TwitchClient.OnMessageReceived += async (s, e) =>
            {
                if(Globals.Settings.TTS)
                {
                    string textToSay = "New Message";
                    if (e.ChatMessage.Message.Length<2)
                    {
                        
                    }
                    else if(e.ChatMessage.Message.Length>90)
                    {
                        textToSay = e.ChatMessage.Username + ": " + e.ChatMessage.Message.Substring(0, 90) + "... and so on";
                    }
                    else
                    {
                        textToSay = e.ChatMessage.Username + ": " + e.ChatMessage.Message;
                    }
                    
                    synthesizer.SpeakAsync(textToSay);
                }
               
            };
        }

    }
}
