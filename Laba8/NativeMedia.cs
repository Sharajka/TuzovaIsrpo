using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    internal static class NativeMedia
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern uint InvokeMediaCommand(string command, StringBuilder returnString, int uReturnLength,
            IntPtr hWndCallback);

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume", SetLastError = true)]
        public static extern uint ChangeVolume(IntPtr owner, uint volume);

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int SetVolume(IntPtr hwo, uint volume);

        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "PlaySound")]
        public static extern bool PlaySound(string path, IntPtr hmod, uint fdwSound);
    }
}
