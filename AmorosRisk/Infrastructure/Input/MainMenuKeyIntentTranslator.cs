using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace AmorosRisk.Infrastructure.Input
{
	public class MainMenuKeyIntentTranslator : IKeyIntentTraslator
	{
		public List<Intent> Translate(Keys[] keyCodes, char lastCommand, MouseStateExtended state)
		{
			throw new NotImplementedException();
		}
	}
}
