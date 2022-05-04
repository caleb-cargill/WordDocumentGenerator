using System.IO;
using System.Xml;
using System.Xml.Xsl;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using XSLT.WordDocument.Generator.Enums;

namespace XSLT.WordDocument.Generator
{
    class Program
    {

        /// <summary>
        /// This application uses the xslt file created from a 
        /// Word template document (see Templates folder) to transform 
        /// data stored in an xml format (see Data folder) into a
        /// Word document using Open XML 2.0 SDK 
        /// </summary>  
        static void Main(string[] args)
        {
            // Document Type to Generate
            DocumentName doc = DocumentName.MyMovies;

            // Get file locations.            
            string xmlDataFile = doc.GetFormattedPath(Enums.DocumentType.Data);
            string xsltFile = doc.GetFormattedPath(Enums.DocumentType.XSLT);
            string templateDocument = doc.GetFormattedPath(Enums.DocumentType.Template);
            string generatedDocument = doc.GetFormattedPath(Enums.DocumentType.Generated);

            // Create a writer for the output of the Xsl Transformation.
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

                // Create the Xsl Transformation object.
                XslCompiledTransform transform = new XslCompiledTransform();
                transform.Load(xsltFile);

                // Transform the xml data into Open XML 2.0 Wordprocessing format.
                transform.Transform(xmlDataFile, xmlWriter);

                // Create an Xml Document of the new content.
                XmlDocument newWordContent = new XmlDocument();
                newWordContent.LoadXml(stringWriter.ToString());

                // Copy the Word template document to the document being generated.
                File.Copy(templateDocument, generatedDocument, true);

                // Use the Open XML SDK version 2.0 to open the output document in edit mode.                
                using (WordprocessingDocument generated =
                  WordprocessingDocument.Open(generatedDocument, true))
                {
                    // Using the body element within the new content XmlDocument create a new Open Xml Body object.                    
                    Body updatedBodyContent = new Body(newWordContent.DocumentElement.InnerXml);

                    // Replace the existing Document Body with the new content.
                    generated.MainDocumentPart.Document.Body = updatedBodyContent;

                    // Save the generated document.
                    generated.MainDocumentPart.Document.Save();                        
                }
            }

            // Open the generated document
            System.Diagnostics.Process.Start(generatedDocument);
        }
    }
}