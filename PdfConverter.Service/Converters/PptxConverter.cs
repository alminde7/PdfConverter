using SautinSoft;

namespace PdfConverter.Service.Converters
{
    public class PptxConverter : Converter
    {
        public PptxConverter() : base(".pptx")
        {
        }
        protected override void Convert()
        {
            var u = new SautinSoft.UseOffice();

            var result = u.InitPowerPoint();

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

                    result = u.ConvertFile(document.FullPath, newPath, UseOffice.eDirection.PPTX_to_PDF);
                } while (ConversionQueue.Count > 0);

                u.ClosePowerPoint();
            }

            ConversionThread.Abort();
        }
    }
}
