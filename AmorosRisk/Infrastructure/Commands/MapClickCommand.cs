using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Infrastructure.Commands
{
	public class MapClickCommand : ICommand
	{
		public MapClickCommand(string territoryID)
		{
			this.TerritoryId = territoryID;
		}

		public string TerritoryId { get; private set; }
	}
}
