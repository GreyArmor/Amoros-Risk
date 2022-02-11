using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using SharpDX;

namespace AmorosRisk.Infrastructure.Input
{
	public interface IKeyIntentTraslator
	{
		List<Intent> Translate(Keys[] keyCodes, char lastCommand, MouseStateExtended state);
	}
}