using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PdfConverter.Service.Converters
{
    public abstract class Converter
    {
        public readonly string SupportedExtension;

        protected Queue<DocumentInfo> ConversionQueue { get; }
        protected Thread ConversionThread { get; set; }

        protected Converter()
        {
            ConversionQueue = new Queue<DocumentInfo>();
        }

        protected Converter(string extension)
        {
            ConversionQueue = new Queue<DocumentInfo>();
            SupportedExtension = extension;
        }

        public void Push(DocumentInfo document)
        {
            if (ConversionQueue.All(x => x.Name != document.Name))
            {
                ConversionQueue.Enqueue(document);
            }

            if (ConversionThread == null || !ConversionThread.IsAlive)
            {
                ConversionThread = new Thread(Convert);
                ConversionThread.Start();
            }
        }

        protected abstract void Convert();

        
    }
}