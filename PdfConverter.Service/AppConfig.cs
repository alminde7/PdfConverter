using System.Configuration;

namespace PdfConverter.Service
{
    public class AppConfig
    {
        public static string[] AllowedFileTypes = ConfigurationManager.AppSettings["SupportedFileTypes"].Split(';');
    }

    public class Constants
    {
        public static readonly string PDFExtension = ".pdf";
    }
}
