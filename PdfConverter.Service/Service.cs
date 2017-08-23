using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;

namespace PdfConverter
{
    public class Service
    {
        private static FileSystemWatcher _watcher;
        private PdfConverter _pdfConverter;

        public void Start()
        {
            _pdfConverter = new PdfConverter();

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

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var doc = new DocumentInfo()
            {
                Name = e.Name,
                Path = e.FullPath.TrimEnd(e.Name.ToCharArray()),
                FullPath = e.FullPath,
                Extension = e.FullPath.Split('.').Last()
            };

            _pdfConverter.Push(doc);
        }
    }
}
