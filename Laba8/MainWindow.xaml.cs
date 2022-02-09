using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Laba8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("winmm.dll")]
        static extern uint mciSendString(string command, StringBuilder returnString, int uReturnLength, IntPtr hWndCallback);


        public MainWindow()
        {
            InitializeComponent();


            StartButton.Click += (sender, e) =>
            {
                var path = System.IO.Path.GetFullPath("../../egg.mp3");

                mciSendString($"open {path} type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                mciSendString($"play {path} from 0", null, 0, IntPtr.Zero);
            };
            
        }
    }
}
