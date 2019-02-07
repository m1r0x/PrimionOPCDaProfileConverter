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
using System.IO;
using Microsoft.Win32;
using System.Xml;

namespace PrimionOPCDaProfileConverter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() != true) { return; }

            // Load XML document from selected source.

            XmlDocument XMLdoc = new XmlDocument();

            try
            {
                XMLdoc.Load(dlg.FileName);
            }
            catch (XmlException)
            {
                MessageBox.Show("The XML file is invalid");
                return;
            }

            rtbOpenFile.Text = dlg.FileName;
            vXMLViewer.xmlDocument = XMLdoc;

        }

        private void btnClearFile_Click(object sender, RoutedEventArgs e)
        {
            rtbOpenFile.Text = string.Empty;
            vXMLViewer.xmlDocument = null;
        }

        private void btnExportToUMS_Click(object sender, RoutedEventArgs e)
        {


            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(rtbOpenFile.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("No XML File selected");
                return;
            }



            XmlNodeList itemRefList = xmldoc.GetElementsByTagName("item");
            foreach (XmlNode xn in itemRefList)
            {

                XmlNodeList doors = xmldoc.SelectNodes("id");
                foreach (XmlNode xItem in doors)
                {
                    string doorname = xItem.Value;
                    tbTest.Text = doorname.ToString();
                }

            }


        }
    }
}
