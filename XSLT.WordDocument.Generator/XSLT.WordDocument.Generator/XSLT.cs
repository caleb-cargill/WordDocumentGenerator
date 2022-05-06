using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSLT.WordDocument.Generator
{
    public static class XSLT
    {
        /// <summary>
        /// Returns xml for standard opening tags of XSLT file
        /// </summary>
        /// <returns></returns>
        public static string GetOpenTags()
         => Constants.OpenTagXslStyleSheet + "\n"
                    + Constants.OpenTagXslTemplate + "\n"
                    + Constants.OpenTagDocument + "\n"
                    + Constants.OpenTagBody + "\n";

        /// <summary>
        /// Returns xml for standard closing tags of XSLT file
        /// </summary>
        /// <returns></returns>
        public static string GetCloseTags()
         => Constants.CloseTagBody + "\n"
                    + Constants.CloseTagDocument + "\n"
                    + Constants.CloseTagXslTemplate + "\n"
                    + Constants.CloseTagXslStyleSheet + "\n";

        public static string GetHeader(string header)
            => @"<!-- " + header + @" Header -->
                <w:p w14:paraId=""7039BE8E"" w14:textId=""1D8D4F4A"" w:rsidR=""005E0B98"" w:rsidRDefault=""007A5E62"" w:rsidP=""007A5E62"">
                    <w:pPr>
                        <w:pStyle w:val=""Heading1""/>
                    </w:pPr>
                        <w:r>
                            <w:t>" + header + @"</w:t>
                        </w:r>
                </w:p>";

        public static string GetHeading2Tags(string select)
         =>  @"<w:p w14:paraId=""512BD978"" 
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

        public static string GetForeach(string path)
            => @"<xsl:for-each select=""" + path + @""">";

        public static string GetForeachClose()
            => "</xsl:for-each>";

        public static string GetSelect(string path)
            => @"<xsl:value-of select=""" + path +  @"""/>";

        public static string GetOpenText(bool preserveSpace)
            => @"<w:t" + (preserveSpace ? @" xml:space=""preserve"">" : ">");

        public static string GetCloseText()
            => "</w:t>";

        public static string GetOpenWords(bool bold)
            => @"<w:r>" + (bold ? @"<w:rPr><w:b/></w:rPr>" : string.Empty);

        public static string GetCloseWords()
            => @"</w:r>";

        public static string GetListStyle()
            => @"<w:pPr>
                    <w:pStyle w:val=""ListParagraph""/>
                    <w:numPr>
                        <w:ilvl w:val=""0""/>
                        <w:numId w:val=""2""/>
                    </w:numPr>
                </w:pPr>";

        public static string GetOpenParagraph()
            => @"<w:p w14:paraId=""3CCAD2A4"" w14:textId=""7F46B842"" w:rsidR=""004F3118"" w:rsidRPr=""004F3118"" w:rsidRDefault=""004F3118"" w:rsidP=""004F3118"">";

        public static string GetCloseParagraph()
            => @"</w:p>";
    }
}

