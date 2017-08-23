using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace PdfConverter
{
    public class PdfConverter
    {
        private Queue<DocumentInfo> ConversionQueue { get;}

        private Thread ConversionThread { get; set; }

        public PdfConverter()
        {
            ConversionQueue = new Queue<DocumentInfo>();
            
        }

        public void Push(DocumentInfo documentInfo)
        {
            if (!ConversionQueue.Contains(documentInfo) && !documentInfo.FullPath.Contains('~'))
            {
                ConversionQueue.Enqueue(documentInfo);
            }

            if (ConversionThread == null || !ConversionThread.IsAlive)
            {
                ConversionThread = new Thread(Convert);
                ConversionThread.Start();
            }
        }

        private void Convert()
        {
            Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = null;
            
            do
            {
                try
                {
                    var document = ConversionQueue.Dequeue();

                    string newPath = "";

                    if (document.Name.EndsWith(".docx"))
                    {
                        var newName = document.Name.Replace(".docx", ".pdf");
                        newPath = document.FullPath.Replace(document.Name, newName);
                    }

                    doc = app.Documents.Open(document.FullPath);
                    doc.SaveAs2(newPath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                    doc.Close();
                }
                catch (Exception)
                {
                    doc?.Close();
                }

            } while (ConversionQueue.Count > 0);
            
            app?.Quit();
            ConversionThread.Abort();
        }
    }
}
