
using Topshelf;

namespace PdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(service => new Service());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.SetServiceName("Word to PDF Conversion");
                x.SetDescription("asd");
                x.SetDisplayName("PDFCONVERTER");

                x.StartAutomatically();
            });
        }
    }
}
