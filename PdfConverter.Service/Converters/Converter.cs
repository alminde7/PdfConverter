using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PdfConverter.Service.Converters
{
    public abstract class Converter
    {
        protected Queue<DocumentInfo> ConversionQueue { get; }

        protected Thread ConversionThread { get; set; }

        protected Converter()
        {
            ConversionQueue = new Queue<DocumentInfo>();
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
