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
	public class UiInputSystem : UpdateSystem
	{
		private readonly AmorosRiskGame game;
		private ComponentMapper<UiScreenComponent> _UiScreenComponentMapper;

		public UiInputSystem(AmorosRiskGame game)
		{
			this.game = game;
		}
		public override void Update(GameTime gameTime)
		{
			game.UiRoot.UpdateInput(gameTime.ElapsedGameTime.TotalMilliseconds);
			game.UiRoot.UpdateLayout(gameTime.ElapsedGameTime.TotalMilliseconds);
		}
	}
}
