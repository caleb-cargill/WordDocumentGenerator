using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Variable")]
	public class Variable
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "VariableDescription")]
		public string VariableDescription { get; set; }
	}
}
