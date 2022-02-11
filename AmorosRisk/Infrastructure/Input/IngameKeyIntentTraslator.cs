using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace AmorosRisk.Infrastructure.Input
{
	public class IngameKeyIntentTraslator : IKeyIntentTraslator
	{
		public virtual List<Intent> Translate(Keys[] keyCodes, char lastCommand, MouseStateExtended mouseState)
		{
			List<Intent> result = new List<Intent>();
			////TODO: Add dictionary for actions, based on game config files

			if (keyCodes == null || keyCodes.Length == 0)
			{
				result.Add(new Intent(null, lastCommand, mouseState, true) { Intention = IntentEnum.MouseMoving });
			}
			else
			{
				for (int i = 0; i < keyCodes.Length; i++)
				{
					var keyCode = keyCodes[i];
					Intent intent = new Intent(keyCodes.ToList(), lastCommand,mouseState, false);
					result.Add(intent);
					switch (keyCode)
					{}
				}
			}

			return result;
		}
	}
}
