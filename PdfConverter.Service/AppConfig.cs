using System.Configuration;

namespace PdfConverter.Service
{
    public class AppConfig
    {
        public static string[] AllowedFileTypes = ConfigurationManager.AppSettings["SupportedFileTypes"].Split(';');
    }
}
