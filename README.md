# .docx to PDF converter

This service converte .docx documents to PDF. It watches a folder - when a .docx document is dropped into the folder
the service will automatically convert the document to PDF. 

The path for the watchfolder is specified in appSettings.

```xml
  <appSettings>
    <add key="WatchFolder" value="Path to folder"/>
  </appSettings>
```