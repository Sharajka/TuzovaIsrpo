using Lab11;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Lab11B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nameDataGrid.ItemsSource = new List<Product>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() != true)
                return;

            Excel.Application excel = new Excel.Application();
            Workbook wb = excel.Workbooks.Open(openFileDialog.FileName);
            Worksheet reportWorksheet = wb.Worksheets[1];

            try
            {

                int i = 1;
                var items = new List<Product>();
                while (true)
                {
                    try
                    {

                    i++;
                    if (reportWorksheet.Cells[i, "A"].Text.ToString() == string.Empty)
                        break;

                    var item = new Product()
                    {
                        Id = SafeConvertInt32(reportWorksheet.Cells[i, "A"].Text.ToString()),
                        Name = reportWorksheet.Cells[i, "B"].Text.ToString(),
                        Count = SafeConvertInt32(reportWorksheet.Cells[i, "C"].Text.ToString()),
                        Price = SafeConvertInt32(reportWorksheet.Cells[i, "D"].Text.ToString())
                    };
                    items.Add(item);

                    }
                    catch (Exception)
                    {
                    }
                }
                nameDataGrid.ItemsSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл поврежден!\n" + ex.Message);
            }
        }

        private int SafeConvertInt32(string value)
        {
            try
            {
                return Convert.ToInt32(value.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            xlApp = new Microsoft.Office.Interop.Excel.Application
            {
                DisplayAlerts = true,
                Visible = true
            };
            Workbook reportWorkbook = xlApp.Workbooks.Add();
            Worksheet reportWorksheet = reportWorkbook.Worksheets.Add();

            reportWorksheet.Cells[1, "A"] = "Id";
            reportWorksheet.Cells[1, "B"] = "Name";
            reportWorksheet.Cells[1, "C"] = "Total";
            reportWorksheet.Cells[1, "D"] = "Price";

            int i = 1;
            foreach (var item in (nameDataGrid.ItemsSource as List<Product>))
            {
                i++;
                reportWorksheet.Cells[i, "A"] = item.Id;
                reportWorksheet.Cells[i, "B"] = item.Name;
                reportWorksheet.Cells[i, "C"] = item.Count;
                reportWorksheet.Cells[i, "D"] = item.Price;
            }


        }
    }
}
