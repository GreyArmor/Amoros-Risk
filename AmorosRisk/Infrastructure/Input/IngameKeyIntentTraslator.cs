using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace AmorosRisk.Infrastructure.Input
{
	public class IngameKeyIntentTraslator : IKeyIntentTraslator
	{
		public virtual List<Intent> Translate(Keys[] keyCodes, char lastCommand)
		{
			List<Intent> result = new List<Intent>();
			////TODO: Add dictionary for actions, based on game config files

			if (keyCodes.Length == 0)
			{
			}
			else
			{
				for (int i = 0; i < keyCodes.Length; i++)
				{
					var keyCode = keyCodes[i];
					Intent intent = new Intent(keyCodes.ToList(), lastCommand);
					result.Add(intent);
					switch (keyCode)
					{}
				}
			}

			return result;
		}
	}
}
