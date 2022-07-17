using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Components.IngameObjects
{
	public class SpriteComponent
	{
		public string SpritePath { get; set; }
		public Vector2 Size { get; set; }
		public Vector2 SizeAspectRatio { get; set; }
		public Texture2D Texture { get; }
		public SpriteComponent(AmorosRiskGame game,string path, Vector2 size) {
			Texture = Texture2D.FromFile(game.GraphicsDevice, path);
			SizeAspectRatio = new Vector2(size.X / Texture.Width, size.Y / Texture.Height);
			SpritePath = path;
			Size = size;
		}
	}
}
