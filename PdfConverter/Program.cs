
namespace PdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Pmd.WindowsService.Service.Bootstrap<Service>();
        }
    }
}
