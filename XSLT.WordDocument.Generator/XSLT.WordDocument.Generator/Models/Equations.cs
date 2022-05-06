using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Equations")]
	public class Equations
	{

		[XmlElement(ElementName = "Property")]
		public List<Property> Property { get; set; }
	}
}
