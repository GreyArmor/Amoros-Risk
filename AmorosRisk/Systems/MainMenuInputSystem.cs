using AmorosRisk.Components.UIComponents;
using AmorosRisk.Infrastructure;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Systems
{
	public class MainMenuInputSystem : EntityUpdateSystem
	{
		private readonly AmorosRiskGame game;
		private readonly SystemContext context;
		private ComponentMapper<UiScreenComponent> _UiScreenComponentMapper;

		public MainMenuInputSystem(AmorosRiskGame game, Infrastructure.SystemContext context) : base(Aspect.All(typeof(UiScreenComponent), typeof(MainMenuUi)))
		{
			this.game = game;
			this.context = context;
		}
		public override void Update(GameTime gameTime)
		{
			foreach (var entity in ActiveEntities)
			{
				var screen = _UiScreenComponentMapper.Get(entity);
				screen.WindowRoot.UpdateInput(gameTime.ElapsedGameTime.TotalMilliseconds);
				screen.WindowRoot.UpdateLayout(gameTime.ElapsedGameTime.TotalMilliseconds);
			}
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_UiScreenComponentMapper = mapperService.GetMapper<UiScreenComponent>();
		}
	}
}
