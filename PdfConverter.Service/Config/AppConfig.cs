using System.Configuration;

namespace PdfConverter.Service.Config
{
    public class AppConfig
    {
        public static string[] AllowedFileTypes = ConfigurationManager.AppSettings["SupportedFileTypes"].Split(';');
    }
}
