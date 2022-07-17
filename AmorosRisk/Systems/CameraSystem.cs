using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Components.Player;
using AmorosRisk.Infrastructure;
using AmorosRisk.Infrastructure.Commands;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Systems
{
	class CameraSystem : EntityUpdateSystem
	{
		private readonly AmorosRiskGame game;
		private readonly SystemContext context;
		private ComponentMapper<PositionComponent> _positionMapper;

		public CameraSystem(AmorosRiskGame game, SystemContext contex):base(Aspect.All(typeof(CameraTag), typeof(PositionComponent)))
		{
			this.game = game;
			this.context = contex;
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_positionMapper = mapperService.GetMapper<PositionComponent>();
		}

		public override void Update(GameTime gameTime)
		{
			if (game.Context != context) return;

			while (game.Commander.DequeueCommand<CameraMoveCommand>(out CameraMoveCommand command))
			{
				foreach (var entity in ActiveEntities)
				{
					var cameraPosition = _positionMapper.Get(entity);
					cameraPosition.Position = command.MoveTo;
					_positionMapper.Put(entity, cameraPosition);
				}
			}			
		}
	}
}
