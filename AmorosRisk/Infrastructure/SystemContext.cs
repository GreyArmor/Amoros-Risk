using MonoGame.Extended.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Infrastructure
{
	class SystemContext
	{
		public List<ISystem> OrderedSystems { get; set; } = new List<ISystem>();
		public SystemContext(params ISystem[] systems)
		{
			OrderedSystems = new List<ISystem>(systems.Length);
			OrderedSystems.AddRange(systems);
		}
	}
}
