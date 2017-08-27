using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PdfConverter.Service.Converters;
using SautinSoft;

namespace PdfConverter.Service
{
    public class PdfConverter
    {
        public DocxConverter DocxConverter { get; }
        public PptxConverter PptxConverter { get; }
        public XlsxConverter XslxConverter { get; }
        
        public PdfConverter()
        {
            DocxConverter = new DocxConverter();
            PptxConverter = new PptxConverter();
            XslxConverter = new XlsxConverter();
        }

        public void Push(DocumentInfo documentInfo)
        {
            if (documentInfo.Extension == XslxConverter.SupportedExtension)
            {
                XslxConverter.Push(documentInfo);
            }
            else if (documentInfo.Extension == PptxConverter.SupportedExtension)
            {
                PptxConverter.Push(documentInfo);
            }
            else if (documentInfo.Extension == DocxConverter.SupportedExtension)
            {
                DocxConverter.Push(documentInfo);
            }
        }
    }
}
