using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Systems
{
	public class MapDrawSystem : EntityDrawSystem
	{
		private ComponentMapper<PositionComponent> _positionMapper;
		private ComponentMapper<SpriteComponent> _spriteMapper;
		private AmorosRiskGame game;
		private SystemContext context;

		public MapDrawSystem(AmorosRiskGame game, SystemContext context) : base(Aspect.All(typeof(MapTag), typeof(PositionComponent), typeof(SpriteComponent))){
			this.game = game;
			this.context = context;
		}
		public override void Draw(GameTime gameTime)
		{
			if (game.Context != context) return;

			foreach (var entityId in ActiveEntities)
			{
				var positio = _positionMapper.Get(entityId);
				var sprite = _spriteMapper.Get(entityId);
				var map = game.Content.Load<Texture2D>("Images\\"+sprite.SpriteName);

				var spriteBatch = game.SpriteBatch;


				spriteBatch.Begin();
				spriteBatch.Draw(map, new Rectangle((int)positio.Position.X, (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);
				spriteBatch.End();

			}
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_positionMapper = mapperService.GetMapper<PositionComponent>();
			_spriteMapper = mapperService.GetMapper<SpriteComponent>();
		}
	}
}
