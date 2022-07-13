using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.WorldMaps.Utility
{
	public static class ScrollingMathHelper
	{


		public static Vector2 GetMouseWorldMapPosititon(Vector2 rawMousePos, Vector2 cameraPosition, Vector2 windowSize, Vector2 worldMapSize, Vector2 mapAspectRation)
		{
			rawMousePos = ScrollingMathHelper.TrimVector2(rawMousePos, windowSize);

			var mousePos = rawMousePos - cameraPosition;

			mousePos = ScrollingMathHelper.ScrollVector2(mousePos, worldMapSize, true, false);

			mousePos /= mapAspectRation;

			return mousePos;
		}
		public static Vector2 ScrollVector2(Vector2 v, Vector2 allowedSize, bool byX = true, bool byY = true)
		{
			if (byX)
			{
				if (v.X > allowedSize.X)
				{
					v.X -= allowedSize.X - 1;
				}
				else if (v.X < 0)
				{
					v.X += allowedSize.X - 1;
				}
			}

			if (byY)
			{
				if (v.Y > allowedSize.Y)
				{
					v.Y -= allowedSize.Y - 1;
				}
				else if (v.Y < 0)
				{
					v.Y += allowedSize.X - 1;
				}
			}
			return v;
		}

		public static Vector2 TrimVector2(Vector2 v, Vector2 allowedSize, bool byX = true, bool byY = true)
		{
			if (byX)
			{
				if (v.X > allowedSize.X - 1)
				{
					v.X = allowedSize.X - 1;
				}
				else if (v.X < 0)
				{
					v.X = 0;
				}
			}

			if (byY)
			{
				if (v.Y > allowedSize.Y - 1)
				{
					v.Y = allowedSize.Y - 1;
				}
				else if (v.Y < 0)
				{
					v.Y = 0;
				}
			}
			return v;
		}

	}
}
