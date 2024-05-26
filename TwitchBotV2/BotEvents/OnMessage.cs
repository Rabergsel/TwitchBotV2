using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.Windows;
using TwitchLib.Client.Extensions;

namespace TwitchBotV2.BotEvents
{
    public class OnMessage
    {

        internal static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public static void RegisterEvents()
        {
            TTSOutput();
            Filter();
            Log();
        }

        public static void Filter()
        {
            
            Globals.TwitchClient.OnMessageReceived += async (s, e) =>
            {
                foreach(var w in Globals.Settings.FilteredWords)
                {
                    if(w.Trim().Length<2)
                    {
                        continue;
                    }
                    if(e.ChatMessage.Message.ToLower().Contains(w))
                    {
                        Globals.TwitchClient.DeleteMessage(Globals.Channel, e.ChatMessage.Id);
                        return;
                    }
                }
            };
        }

        public static void Log()
        {
            Globals.TwitchClient.OnMessageReceived += async (s, e) =>
            {
                if(Globals.Settings.Log)
                {
                    Functions.Logger.Log("MSG", e.ChatMessage.Username + ": " + e.ChatMessage.Message);
                }
            };
        }

        public static void TTSOutput()
        {
            synthesizer.SetOutputToDefaultAudioDevice();
            
            Globals.TwitchClient.OnMessageReceived += async (s, e) =>
            {
                if(Globals.Settings.TTS)
                {
                    if (!Globals.Settings.TTSEveryone)
                    {
                        if (!((e.ChatMessage.IsModerator & Globals.Settings.TTSMod) || (e.ChatMessage.IsVip & Globals.Settings.TTSVIP)))
                        {
                            return;
                        }
                    }

                    string textToSay = "";
                    if (e.ChatMessage.Message.Length<Globals.Settings.TTSMinCutoff)
                    {
                        
                    }
                    else if(e.ChatMessage.Message.Length>Globals.Settings.TTSMaxCutoff)
                    {
                        textToSay = "New long message";
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
