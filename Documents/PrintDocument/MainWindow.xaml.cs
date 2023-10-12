using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace PrintDocument {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void PrintWholeDoc(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(filePath.Text)) {
                return;
            }

            PrintWholeDocument(filePath.Text);
        }

        private static bool PrintWholeDocument(string xpsFilePath, bool hidePrintDialog = false) {
            PrintDialog printDialog = new();
            if (!hidePrintDialog) {
                bool? isPrinted = printDialog.ShowDialog();
                if (isPrinted != true) {
                    return false;
                }
            }

            // Print the whole document
            try {
                // open the selected document
                XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

                // Get a fixed document squence for the selected document
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Create a paginator for all pages in the selected document
                DocumentPaginator docPaginator = fixedDocSeq.DocumentPaginator;

                // Print to a new file
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}");
                return true;
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void SelectFile(object sender, RoutedEventArgs e) {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".docx";
            dialog.Filter = "*.docx|*.docx";
            bool? result = dialog.ShowDialog();
            if (result == true) {
                filePath.Text = dialog.FileName;
            }
        }
    }
}
