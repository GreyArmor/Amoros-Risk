using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Components.Player
{
	internal class PlayerTag
	{
		public PlayerTag(Guid id)
		{
			Id = id.ToString();
		}

		public PlayerTag()
		{
			Id = Guid.NewGuid().ToString();
		}

		public string Id { get; }
	}
}
