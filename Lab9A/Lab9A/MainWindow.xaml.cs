using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Lab9A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _day;
        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertyChanged(nameof(Day));
            }
        }

        private int _month;
        public int Month
        {
            get { return _month; }
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Day = 10;
            Month = 10;
            Year = 2020;
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string txt)
        {

            PropertyChangedEventHandler handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(txt));
            }
        }
    }
}
