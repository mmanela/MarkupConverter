using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace MarkupConverter
{
    public static class RtfToHtmlConverter
    {
        private const string FlowDocumentFormat = "<FlowDocument>{0}</FlowDocument>";

        public static string ConvertRtfToHtml(string rtfText)
        {
            var xamlText = string.Format(FlowDocumentFormat, ConvertRtfToXaml(rtfText));

            return HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);
        }

        private static string ConvertRtfToXaml(string rtfText)
        {

            if (string.IsNullOrEmpty(rtfText)) return "";
            var flowDocument = new FlowDocument();
            var textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
            //Create a MemoryStream of the Rtf content

            using (var rtfMemoryStream = new MemoryStream())
            {
                using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                {
                    rtfStreamWriter.Write(rtfText);
                    rtfStreamWriter.Flush();
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);

                    //Load the MemoryStream into TextRange ranging from start to end of RichTextBox.
                    textRange.Load(rtfMemoryStream, DataFormats.Rtf);
                }
            }

            using (var rtfMemoryStream = new MemoryStream())
            {

                textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                textRange.Save(rtfMemoryStream, DataFormats.Xaml);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }

        }




    }
}
