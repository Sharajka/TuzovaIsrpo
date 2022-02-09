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
using System.Windows.Shapes;

namespace Lab7
{
    /// <summary>
    /// Interaction logic for SelectFillingPage.xaml
    /// </summary>
    public partial class SelectFillingWindow : Window
    {
        public List<PizzaFilling> AvaliblePizzaFillings { get; set; } = new List<PizzaFilling>();
        public List<PizzaFilling> SettedPizzaFillings { get; set; } = new List<PizzaFilling>();

        public SelectFillingWindow(List<PizzaFilling> selectedPizzaFillings)
        {
            InitializeComponent();

            var avaliblePizzaFillings = PizzaFilling.GenerateTestData();
            avaliblePizzaFillings.RemoveAll(item =>
                    selectedPizzaFillings.Any(seleceted => seleceted.Name == item.Name)
                );

            this.AvaliblePizzaFillings = avaliblePizzaFillings;
            this.SettedPizzaFillings = selectedPizzaFillings;
            SyncListsWithView();
        }

        private void SyncListsWithView()
        {
            avalivableFillingsListView.ItemsSource = null;
            settedFillingsListView.ItemsSource = null;

            avalivableFillingsListView.ItemsSource = AvaliblePizzaFillings;
            settedFillingsListView.ItemsSource = SettedPizzaFillings;
        }

        private void addFilling_Click(object sender, RoutedEventArgs e)
        {
            if (avalivableFillingsListView.SelectedItem == null)
                return;

            var items = avalivableFillingsListView.SelectedItems.Cast<PizzaFilling>();
            SettedPizzaFillings.AddRange(items);
            AvaliblePizzaFillings.RemoveAll(item => items.Contains(item));
            SyncListsWithView();
        }

        private void removeFilling_Click(object sender, RoutedEventArgs e)
        {
            if (settedFillingsListView.SelectedItem == null)
                return;

            var items = settedFillingsListView.SelectedItems.Cast<PizzaFilling>();
            AvaliblePizzaFillings.AddRange(items);
            SettedPizzaFillings.RemoveAll(item => items.Contains(item));
            SyncListsWithView();
        }

        private void addAllSelectedFillingsButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
