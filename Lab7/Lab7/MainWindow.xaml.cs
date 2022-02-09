using System;
using System.Collections.Generic;
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

namespace Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<PizzaFilling> selectedFillings = new List<PizzaFilling>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void selectFillingButton_Click(object sender, RoutedEventArgs e)
        {
            SelectFillingWindow selectFillings = new SelectFillingWindow(selectedFillings);
            if(selectFillings.ShowDialog() == true)
            {
                fillingListView.ItemsSource = null;
                selectedFillings = selectFillings.SettedPizzaFillings;
                fillingListView.ItemsSource = selectedFillings;
            }
        }

        private void arrangeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Заказ стоит {GetSizeOfPizza() + selectedFillings.Sum(item => item.Price)} рублей");
        }

        private decimal GetSizeOfPizza()
        {
            if (pizza450CheckBox.IsChecked == true)
                return 450;

            if (pizza340CheckBox.IsChecked == true)
                return 340;

            if (pizza280CheckBox.IsChecked == true)
                return 280;

            return 0;
        }
    }
}
