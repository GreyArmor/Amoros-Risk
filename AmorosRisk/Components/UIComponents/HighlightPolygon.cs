using AmorosRisk.WorldMaps;
using AmorosRisk.WorldMaps.Utility;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace AmorosRisk.Components.UIComponents
{
	public class HighlightPolygon
	{
		public HighlightPolygon(Territory territory, AmorosRiskGame game) {
			TerritoryId = territory.Id;
			IsVisible = false;

			var bounds = territory.Polygon.BoundingRectangle;

			Bitmap bitmap = new Bitmap((int)bounds.Width, (int)bounds.Height);


			for (int x = 0; x < bounds.Width; x++)
			{
				for (int y = 0; y < bounds.Height; y++)
				{
					if (territory.Polygon.Contains(x + bounds.X, y + bounds.Y))
					{
						bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 0, 0));
					}
					else
					{
						bitmap.SetPixel(x, y, Color.Transparent);
					}
				}
			}

			using (MemoryStream s = new MemoryStream())
			{
				bitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);
				s.Seek(0, SeekOrigin.Begin);
				PolygonImage = Texture2D.FromStream(game.GraphicsDevice, s);
			}
		}
		public string TerritoryId { get; set; }
		public bool IsVisible { get; set; }

		public Texture2D PolygonImage { get; set; }
	}
}
