using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Lab_6_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileStream fileStream = null;
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void сreateFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {     
                File.WriteAllText(nameFile.Text, dataInsideFile.Text);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Введите имя файла");
            }
        }

        private void overviewFile_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nameFile.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nameFile.Text = openFileDialog.FileName;
            }

            dataInsideFile.Text =  File.ReadAllText(nameFile.Text);
        }
    }
}
