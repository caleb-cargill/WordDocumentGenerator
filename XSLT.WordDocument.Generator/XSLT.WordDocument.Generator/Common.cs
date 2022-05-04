using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSLT.WordDocument.Generator.Enums;

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
    }
}
