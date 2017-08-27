using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PdfConverter.Service.Converters;
using SautinSoft;

namespace PdfConverter.Service
{
    public class PdfConverter
    {
        public DocxConverter DocxConverter { get; set; }
        public PptxConverter PptxConverter { get; set; }
        public XlsxConverter XslxConverter { get; set; }
        
        public PdfConverter()
        {
            DocxConverter = new DocxConverter();
            PptxConverter = new PptxConverter();
            XslxConverter = new XlsxConverter();
        }

        public void Push(DocumentInfo documentInfo)
        {
            switch (documentInfo.Extension)
            {
                case ".xlsx":
                    XslxConverter.Push(documentInfo);
                    break;
                case ".pptx":
                    PptxConverter.Push(documentInfo);
                    break;
                case ".docx":
                    DocxConverter.Push(documentInfo);
                    break;
            }
        }
    }
}
