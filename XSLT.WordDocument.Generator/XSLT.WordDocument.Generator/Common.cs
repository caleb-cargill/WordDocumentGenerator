using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSLT.WordDocument.Generator.Enums;
using System.IO;
using XSLT.WordDocument.Generator.Models;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator
{
    public static class Common
    {
        /// <summary>
        /// returns a formatted file path for the passed in document of document type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFormattedPath(this DocumentName name, DocumentType type)
        {
            return $"..\\..\\{type}\\{name}{GetFileExtension(type)}";
        }

        /// <summary>
        /// returns the correct file extension for the passed in document type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFileExtension(DocumentType type)
        {
            switch (type)
            {
                case (DocumentType.Data):
                    return ".xml";
                case (DocumentType.XSLT):
                    return ".xslt";
                case (DocumentType.Template):
                    return "Template.docx";
                case (DocumentType.Generated):
                    return ".docx";
                default:
                    return ".txt";
            }
        }

        /// <summary>
        /// Generates XSLT file for document based off of XML data
        /// </summary>
        /// <param name="name"></param>
        public static void GenerateXSLT(this DocumentName name)
        {
            string path = $"..\\..\\XSLT\\{name}.xslt";

            using (FileStream fs = File.Create(path)) { };

            using (StreamWriter sw = new StreamWriter(path: path))
            {
                // standard open tags
                sw.WriteLine(XSLT.GetOpenTags());

                // content
                sw.WriteLine(GetXSLTContent(name));

                // document formatting and standard closing tags
                sw.WriteLine(Constants.OpenCloseTagFormat);
                sw.WriteLine(XSLT.GetCloseTags());
            }
        }

        /// <summary>
        /// Returns the xml for content of XSLT file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetXSLTContent(DocumentName name)
        {
            string content = string.Empty;

            switch (name)
            {
                case (DocumentName.MyMovies):
                    content = GetXSLTMovieContent();
                    break;
                case (DocumentName.SimpleEquations):

                    break;
                case (DocumentName.FormattedEquations):

                    break;
            }

            return content;
        }

        /// <summary>
        /// Returns xml for movie content of XSLT file
        /// </summary>
        /// <returns></returns>
        public static string GetXSLTMovieContent()
        {
            string content = string.Empty;

            XmlSerializer serializer = new XmlSerializer(typeof(Movies));

            Movies movies = null;

            using (StringReader reader = new StringReader(System.IO.File.ReadAllText("..\\..\\Data\\MyMovies.xml")))
            {
                movies = (Movies)serializer.Deserialize(reader);
            }

            content += XSLT.GetHeader("Movies");

            content += XSLT.GetForeach("Movies/Genre");

            content += XSLT.GetHeading2Tags(select: nameof(Genre.Name).ToLower());

            content += XSLT.GetForeach("Movie");

            content += XSLT.GetOpenParagraph();
            content += XSLT.GetListStyle();
            content += XSLT.GetOpenWords(bold: true);
            content += XSLT.GetOpenText(preserveSpace: false);
            content += XSLT.GetSelect(path: "Name");
            content += XSLT.GetCloseText();
            content += XSLT.GetCloseWords();
            content += XSLT.GetOpenWords(bold: false);
            content += XSLT.GetOpenText(preserveSpace: true);
            content += " (";
            content += XSLT.GetSelect(path: "Released");
            content += ") ";
            content += XSLT.GetCloseText();
            content += XSLT.GetCloseWords();
            content += XSLT.GetCloseParagraph();

            content += XSLT.GetForeachClose();
            content += XSLT.GetForeachClose();

            return content;
        }


    }
}

