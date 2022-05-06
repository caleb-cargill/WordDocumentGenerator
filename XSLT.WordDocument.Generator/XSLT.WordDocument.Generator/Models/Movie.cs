using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Movie")]
	public class Movie
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Released")]
		public int Released { get; set; }
	}
}
