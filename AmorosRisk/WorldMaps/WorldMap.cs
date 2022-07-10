using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AmorosRisk.WorldMaps
{
	[XmlRoot]
	public class WorldMap
	{

		[XmlElement(IsNullable = false)]
		public string MapPathLocal { get; set; }

		[XmlElement(IsNullable = false)]
		public string MapTerritoryMaskPathLocal { get; set; }

		[XmlArray]
		public List<Territory> Territories { get; set; } = new List<Territory>();

		[XmlArray]
		public List<TerritoryConnection> Connections { get; set; } = new List<TerritoryConnection>(); 

	}
}
