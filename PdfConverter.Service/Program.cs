
using Topshelf;

namespace PdfConverter.Service
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

                x.SetDisplayName("PDF Converter");
                x.SetServiceName("Word to PDF Conversion");
                x.SetDescription("Services watches a folder an when a word doc is dropped into the folder, it will automatically convert it to a PDF");
                
                x.StartAutomatically();
            });
        }
    }
}
