using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace AmorosRisk.Infrastructure.Input
{
	public interface IKeyIntentTraslator
	{
		List<Intent> Translate(Keys[] keyCodes, char lastCommand);
	}
}