using System.Collections.Generic;
using PdfConverter.Service.Converters;
using PdfConverter.Service.Models;

namespace PdfConverter.Service
{
    public class PdfConverter
    {
        public DocxConverter DocxConverter { get; }
        public PptxConverter PptxConverter { get; }
        public XlsxConverter XlsxConverter { get; }

        public IDictionary<string, Converter> Converters { get; }
        
        // hardcoded dependencies
        public PdfConverter()
        {
            Converters = new Dictionary<string, Converter>();

            DocxConverter = new DocxConverter();
            PptxConverter = new PptxConverter();
            XlsxConverter = new XlsxConverter();

            Converters.Add(DocxConverter.SupportedExtension, DocxConverter);
            Converters.Add(PptxConverter.SupportedExtension, PptxConverter);
            Converters.Add(XlsxConverter.SupportedExtension, XlsxConverter);
        }

        // constructor injection dependencies
        public PdfConverter(IEnumerable<Converter> converters)
        {
            Converters = new Dictionary<string, Converter>();

            foreach (var converter in converters)
            {
                Converters.Add(converter.SupportedExtension, converter);
            }
        }

        public void Push(DocumentInfo documentInfo)
        {
            Converters[documentInfo.Extension].Push(documentInfo);
        }
    }
}
