using System.Windows;
using MarkupConverter;

namespace MarkupConverter
{

    public partial class Window1 : Window
    {
        private IMarkupConverter markupConverter;
        public Window1()
        {
            markupConverter = new MarkupConverter();
        }

        public void convertHTMLToXAML(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = markupConverter.ConvertHtmlToXaml(myTextBox.Text);
            MessageBox.Show("Content Conversion Complete!");
        }

        public void convertXAMLToHTML(object sender, RoutedEventArgs e)
        {
            myTextBox2.Text = markupConverter.ConvertXamlToHtml(myTextBox2.Text);
            MessageBox.Show("Content Conversion Complete!");
        }

        public void convertRtfToHtml(object sender, RoutedEventArgs e)
        {
            myTextBox3.Text = markupConverter.ConvertRtfToHtml(myTextBox3.Text);
            MessageBox.Show("Content Conversion Complete!");
        }

        public void convertHtmlToRtf(object sender, RoutedEventArgs e)
        {
            myTextBox4.Text = markupConverter.ConvertHtmlToRtf(myTextBox4.Text);
            MessageBox.Show("Content Conversion Complete!");
        }

        public void copyXAML(object sender, RoutedEventArgs e)
        {
            myTextBox.SelectAll();
            myTextBox.Copy();
        }
        public void copyHTML(object sender, RoutedEventArgs e)
        {
            myTextBox2.SelectAll();
            myTextBox2.Copy();
        }

        public void copyHTML2(object sender, RoutedEventArgs e)
        {
            myTextBox3.SelectAll();
            myTextBox3.Copy();
        }

        public void copyRTF(object sender, RoutedEventArgs e)
        {
            myTextBox4.SelectAll();
            myTextBox4.Copy();
        }
    }
}