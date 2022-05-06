using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Genre")]
	public class Genre
	{

		[XmlElement(ElementName = "Movie")]
		public List<Movie> Movie { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
