using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Infrastructure.Commands
{
	internal class CameraMoveCommand : ICommand
	{
		public CameraMoveCommand(Vector2 moveTo)
		{
			MoveTo = moveTo;
		}

		public Vector2 MoveTo { get; }
	}
}
