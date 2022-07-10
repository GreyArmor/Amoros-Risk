﻿using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Components.UIComponents;
using AmorosRisk.Infrastructure;
using AmorosRisk.WorldMaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Systems
{
	public class MapDrawSystem : EntityDrawSystem
	{
		private ComponentMapper<PositionComponent> _positionMapper;
		private ComponentMapper<SpriteComponent> _spriteMapper;
		private ComponentMapper<WorldMap> _worldMapper;
		private ComponentMapper<HighlightPolygonCollection> _highlightPolygonCollectionMapper;
		private AmorosRiskGame game;
		private SystemContext context;
		private Texture2D map;
		private Vector2 mapAspectRatio;
		private Vector2 mapAspectRatioInverted;

		public MapDrawSystem(AmorosRiskGame game, SystemContext context) : base(Aspect.All(typeof(MapTag), typeof(PositionComponent), typeof(SpriteComponent))){
			this.game = game;
			this.context = context;
		}
		public override void Draw(GameTime gameTime)
		{
			if (game.Context != context) return;
			var spriteBatch = game.SpriteBatch;

			var cameraPosition = _positionMapper.Get(game.PlayerEntityId).Position;

			spriteBatch.Begin(transformMatrix:Matrix.CreateTranslation(cameraPosition.X,cameraPosition.Y,0));
			var territories = _worldMapper.Get(game.MapEntityId).Territories;
			foreach (var entityId in ActiveEntities)
			{
				var positio = _positionMapper.Get(entityId);
				var sprite = _spriteMapper.Get(entityId);
				if (map == null)
				{
					//load only once
					map = Texture2D.FromFile(game.GraphicsDevice, sprite.SpritePath);
					mapAspectRatio = new Vector2(sprite.Size.X / map.Width, sprite.Size.Y / map.Height);
					mapAspectRatioInverted = new Vector2(map.Width / sprite.Size.X,map.Height / sprite.Size.Y);
				}
				//draw the map
				spriteBatch.Draw(map, new Rectangle((int)(positio.Position.X - sprite.Size.X+1), (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);
				spriteBatch.Draw(map, new Rectangle((int)-positio.Position.X, (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);
				spriteBatch.Draw(map, new Rectangle((int)(positio.Position.X + sprite.Size.X-1), (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);

				//then draw the highlights
				var mousePos = MouseExtended.GetState().Position.ToVector2() / mapAspectRatio;
				var collection = _highlightPolygonCollectionMapper.Get(entityId);


				spriteBatch.Draw(map, new Rectangle((int)mousePos.X, (int)mousePos.Y, 10, 10), Color.Yellow);

				foreach (var territory in territories)
				{
					if (territory.Polygon.Contains(mousePos))
					{
						var polygonBounds = territory.Polygon.BoundingRectangle;
						var polygon = collection.TerritoryPolygons[territory.Id].PolygonImage;

						var mask = Color.White;

						spriteBatch.Draw(polygon,
							new Rectangle(
							(int)(polygonBounds.X * mapAspectRatio.X - sprite.Size.X + 1),
							(int)(polygonBounds.Y * mapAspectRatio.Y),
							(int)(polygonBounds.Width * mapAspectRatio.X),
							(int)(polygonBounds.Height * mapAspectRatio.Y)
							),
							mask);

						spriteBatch.Draw(polygon,
							new Rectangle(
							(int)(polygonBounds.X * mapAspectRatio.X), 
							(int)(polygonBounds.Y * mapAspectRatio.Y), 
							(int)(polygonBounds.Width * mapAspectRatio.X), 
							(int)(polygonBounds.Height * mapAspectRatio.Y)
							),
							mask);

						spriteBatch.Draw(polygon,
							new Rectangle(
							(int)(polygonBounds.X * mapAspectRatio.X + sprite.Size.X - 1),
							(int)(polygonBounds.Y * mapAspectRatio.Y),
							(int)(polygonBounds.Width * mapAspectRatio.X),
							(int)(polygonBounds.Height * mapAspectRatio.Y)
							),
							mask);
						break;
					}
				}

			}

			spriteBatch.End();
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_positionMapper = mapperService.GetMapper<PositionComponent>();
			_spriteMapper = mapperService.GetMapper<SpriteComponent>();
			_worldMapper = mapperService.GetMapper<WorldMap>();
			_highlightPolygonCollectionMapper = mapperService.GetMapper<HighlightPolygonCollection>();
		}
	}
}
