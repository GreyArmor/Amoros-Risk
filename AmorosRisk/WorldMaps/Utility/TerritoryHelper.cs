using FloodSpill;
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

namespace AmorosRisk.WorldMaps.Utility
{
	public static class TerritoryHelper
	{
		public static List<Territory> DetectTerritories(Color borderColor, Color detectionColor, Bitmap worldMapMask)
		{
			var result = new List<Territory>();

			var floodSpiller = new FloodSpiller();

			var bitmapLock = new LockBitmap(worldMapMask);


			int imageSizeX = bitmapLock.Width;
			int imageSizeY = bitmapLock.Height;
			
			List<Vector2> floodStartingPoints = new List<Vector2>();

			for (int x = 0; x < imageSizeX; x++)
			{
				for (int y = 0; y < imageSizeY; y++)
				{
					if (bitmapLock.GetPixel(x, y) == detectionColor)
					{
						floodStartingPoints.Add(new Vector2(x, y));
					}
				}
			}

			List<Queue<Vector2>> detectedPixels = new List<Queue<Vector2>>();

			foreach (var startingPoint in floodStartingPoints)
			{
				int floodStartX = (int)startingPoint.X;
				int floodStartY = (int)startingPoint.Y;

				Queue<Vector2> pixels = new Queue<Vector2>();
				var floodParameters = new FloodParameters(floodStartX, floodStartY)
				{
					BoundsRestriction = new FloodBounds(imageSizeX, imageSizeY),
					NeighbourhoodType = NeighbourhoodType.Four,
					Qualifier = (x, y) => bitmapLock.GetPixel(x, y).ToArgb() != borderColor.ToArgb(),
					NeighbourProcessor = (x, y, mark) => {pixels.Enqueue(new Vector2(x, y)); },
					ProcessStartAsFirstNeighbour = true

				};

				var markMatrix = new int[imageSizeX, imageSizeY];

				floodSpiller.SpillFlood(floodParameters, markMatrix);

				detectedPixels.Add(pixels);

			}

			var territoryBorders = new List<List<Vector2>>();
			//TODO: clean up convertations, performance/memory intensive
			foreach (var pixels in detectedPixels)
			{
				var pointSwarm = pixels;
				var unsortedBoundaryPixels = new Queue<Vector2>();
				foreach (var point in pointSwarm)
				{
					int x = (int)point.X;
					int y = (int)point.Y;
					Queue<Color> neighborColors = new Queue<Color>();
					neighborColors.Enqueue(bitmapLock.GetPixel(x - 1, y));
					neighborColors.Enqueue(bitmapLock.GetPixel(x + 1, y));
					neighborColors.Enqueue(bitmapLock.GetPixel(x, y - 1));
					neighborColors.Enqueue(bitmapLock.GetPixel(x, y + 1));

					if (neighborColors.Any(color => color.ToArgb() == borderColor.ToArgb()))
					{
						unsortedBoundaryPixels.Enqueue(point);
					}					
				}

				BoundingBox b = BoundingBox.CreateFromPoints(unsortedBoundaryPixels.Select(v => new Vector3(v, 0)));

				int width = (int)(b.Max.X - b.Min.X)+1;
				int height = (int)(b.Max.Y - b.Min.Y)+1;
				var min = new Vector2(b.Min.X, b.Min.Y);

				var fillMatrix = new int[width, height];
				var blockMatrix = new bool[width, height];
				var start = unsortedBoundaryPixels.First() - min;

				foreach (var pixel in unsortedBoundaryPixels)
				{
					var arrayPos = pixel - min;
					blockMatrix[(int)arrayPos.X, (int)arrayPos.Y] = true;
				}

				var floodParameters = new FloodParameters((int)start.X, (int)start.Y)
				{
					BoundsRestriction = new FloodBounds(width, height),
					NeighbourhoodType = NeighbourhoodType.Eight,
					Qualifier = (x, y) => blockMatrix[x,y],
					ProcessStartAsFirstNeighbour = true
				};

				floodSpiller.SpillFlood(floodParameters, fillMatrix);

				string representation = MarkMatrixVisualiser.Visualise(fillMatrix);
				Debug.WriteLine(representation);

				#region debug
				//var bounds = BoundingBox.CreateFromPoints(unsortedBoundaryPixels.Select(v => new Vector3(v, 0)));
				//   var centre = (bounds.Max + bounds.Min) / 2;		

				//var centerOfBoundaryPixels = unsortedBoundaryPixels.Aggregate((a, b) => { return (a + b)/2; }) / unsortedBoundaryPixels.Count;

				//bool isCloseby(Vector2 a, Vector2 b , int threshhold = 1)
				//{
				//	return Math.Abs(a.X - b.X) <= threshhold || Math.Abs(a.Y - b.Y) <= threshhold;
				//}

				////building a chain
				//Queue<Queue<Vector2>> unsortedChains = new Queue<Queue<Vector2>>();
				//while (unsortedBoundaryPixels.Any())
				//{
				//	var chain = new Stack<Vector2>();
				//	chain.Push(unsortedBoundaryPixels.Dequeue());
				//	int loopCounterDetector = 0;
				//	while (unsortedBoundaryPixels.Any())
				//	{
				//		var topChainLink = chain.Peek();
				//		var unsortedPixel = unsortedBoundaryPixels.Dequeue();

				//		if (isCloseby(topChainLink,unsortedPixel))
				//		{
				//			chain.Push(unsortedPixel);
				//			loopCounterDetector = 0;
				//		}
				//		else
				//		{
				//			unsortedBoundaryPixels.Enqueue(unsortedPixel);
				//			loopCounterDetector++;
				//		}
				//		if (loopCounterDetector > unsortedBoundaryPixels.Count)
				//		{
				//			break;
				//		}
				//	}
				//	unsortedChains.Enqueue(new Queue<Vector2>(chain));
				//}


				////now sort the chains

				//var finalChain = unsortedChains.Dequeue();
				//var threshold = 1;
				//var endelessLoopCounter = 0;
				//while (unsortedChains.Any())
				//{
				//	var finalFirst = finalChain.First();
				//	var finalLast = finalChain.Last();

				//	var currentChain = unsortedChains.Dequeue();

				//	var currentFirst = currentChain.First();
				//	var currentLast = currentChain.Last();

				//	if (isCloseby(finalLast, currentFirst, threshold))
				//	{
				//		while (currentChain.Any())
				//		{
				//			finalChain.Enqueue(currentChain.Dequeue());
				//		}
				//		endelessLoopCounter = 0;
				//		threshold = 1;
				//	}
				//	else if (isCloseby(finalFirst, currentLast, threshold))
				//	{
				//		while (finalChain.Any())
				//		{
				//			currentChain.Enqueue(finalChain.Dequeue());
				//		}
				//		finalChain = currentChain;
				//		endelessLoopCounter = 0;
				//		threshold = 1;
				//	}
				//	else if (isCloseby(currentFirst, finalFirst, threshold) || isCloseby(currentLast, finalLast, threshold))
				//	{
				//		finalChain = new Queue<Vector2>(finalChain.Reverse());
				//		while (finalChain.Any())
				//		{
				//			currentChain.Enqueue(finalChain.Dequeue());
				//		}
				//		finalChain = currentChain;
				//		endelessLoopCounter = 0;
				//		threshold = 1;
				//	}
				//	else {
				//		unsortedChains.Enqueue(currentChain);
				//		endelessLoopCounter++;
				//	}
				//	if (endelessLoopCounter > unsortedChains.Count)
				//	{
				//		endelessLoopCounter = 0;
				//		threshold++;
				//	}
				//}


				////foreach (var chain in unsortedChains)
				////{
				////	Debug.WriteLine($@"first {chain.First().X}:{chain.First().Y} last {chain.Last().X}:{chain.Last().Y}");
				////}

				//territoryBorders.Add(finalChain.ToList());
				#endregion

			}
			//bitmapLock.UnlockBits();
			//for (int i = 0; i < territoryBorders[0].Count; i++)
			//{
			//	Vector2 pixel = territoryBorders[0][i];
			//	var coef = (float)(i + 1f) / (territoryBorders[1].Count + 1);
			//	if (coef > 1) { coef = 1; }
			//	worldMapMask.SetPixel((int)pixel.X, (int)pixel.Y, Color.FromArgb(255, (int)(255 * coef), 0, 0) );
			//}
			//worldMapMask.Save("test.png");
			foreach (var territoryBorder in territoryBorders)
			{
				result.Add(new Territory()
				{
					Id = Guid.NewGuid().ToString(),
					Polygon = new Polygon(territoryBorder.ToArray()),
				});

			}

			bitmapLock.UnlockBits();

			return result;
			
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
