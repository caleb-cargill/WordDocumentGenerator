using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Movies")]
	public class Movies
	{

		[XmlElement(ElementName = "Genre")]
		public List<Genre> Genre { get; set; }
	}
}
