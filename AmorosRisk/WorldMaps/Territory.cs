using FloodSpill;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AmorosRisk.WorldMaps
{
	public enum TerritoryConnectionType
	{
		ByLand,
		BySea,
	}
	public class TerritoryConnection
	{
		[XmlAttribute]
		public string FirstTerritory { get; set; }

		[XmlAttribute]
		public string SecondTerritory { get; set; }

		[XmlAttribute]
		public TerritoryConnectionType ConnectionType { get; set; }


	}

	public class Territory
	{
		[XmlElement(IsNullable = false)]
		public String Id { get; set; }
		[XmlIgnore]
		public Guid OwnerPlayerId { get; set; }
		[XmlIgnore]
		public int NumberOfTroops { get; set; } = 0;

		[XmlIgnore]
		public Position Position { get; set; }

		[XmlIgnore]
		public Position Size { get; set; }
		[XmlIgnore]
		public Vector2 Center { get; set; }



	}
}
