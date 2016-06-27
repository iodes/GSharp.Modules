using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SoundLIB;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Media.Sound
{
    public class GSound : GModule
    {
        static GSound()
        {
            EngineBASS.Registration();
            EngineBASS.Initialize(IntPtr.Zero);
        }

        [GCommand("앨범 이미지")]
        public static ImageSource AlbumCover
        {
            get
            {
                if (File.Exists(EngineBASS.Path))
                {
                    TagLib.File file = TagLib.File.Create(EngineBASS.Path);
                    if (file.Tag.Pictures.Length >= 1)
                    {
                        MemoryStream stream = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                        return BitmapFrame.Create(stream);
                    }
                }

                return null;
            }
        }

        [GCommand("재생 위치")]
        public static double Position
        {
            get
            {
                return EngineBASS.Position;
            }
        }

        [GCommand("문자식 재생 위치")]
        public static string FormattedPosition
        {
            get
            {
                return EngineBASS.FormattedPosition;
            }
        }

        [GCommand("재생 길이")]
        public static double Length
        {
            get {
                return EngineBASS.Length;
            }
        }

        [GCommand("문자식 재생 길이")]
        public static string FormattedLength
        {
            get
            {
                return EngineBASS.FormattedLength;
            }
        }

        [GCommand("{0}파일 재생")]
        public static void Play(string path)
        {
            EngineBASS.Path = path;
            EngineBASS.Play();
        }

        [GCommand("재생 정지")]
        public static void Stop()
        {
            EngineBASS.Stop();
        }

        [GCommand("템포를 {0}% 증가")]
        public static void SetTempoPositive(int value)
        {
            EngineBASS.Tempo += value;
        }

        [GCommand("템포를 {0}% 감소")]
        public static void SetTempoNegative(int value)
        {
            EngineBASS.Tempo -= value;
        }

        [GCommand("음정을 {0}♯ 올림")]
        public static void SetPitchPositive(int value)
        {
            EngineBASS.Pitch += value;
        }

        [GCommand("음정을 {0}♭ 내림")]
        public static void SetPitchNegative(int value)
        {
            EngineBASS.Pitch -= value;
        }

        [GCommand("음량을 {0}%로 설정")]
        public static void SetVolume(int value)
        {
            EngineBASS.Volume = value;
        }

        [GCommand("{0} VST 적용")]
        public static void SetVST(string path)
        {
            EngineBASS.VST_SetPlugin = path;
            EngineBASS.VST_OpenEditor();
        }

        [GCommand("{0} WADSP 적용")]
        public static void SetWADSP(string path)
        {
            EngineBASS.WADSP_LoadPlugin(path, 0, 0, 0);
        }
    }
}
