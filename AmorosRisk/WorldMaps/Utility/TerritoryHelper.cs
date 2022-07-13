using FloodSpill;
using FloodSpill.Queues;
using FloodSpill.Utilities;
using MIConvexHull;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using ColorXNA = Microsoft.Xna.Framework.Color;


namespace AmorosRisk.WorldMaps.Utility
{

	public struct MarkedPosition{
		public Position position;
		public int weight;
	}
	public static class TerritoryHelper
	{
		public static void DetectTerritories(Color borderColor, Color detectionColor, Bitmap worldMapMask, out string[,] hitboxMap, out List<Territory> territories)
		{
			territories = new List<Territory>();

			var floodSpiller = new FloodSpiller();
			var bitmapLock = new LockBitmap(worldMapMask);


			int imageSizeX = bitmapLock.Width;
			int imageSizeY = bitmapLock.Height;
			
			List<Position> floodStartingPoints = new List<Position>();

			for (int x = 0; x < imageSizeX; x++)
			{
				for (int y = 0; y < imageSizeY; y++)
				{
					if (bitmapLock.GetPixel(x, y) == detectionColor)
					{
						floodStartingPoints.Add(new Position(x, y));
					}
				}
			}

			List<Queue<Position>> detectedPixels = new List<Queue<Position>>();

			foreach (var startingPoint in floodStartingPoints)
			{
				int floodStartX = (int)startingPoint.X;
				int floodStartY = (int)startingPoint.Y;

				Queue<Position> pixels = new Queue<Position>();
				var floodParameters = new FloodParameters(floodStartX, floodStartY)
				{
					BoundsRestriction = new FloodBounds(imageSizeX, imageSizeY),
					NeighbourhoodType = NeighbourhoodType.Four,
					Qualifier = (x, y) => bitmapLock.GetPixel(x, y).ToArgb() != borderColor.ToArgb(),
					NeighbourProcessor = (x, y, mark) => {pixels.Enqueue(new Position(x, y)); bitmapLock.SetPixel(x, y, borderColor); },
					ProcessStartAsFirstNeighbour = true

				};

				var markMatrix = new int[imageSizeX, imageSizeY];

				floodSpiller.SpillFlood(floodParameters, markMatrix);
				if (pixels.Any())
				{
					detectedPixels.Add(pixels);
				}

			}

			hitboxMap = new string[imageSizeX, imageSizeY];
			//var random = new Random();

			bitmapLock.UnlockBits();
			foreach (var detected in detectedPixels)
			{
				//var c = Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
				var id = Guid.NewGuid().ToString();
				var b = BoundingBox.CreateFromPoints(detected.Select(p => new Vector3(p.X, p.Y, 0)));
				var terWidth = b.Max.X - b.Min.X;
				var terHeight = b.Max.Y - b.Min.Y;
				territories.Add(new Territory()
				{
					Id = id,
					Position = new Position((int)b.Min.X, (int)b.Min.Y),
					Size = new Position((int)terWidth, (int)terHeight)
				});

				foreach (var pixel in detected)
				{
					hitboxMap[pixel.X, pixel.Y] = id;
					//worldMapMask.SetPixel(pixel.X, pixel.Y,c);
				}
			}
		//	worldMapMask.Save("test.png");
		}


		public class Vector2ClorwiseComparer : IComparer<Vector2>
		{
			Vector2 _center;
			public Vector2ClorwiseComparer(Vector2 center)
			{
				this._center = center;
			}
			public int Compare([AllowNull] Vector2 x, [AllowNull] Vector2 y)
			{
				return pointAisLeftOfB(x, y,_center)? 1 : -1;
			}

			bool pointAisLeftOfB(Vector2 a, Vector2 b, Vector2 center)
			{
				if (a.X - center.X >= 0 && b.X - center.X < 0)
					return true;
				if (a.X - center.X < 0 && b.X - center.X >= 0)
					return false;
				if (a.X - center.X == 0 && b.X - center.X == 0)
				{
					if (a.Y - center.Y >= 0 || b.Y - center.Y >= 0)
						return a.Y > b.Y;
					return b.Y > a.Y;
				}

				// compute the cross product of vectors (center -> a) X (center -> b)
				int det = (int)((a.X - center.X) * (b.Y - center.Y) - (b.X - center.X) * (a.Y - center.Y));
				if (det < 0 )
					return true;
				if (det > 0)
					return false;

				// points a and b are on the same line from the center
				// check which point is closer to the center
				int d1 = (int)((a.X - center.X) * (a.X - center.X) + (a.Y - center.Y) * (a.Y - center.Y));
				int d2 = (int)((b.X - center.X) * (b.X - center.X) + (b.Y - center.Y) * (b.Y - center.Y));
				return d1 > d2;
			}

		}

	}
}
