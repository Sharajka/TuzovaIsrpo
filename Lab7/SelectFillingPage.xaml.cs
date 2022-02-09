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

namespace Task1
{
    /// <summary>
    /// Interaction logic for SelectFillingPage.xaml
    /// </summary>
    public partial class SelectFillingPage : Page
    {
        private readonly List<PizzaFilling> avaliblePizzaFillings = new List<PizzaFilling>();
        private readonly List<PizzaFilling> settedPizzaFillings = new List<PizzaFilling>();

        public SelectFillingPage(List<PizzaFilling> selectedPizzaFillings)
        {
            InitializeComponent();

            var avaliblePizzaFillings = PizzaFilling.GenerateTestData();
            avaliblePizzaFillings.RemoveAll(item =>
                    selectedPizzaFillings.Any(seleceted => seleceted.Name == item.Name)
                );

            this.avaliblePizzaFillings = avaliblePizzaFillings;
            this.settedPizzaFillings = selectedPizzaFillings;
            SyncListsWithView();
        }

        private void SyncListsWithView()
        {
            avalivableFillingsListView.ItemsSource = avaliblePizzaFillings;
            settedFillingsListView.ItemsSource = settedPizzaFillings;
        }

        private void addFilling_Click(object sender, RoutedEventArgs e)
        {
            if (avalivableFillingsListView.SelectedItem == null)
                return;

            var item = settedFillingsListView.SelectedItem as PizzaFilling;
            settedPizzaFillings.Remove(item);
            avaliblePizzaFillings.Add(item);
            SyncListsWithView();
        }

        private void removeFilling_Click(object sender, RoutedEventArgs e)
        {
            if (settedFillingsListView.SelectedItem == null)
                return;

            var item = settedFillingsListView.SelectedItem as PizzaFilling;
            settedPizzaFillings.Add(item);
            avaliblePizzaFillings.Remove(item);
            SyncListsWithView();
        }

        private void addAllSelectedFillingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
