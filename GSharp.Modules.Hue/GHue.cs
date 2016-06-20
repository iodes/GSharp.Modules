using System;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Collections.Generic;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Hue
{
    public class GHue : GModule
    {
        #region 객체
        private static int count = 1;
        private static string appKey;
        private static string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GHue";
        private static bool changing = false;

        static ILocalHueClient client;
        static IBridgeLocator locator = new HttpBridgeLocator();
        static IEnumerable<string> bridgeIPs;
        #endregion

        #region 이벤트
        [GCommand("휴가 연결되었을 때")]
        public static event ConnectedEventHandler Connected;
        public delegate void ConnectedEventHandler();
        #endregion

        #region 내부 함수
        private static async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer timer = sender as Timer;

            try
            {
                appKey = await client.RegisterAsync("ghueapp", "ghuedevice");

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                StreamWriter writer = File.CreateText(dirPath + @"\appKey.txt");
                writer.Write(appKey);
                writer.Flush();

                Connected?.Invoke();
                MessageBox.Show("새로운 휴 브릿지에 연결되었습니다.");

                timer.Stop();
                count = 0;
            }
            catch (Exception)
            {
                if (count >= 10)
                {
                    timer.Stop();
                    count = 0;
                    MessageBox.Show("휴 브릿지 링크 대기 시간을 초과하였습니다.");
                }
                else
                {
                    count++;
                }
            }
        }
        #endregion

        #region 사용자 함수
        [GCommand("휴 브릿지에 연결")]
        public static async void HUEInitialize()
        {
            bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            client = new LocalHueClient(bridgeIPs.First());

            if (File.Exists(dirPath + @"\appKey.txt"))
            {
                appKey = File.ReadAllText(dirPath + @"\appKey.txt");
            }

            if (appKey != null)
            {
                client.Initialize(appKey);
                Connected?.Invoke();
                MessageBox.Show("기존의 휴 브릿지에 연결되었습니다.");
            }
            else
            {
                MessageBox.Show("10초 이내에 휴 브릿지의 링크 버튼을 눌러주세요.");

                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
        }

        [GCommand("휴 전원 켜기")]
        public static void HUEOn()
        {
            if (client == null) return;

            var command = new LightCommand();
            command.On = true;
            command.TransitionTime = TimeSpan.FromMilliseconds(0);

            client.SendCommandAsync(command);
        }

        [GCommand("휴 전원 끄기")]
        public static void HUEOff()
        {
            if (client == null) return;

            var command = new LightCommand();
            command.On = false;
            command.TransitionTime = TimeSpan.FromMilliseconds(0);

            client.SendCommandAsync(command);
        }

        [GCommand("휴 밝기를 {0}%로 설정")]
        public static async void HUEBright(int value)
        {
            if (changing) return;
            if (client == null) return;

            changing = true;

            var command = new LightCommand();
            command.Brightness = (byte)(255 / 100 * value);

            await client.SendCommandAsync(command);
            changing = false;
        }

        [GCommand("휴 색상을 #{0}로 설정")]
        public static void HUEColor(string value)
        {
            var command = new LightCommand();
            command.SetColor("#" + value);

            client.SendCommandAsync(command);
        }
        #endregion
    }
}
