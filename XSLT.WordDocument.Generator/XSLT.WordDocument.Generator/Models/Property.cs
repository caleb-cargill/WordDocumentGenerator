using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Property")]
	public class Property
	{

		[XmlElement(ElementName = "Variables")]
		public Variables Variables { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }

		[XmlAttribute(AttributeName = "equation")]
		public string Equation { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
