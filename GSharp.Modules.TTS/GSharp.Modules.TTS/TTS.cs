using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace GSharp.Modules.TTS
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
