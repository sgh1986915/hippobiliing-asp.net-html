using System;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace NpiImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            OpenFile();
        }

        private void FilePath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            var result = dialog.ShowDialog();

            if (result != null && result.Value)
            {
                FilePath.Text = dialog.FileName;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!File.Exists(FilePath.Text)) return;

            ProgressInfo.Text = "";
            Import.IsEnabled = false;

            var filePath = FilePath.Text;
            var connectStr = ConnectionString.Text;

            new Thread(x => Core.CsvReader.ReadCsv(filePath, connectStr, UpdateProgressInfo, Completed))
            {
                IsBackground = true
            }.Start();
        }

        private void UpdateProgressInfo(string info)
        {
            Dispatcher.BeginInvoke((Action) (() =>
            {
                ProgressInfo.Text = info;
                ProgressInfo.ScrollToEnd();
            }));
        }

        private void Completed()
        {
            Dispatcher.BeginInvoke((Action) (() =>
            {
                ProgressInfo.Text += Environment.NewLine + "Import Completed";
                ProgressInfo.ScrollToEnd();
                Import.IsEnabled = true;
            }));
        }
    }
}