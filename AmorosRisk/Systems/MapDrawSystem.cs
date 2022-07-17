using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Components.UIComponents;
using AmorosRisk.Infrastructure;
using AmorosRisk.WorldMaps;
using AmorosRisk.WorldMaps.Utility;
using FloodSpill;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
			
			var world = _worldMapper.Get(game.MapEntityId);
			var territories = world.Territories;

			foreach (var entityId in ActiveEntities)
			{
				var positio = _positionMapper.Get(entityId);
				var sprite = _spriteMapper.Get(entityId);
				var map = sprite.Texture;
				var mapAspectRatio = sprite.SizeAspectRatio;

				//draw the map
				spriteBatch.Draw(map, new Rectangle((int)(positio.Position.X - sprite.Size.X + 1), (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);
				spriteBatch.Draw(map, new Rectangle((int)-positio.Position.X, (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);
				spriteBatch.Draw(map, new Rectangle((int)(positio.Position.X + sprite.Size.X - 1), (int)positio.Position.Y, (int)sprite.Size.X, (int)sprite.Size.Y), Color.White);

				//scroll mouse position

				var windowSize = new Vector2(game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
				var rawMousePos = MouseExtended.GetState().Position.ToVector2();
				var mousePos = ScrollingMathHelper.GetMouseWorldMapPosititon(rawMousePos, cameraPosition, windowSize, sprite.Size, mapAspectRatio);


				var collection = _highlightPolygonCollectionMapper.Get(entityId);

				//debug mouse draw
				//spriteBatch.Draw(map, new Rectangle((int)mousePos.X, (int)mousePos.Y, 10, 10), Color.Yellow);

				var territoryId = MouseHelper.GetTerritoryUnderMouse(cameraPosition);

				//then draw the highlights
				foreach (var territory in territories)
				{
					if (world.HitboxBuffer[(int)mousePos.X, (int)mousePos.Y] == territory.Id)
					{
						var polygonBounds = new Rectangle(territory.Position.X, territory.Position.Y, territory.Size.X, territory.Size.Y);
						var polygon = collection.TerritoryPolygons[territory.Id].PolygonImage;

						var mask = Color.White * 0.75f;

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
				//Dram the number of troops
				foreach (var territory in territories)
				{
					spriteBatch.DrawString(game.GameFont, territory.NumberOfTroops.ToString(), territory.Center * mapAspectRatio, Color.White, 0, Vector2.Zero, 1.2f, SpriteEffects.None, 1);
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
