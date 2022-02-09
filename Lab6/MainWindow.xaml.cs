using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                searchingResults.Clear();

                IEnumerable<string> allFiles = Directory
                    .EnumerateFiles(
                    pathToFile.Text, 
                    nameFileSearch.Text, 
                    (bool)checkBox.IsChecked ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);

                foreach (var fileName in allFiles)
                {
                    searchingResults.Text += fileName + "\n";
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }          
        }

        private void overviewButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathToFile.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void archive_Click(object sender, RoutedEventArgs e)
        {
            const string ArchivePath = @"C:\\Users\mamed\Documents\TestFolder\testarchive.zip";

            OpenFileDialog openFileDialog = new OpenFileDialog();
          
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (ZipArchive zipArchive = ZipFile.Open(ArchivePath, ZipArchiveMode.Create))
                    {     
                        zipArchive.CreateEntryFromFile(openFileDialog.FileName, openFileDialog.SafeFileName);
                    }
                }
                catch (Exception)
                {
                    using (ZipArchive zipArchive = ZipFile.Open(ArchivePath, ZipArchiveMode.Update))
                    {
                        zipArchive.CreateEntryFromFile(openFileDialog.FileName, openFileDialog.SafeFileName);
                    }
                }
                
            }       
        }
    }
}
