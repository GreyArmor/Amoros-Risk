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
	public class MainMenuUiDrawSystem : EntityDrawSystem
	{
		private ComponentMapper<UiScreenComponent> _UiScreenComponentMapper;
		private SystemContext context;
		private AmorosRiskGame game;

		public MainMenuUiDrawSystem(AmorosRiskGame game, Infrastructure.SystemContext context) : base(Aspect.All(typeof(UiScreenComponent),typeof(MainMenuUi)))
		{
			this.context = context;
			this.game = game;
		}
		public override void Draw(GameTime gameTime)
		{
			if (context != game.Context) return;

			foreach (var entity in ActiveEntities)
			{
				UiScreenComponent uiScreen = _UiScreenComponentMapper.Get(entity);

				uiScreen.WindowRoot.Draw(gameTime.ElapsedGameTime.TotalMilliseconds);
			}
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_UiScreenComponentMapper = mapperService.GetMapper<UiScreenComponent>();
		}
	}
}
