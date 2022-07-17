using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Infrastructure;
using AmorosRisk.Infrastructure.Commands;
using AmorosRisk.WorldMaps;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmorosRisk.Systems
{
	public class MapClickSystem : EntityProcessingSystem
	{
		private AmorosRiskGame game;
		private SystemContext context;
		private ComponentMapper<WorldMap> _worldMapper;

		public MapClickSystem(AmorosRiskGame game, SystemContext context) : base(Aspect.All(typeof(MapTag)))
		{
			this.game = game;
			this.context = context;
		}
		public override void Initialize(IComponentMapperService mapperService)
		{
			_worldMapper = mapperService.GetMapper<WorldMap>();
		}

		public override void Process(GameTime gameTime, int entityId)
		{
			if (game.Context != context) return;

			var world = _worldMapper.Get(game.MapEntityId);

			while(game.Commander.DequeueCommand<MapClickCommand>(out MapClickCommand clickCommand))
			{
				world.Territories.First(t => t.Id == clickCommand.TerritoryId).NumberOfTroops++;
			}
		}




	}
}
