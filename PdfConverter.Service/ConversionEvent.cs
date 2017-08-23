using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PdfConverter
{
    public class ConversionEvent
    {
        public DocumentInfo DocumentInfo { get; set; }
        public string OutputExtension { get; set; }
        public string OutputFullPath { get; set; }
    }

    public class DocumentInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public string Extension { get; set; }
    }
}
