using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;

namespace Laba8
{
    public partial class MainWindow : Window
    {
        private const string PathToChelovekYaitsa = "../../egg.mp3";

        private Sound _sound;

        public MainWindow()
        {
            InitializeComponent();
            RollbackToYaitsa();

            Closing += (sender, e) => ClearSound();

            StartButton.Click += (sender, e) => _sound.Play();
            StopButton.Click += (sender, e) => _sound.Stop();
            PauseButton.Click += (sender, e) => _sound.Pause();

            VolumeSlider.ValueChanged += (sender, e) 
                => Sound.SetAppVolume(Convert.ToUInt32(e.NewValue));

            SpeedSlider.ValueChanged += (sender, e) 
                => _sound.SetSpeed(Convert.ToUInt32(e.NewValue));

            OpenFileButton.Click += (sender, e) =>
            {
                try
                {
                    var dialog = new OpenFileDialog();

                    if (dialog.ShowDialog(this) != true) 
                        return;

                    ClearSound();
                    _sound = new Sound(dialog.FileName);

                }
                catch
                {
                    RollbackToYaitsa();
                }
            };
        }

        private void RollbackToYaitsa()
        {
            ClearSound();
            _sound = new Sound(Path.GetFullPath(PathToChelovekYaitsa));
        }

        private void ClearSound()
        {
            _sound?.Dispose();
            _sound = null;
        }
    }
}
