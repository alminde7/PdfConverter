using System;
using Microsoft.Office.Interop.Word;
using SautinSoft;

namespace PdfConverter.Service.Converters
{
    public class XlsxConverter : Converter
    {
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

                    if (document.Name.EndsWith(".xlsx"))
                    {
                        var newName = document.Name.Replace(".xlsx", ".pdf");
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
