using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Word = Microsoft.Office.Interop.Word;

namespace Lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DateTime ORDER_DATE_TIME = new DateTime(2017, 12, 2);
        private Word.Application winword;
        private Word.Document document;
        private object missing;
        private const int ORDER_NUMBER = 108;

        private string wordFile;
        private Word.Application wordApp;
        private Word.Document wordDoc;
        private Word.Range range;

        public MainWindow()
        {
            InitializeComponent();

            nameDataGrid.ItemsSource = new List<Product>();
        }

        private async void createDocument_Click(object sender, RoutedEventArgs e)
        {
            var items = (List<Product>)nameDataGrid.ItemsSource;


            totalTextBox.Text = items.Sum(item => item.TotalPrice).ToString();

            nameDataGrid.ItemsSource = null;
            nameDataGrid.ItemsSource = items;

            await Task.Delay(10);
            wordFile = SetFileDetails("WordCreationTest.docx");
            InitializeWordObjects();
            AddInfo();
            AddPokupatel();
            AddPostasik();
            AddTableToWord();
            AddTotal();
            //SaveCloseQuitWord();
        }

        private void AddTotal()
        {
            range.InsertParagraphAfter();
            range.InsertAfter(
                $"Итого:    {totalTextBox.Text} руб."
                );


            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
        }

        private string SetFileDetails(string filename)
        {
            string userDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return userDesktop + "\\" + filename;
        }

        private void InitializeWordObjects()
        {
            wordApp = new Word.Application();
            wordApp.Visible = true;
            wordDoc = new Word.Document();
            wordDoc = wordApp.Documents.Add();
            range = wordDoc.Range();
        }

        private void AddInfo()
        {
            range.InsertParagraphAfter();
            range.InsertAfter(
                "Расходная накладная № "
                );

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.InsertAfter($"{ORDER_NUMBER}");
            range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            range.Font.Bold = Convert.ToInt32(true);
            
            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.InsertAfter(" от ");
            range.Font.Bold = Convert.ToInt32(false);
            range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.InsertAfter($"{ORDER_DATE_TIME:dd.MM.yyyy}");
            range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            range.Font.Bold= Convert.ToInt32(true);

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
        }

        private void AddPostasik()
        {
            range.InsertParagraphAfter();
            range.InsertAfter(
                "Поставщик: "
                );

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.InsertAfter($"{postavskiTextBox.Text}");
            range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            range.Font.Bold = Convert.ToInt32(true);

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
        }


        private void AddPokupatel()
        {
            range.InsertParagraphAfter();
            range.InsertAfter(
                "Поставщик: "
                );

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            range.InsertAfter($"{pokupatelTextBox.Text}");
            range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            range.Font.Bold = Convert.ToInt32(true);

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
        }

        private void AddTableToWord()
        {
            var items = (List<Product>)nameDataGrid.ItemsSource;
            if (items.Count == 0)
                return;


            Word.Table table = wordDoc.Tables.Add(
                range, items.Count + 1, 5,
                Word.WdDefaultTableBehavior.wdWord9TableBehavior
                );
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            range = wordDoc.Content;

            table.Rows[1].Range.Font.Bold = Convert.ToInt32(false);
            table.Cell(1, 1).Range.Text = "№";
            table.Cell(1, 2).Range.Text = "Товар";
            table.Cell(1, 3).Range.Text = "Количество";
            table.Cell(1, 4).Range.Text = "Цена";
            table.Cell(1, 5).Range.Text = "Сумма";
            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            for (int i = 0; i < items.Count; i++)
            {
                table.Rows[i + 2].Range.Font.Bold = Convert.ToInt32(true);
                table.Cell(i + 2, 1).Range.Text = items[i].Id.ToString();
                table.Cell(i + 2, 2).Range.Text = items[i].Name.ToString();
                table.Cell(i + 2, 3).Range.Text = items[i].Count.ToString() + " кг.";
                table.Cell(i + 2, 4).Range.Text = items[i].Price.ToString() + " руб";
                table.Cell(i + 2, 5).Range.Text = items[i].TotalPrice.ToString() + " руб";
            }

            table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
        }

        private async void SaveCloseQuitWord()
        {
            wordDoc.SaveAs2(wordFile);
            wordDoc.Close();
            Marshal.FinalReleaseComObject(wordDoc);
            wordApp.Quit();
            Marshal.FinalReleaseComObject(wordApp);
        }
    }
}
