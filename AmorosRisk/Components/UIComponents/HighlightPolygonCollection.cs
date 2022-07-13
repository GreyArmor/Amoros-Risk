using AmorosRisk.WorldMaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Components.UIComponents
{
	public class HighlightPolygonCollection
	{
		public HighlightPolygonCollection(WorldMap world, AmorosRiskGame game)
		{
			TerritoryPolygons = new Dictionary<string, HighlightPolygon>();
			foreach (var territory in world.Territories)
			{
				TerritoryPolygons.Add(territory.Id, new HighlightPolygon(territory, world, game));
			}
		}
		public Dictionary<string,HighlightPolygon> TerritoryPolygons { get; set; }
	}
}
