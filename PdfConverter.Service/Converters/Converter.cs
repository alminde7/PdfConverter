using System.Collections.Generic;
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
            ConversionQueue.Enqueue(document);

            if (ConversionThread == null || !ConversionThread.IsAlive)
            {
                ConversionThread = new Thread(Convert);
                ConversionThread.Start();
            }
        }

        protected abstract void Convert();
    }
}
