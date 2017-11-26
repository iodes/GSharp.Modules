using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Speech.Synthesis;

namespace GSharp.Modules.Speech
{
    public class TTS : GModule
    {
        [GCommand("{0}를 목소리로 출력")]
        public static void SpeechMsg(string text)
        {
            SpeechSynthesizer ts = new SpeechSynthesizer();
            ts.Speak(text);
        }
    }
}
