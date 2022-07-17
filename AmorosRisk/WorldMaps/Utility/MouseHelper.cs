using AmorosRisk.Components.IngameObjects;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.WorldMaps.Utility
{
	public static class MouseHelper
	{
		private static AmorosRiskGame _game;
		private static SpriteComponent _mapSprite;
		private static WorldMap _world;
		public static void Init(AmorosRiskGame game, SpriteComponent mapSprite, WorldMap world)
		{
			_game = game;
			_mapSprite = mapSprite;
			_world = world;
		}

		public static string GetTerritoryUnderMouse(Vector2 cameraPosition)
		{
			var windowSize = new Vector2(_game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);
			var rawMousePos = MouseExtended.GetState().Position.ToVector2();
			var mousePos = ScrollingMathHelper.GetMouseWorldMapPosititon(rawMousePos, cameraPosition, windowSize, _mapSprite.Size, _mapSprite.SizeAspectRatio);
			return _world.HitboxBuffer[(int)mousePos.X, (int)mousePos.Y];
		}
	}
}
