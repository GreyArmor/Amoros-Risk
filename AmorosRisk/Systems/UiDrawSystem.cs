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
	public class UiDrawSystem : DrawSystem
	{
		private ComponentMapper<UiScreenComponent> _UiScreenComponentMapper;
		private AmorosRiskGame game;

		public UiDrawSystem(AmorosRiskGame game)
		{
			this.game = game;
		}
		public override void Draw(GameTime gameTime)
		{
			game.UiRoot.Draw(gameTime.ElapsedGameTime.TotalMilliseconds);
		}

	}
}
