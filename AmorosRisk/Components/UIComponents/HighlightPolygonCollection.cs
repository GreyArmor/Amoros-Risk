using AmorosRisk.WorldMaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Components.UIComponents
{
	public class HighlightPolygonCollection
	{
		public HighlightPolygonCollection(ICollection<Territory> territories, AmorosRiskGame game)
		{
			TerritoryPolygons = new Dictionary<string, HighlightPolygon>();
			foreach (var territory in territories)
			{
				TerritoryPolygons.Add(territory.Id, new HighlightPolygon(territory, game));
			}
		}
		public Dictionary<string,HighlightPolygon> TerritoryPolygons { get; set; }
	}
}
