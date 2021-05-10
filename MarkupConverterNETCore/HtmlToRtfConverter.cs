using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace MarkupConverter
{
    public static class HtmlToRtfConverter
    {

        public static string ConvertHtmlToRtf(string htmlText)
        {
            var xamlText = HtmlToXamlConverter.ConvertHtmlToXaml(htmlText, false);

            return ConvertXamlToRtf(xamlText);
        }

        private static string ConvertXamlToRtf(string xamlText)
        {
            if (string.IsNullOrEmpty(xamlText)) return "";
            var flowDocument = new FlowDocument();
            

            var textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);

            //Create a MemoryStream of the xaml content

            using (var xamlMemoryStream = new MemoryStream())
            {
                using (var xamlStreamWriter = new StreamWriter(xamlMemoryStream))
                {
                    xamlStreamWriter.Write(xamlText);
                    xamlStreamWriter.Flush();
                    xamlMemoryStream.Seek(0, SeekOrigin.Begin);

                    //Load the MemoryStream into TextRange ranging from start to end of RichTextBox.
                    textRange.Load(xamlMemoryStream, DataFormats.Xaml);
                }
            }

            using (var rtfMemoryStream = new MemoryStream())
            {

                textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                textRange.Save(rtfMemoryStream, DataFormats.Rtf);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }

        }




    }
}
