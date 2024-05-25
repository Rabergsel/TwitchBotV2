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
                    if(!((e.ChatMessage.IsModerator & Globals.Settings.TTSMod)||(e.ChatMessage.IsVip & Globals.Settings.TTSVIP)))
                    {
                        return;
                    }

                    string textToSay = "New Message";
                    if (e.ChatMessage.Message.Length<Globals.Settings.TTSMinCutoff)
                    {
                        
                    }
                    else if(e.ChatMessage.Message.Length>Globals.Settings.TTSMaxCutoff)
                    {
                        textToSay = e.ChatMessage.Username + ": " + e.ChatMessage.Message.Substring(0, Globals.Settings.TTSMaxCutoff) + "... and so on";
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
