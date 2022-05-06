using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSLT.WordDocument.Generator.Models
{
	[XmlRoot(ElementName = "Variables")]
	public class Variables
	{

		[XmlElement(ElementName = "Variable")]
		public List<Variable> Variable { get; set; }
	}
}
