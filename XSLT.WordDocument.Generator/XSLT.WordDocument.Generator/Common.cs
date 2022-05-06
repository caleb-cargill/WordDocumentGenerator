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
                sw.WriteLine(GetXSLTOpenTags());

                // content
                sw.WriteLine(GetXSLTContent(name));

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

            content += GetXSLTHeader("Movies");
            content += @"<xsl:for-each select=""Movies/Genre"">" + "\n";

            content += GetXSLTHeading2Tags(select: nameof(Genre.Name).ToLower());

            content += @"<xsl:for-each select=""Movie"">" + "\n";

            content += @"<w:p w14:paraId=""3CCAD2A4"" w14:textId=""7F46B842"" w:rsidR=""004F3118"" w:rsidRPr=""004F3118"" w:rsidRDefault=""004F3118"" w:rsidP=""004F3118"">
                          <w:pPr>
                            <w:pStyle w:val=""ListParagraph""/>
                            <w:numPr>
                              <w:ilvl w:val=""0""/>
                              <w:numId w:val=""2""/>
                            </w:numPr>
                          </w:pPr>
                          <w:r w:rsidRPr=""00BF350E"">
                            <w:rPr>
                              <w:b/>
                            </w:rPr>
                            <w:t>
                              <xsl:value-of select=""Name""/>
                            </w:t>
                          </w:r>
                          <w:r w:rsidR=""00C46B60"">
                            <w:t xml:space=""preserve""> (<xsl:value-of select=""Released""/>)</w:t>
                          </w:r>
                        </w:p>" + "\n";


            content += @"</xsl:for-each>";
            content += @"</xsl:for-each>";

            return content;
        }

        public static string GetXSLTHeading2Tags(string select)
        {
            return @"<w:p w14:paraId=""512BD978"" 
                            w14:textId=""2B823227"" 
                            w:rsidR=""004F3118"" 
                            w:rsidRDefault=""004F3118"" 
                            w:rsidP=""004F3118"">
                        <w:pPr>
                            <w:pStyle w:val=""Heading2""/>
                        </w:pPr>
                        <w:r w:rsidRPr=""00BF350E"">
                            <w:t>                                
                                <xsl:value-of select=""@" + select + @"""/>
                            </w:t>
                        </w:r>
                    </w:p>" + "\n";
        }        
    }
}
