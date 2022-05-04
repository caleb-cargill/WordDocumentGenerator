using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSLT.WordDocument.Generator.Enums;
using System.IO;

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
                sw.WriteLine(GetXSLTOpenTags());

                // document header
                sw.WriteLine(GetXSLTHeader($"{name}"));

                // content

                // document formatting and standard closing tags
                sw.WriteLine(Constants.OpenCloseTagFormat);
                sw.WriteLine(GetXSLTCloseTags());
            }
        }

        /// <summary>
        /// Returns xml for header of XSLT file
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static string GetXSLTHeader(string header)
        {
            return @"<!-- " + header + @" Header -->
                    <w:p w14:paraId=""7039BE8E"" w14:textId=""1D8D4F4A"" w:rsidR=""005E0B98"" w:rsidRDefault=""007A5E62"" w:rsidP=""007A5E62"">
                        <w:pPr>
                            <w:pStyle w:val=""Heading1""/>
                        </w:pPr>
                            <w:r>
                                <w:t>" + header + @"</w:t>
                            </w:r>
                    </w:p>";
        }

        /// <summary>
        /// Returns xml for standard opening tags of XSLT file
        /// </summary>
        /// <returns></returns>
        public static string GetXSLTOpenTags()
        {
            return Constants.OpenTagXslStyleSheet + "\n"
                    + Constants.OpenTagXslTemplate + "\n"
                    + Constants.OpenTagDocument + "\n"
                    + Constants.OpenTagBody + "\n";
        }

        /// <summary>
        /// Returns xml for standard closing tags of XSLT file
        /// </summary>
        /// <returns></returns>
        public static string GetXSLTCloseTags()
        {
            return Constants.CloseTagBody + "\n"
                    + Constants.CloseTagDocument + "\n"
                    + Constants.CloseTagXslTemplate + "\n"
                    + Constants.CloseTagXslStyleSheet + "\n";
        }
    }
}
