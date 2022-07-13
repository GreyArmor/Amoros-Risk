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
		public HighlightPolygon(Territory territory, WorldMap world, AmorosRiskGame game) {
			TerritoryId = territory.Id;
			IsVisible = false;

			Bitmap bitmap = new Bitmap(territory.Size.X, territory.Size.Y);
			for (int x = 0; x < territory.Size.X; x++)
			{
				for (int y = 0; y < territory.Size.Y; y++)
				{
					if (world.HitboxBuffer[x + territory.Position.X, y + territory.Position.Y] == territory.Id)
					{
						bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 0, 0));
					}
					else
					{
						bitmap.SetPixel(x, y, Color.Transparent);
					}
				}
			}
			bitmap.Save("tttt" + territory.Id + ".png");
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
