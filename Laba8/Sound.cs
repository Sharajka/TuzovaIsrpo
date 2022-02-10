using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    internal class Sound : IDisposable
    {
        private static int _countSounds;

        private readonly int _currentSound;
        private readonly string _mediaName;

        public static void SetAppVolume(uint volume)
        {
            if (volume > 10)
                volume = 10;

            if (volume < 0)
                volume = 0;

            // Никто не знает, что это такое, так что сделаем вид, что очень нужно
            var calcVol = ushort.MaxValue / 10 * volume;
            var newAppVolume = (calcVol & 0xffffffff) | (calcVol << 16);

            NativeMedia.SetVolume(default, newAppVolume);
        }

        public Sound(string pathToSound)
        {
            _countSounds++;
            _currentSound = _countSounds;
            _mediaName = $"MediaFile{_currentSound}";

            var command = $"open {pathToSound} type mpegvideo alias {_mediaName}";
            InvokeMediaCommandShort(command);
        }

        public void Play() => InvokeMediaCommandShort($"play {_mediaName} repeat");

        public void Resume() => InvokeMediaCommandShort($"resume {_mediaName}");

        public void Pause() => InvokeMediaCommandShort($"pause {_mediaName}");

        public void Stop() => InvokeMediaCommandShort($"stop {_mediaName}");

        public void Close() => InvokeMediaCommandShort($"close {_mediaName}");


        public void SetSpeed(uint speed)
        {
            if (speed > 2000)
                speed = 2000;

            if (speed < 0)
                speed = 0;

            InvokeMediaCommandShort($"set {_mediaName} speed {speed}");
        }

        private static void InvokeMediaCommandShort(string command)
            => NativeMedia.InvokeMediaCommand(command, null, 0, default);

        public void Dispose() => Close();
    }
}
