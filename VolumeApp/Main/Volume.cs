using NAudio.CoreAudioApi;
using System.Runtime.InteropServices;

namespace VolumeApp.Main
{

    internal class Volume
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

       public static void VolumeMain()
        {
            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            //Console.WriteLine("Press Ctrl + F11 to decrease volume");

            while (!Program.cts.IsCancellationRequested)
            {
                if ((GetAsyncKeyState(0x11) & 0x8000) != 0)  // Ctrl
                {
                    if ((GetAsyncKeyState(0x7A) & 0x8000) != 0)
                    {
                        //Form1.textBox1.Text = "F11";
                        //Console.WriteLine("F11");
                        DecreaseVolume(defaultDevice, 3);
                    }
                    if ((GetAsyncKeyState(0x7B) & 0x8000) != 0)
                    {
                        //Form1.textBox1.Text = "F12";
                        //Console.WriteLine("F12");
                        IncreaseVolume(defaultDevice, 3);
                    }
                }

                System.Threading.Thread.Sleep(150);
            }
        }

        static void IncreaseVolume(MMDevice device, int value)
        {
            float newVolume = device.AudioEndpointVolume.MasterVolumeLevelScalar + (value / 100.0f);
            if (newVolume > 1.0f) newVolume = 1.0f;                                                      // Omezit maximální hlasitost na 100% device.AudioEndpointVolume.MasterVolumeLevelScalar
            device.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
        }

        static void DecreaseVolume(MMDevice device, int value)
        {
            float newVolume = device.AudioEndpointVolume.MasterVolumeLevelScalar - (value / 100.0f);
            if (newVolume < 0.0f) newVolume = 0.0f;                                                       // Omezit minimální hlasitost na 0% device.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume; }
            device.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
        }
    }
}
