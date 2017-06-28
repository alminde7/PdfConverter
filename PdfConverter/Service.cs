using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Word;
using Pmd.WindowsService;

namespace PdfConverter
{
    public class Service : IService
    {
        private static FileSystemWatcher _watcher;

        public void Start()
        {
            var folderPath = ConfigurationManager.AppSettings["WatchFolder"];
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                throw new KeyNotFoundException("No WatchFolder specified in appSettings");
            }
            
            _watcher = new FileSystemWatcher();
            _watcher.Path = folderPath;
            _watcher.Created += OnChanged;
            _watcher.Filter = "*.docx";
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _watcher?.Dispose();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {

            Application app = null;
            Document doc = null;
            try
            {
                _watcher.EnableRaisingEvents = false;

                string newPath = "";

                if (e.Name.EndsWith(".docx"))
                {
                    var newName = e.Name.Replace(".docx", ".pdf");
                    newPath = e.FullPath.Replace(e.Name, newName);
                }

                app = new Microsoft.Office.Interop.Word.Application();
                doc = app.Documents.Open(e.FullPath);

                doc.SaveAs2(newPath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                doc.Close();
                app.Quit();
            }
            catch (Exception exception)
            {
                doc?.Close();
                app?.Quit();
                _watcher.EnableRaisingEvents = true;
            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }
    }
}
