# PDF Converter

This service converte .docx documents to PDF. It watches a folder - when a document is dropped into the folder
the service will automatically convert the document to PDF. 

The path for the watchfolder is specified in appSettings.

```xml
  <appSettings>
    <add key="WatchFolder" value="Path to folder"/>
  </appSettings>
```

## Supported file types
As of now the file types supported is:
- .docx
- .pptx
- .xlsx

## Future work
To be determined...
