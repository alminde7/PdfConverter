using System;
using Microsoft.Office.Interop.Word;
using PdfConverter.Service.Config;
using SautinSoft;

namespace PdfConverter.Service.Converters
{
    public class XlsxConverter : Converter
    {
        public XlsxConverter() : base(".xlsx") {}

        protected override void Convert()
        {
            https://code.msdn.microsoft.com/windowsapps/Convert-Power-Point-c88aed9d
            SautinSoft.UseOffice u = new SautinSoft.UseOffice();

            var result = u.InitExcel();

            if (result == 0) //succesfully opend program
            {
                do
                {
                    var document = ConversionQueue.Dequeue();

                    string newPath = "";

                    if (document.Name.EndsWith(SupportedExtension))
                    {
                        var newName = document.Name.Replace(SupportedExtension, Constants.PDFExtension);
                        newPath = document.FullPath.Replace(document.Name, newName);
                    }

                    result = u.ConvertFile(document.FullPath, newPath, UseOffice.eDirection.XLSX_to_PDF);
                } while (ConversionQueue.Count > 0);

                u.CloseExcel();
            }

            ConversionThread.Abort();
        }
    }
}
