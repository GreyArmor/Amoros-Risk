 

using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace AmorosRisk.Infrastructure.Input
{
    public enum IntentEnum {
        None,
    }

    public class Intent
    {
        public Intent(List<Keys> pressedKeys, char pressedChar)
        {
            this.PressedKeys = pressedKeys;
            this.PressedChar = pressedChar;
        }
        public List<Keys> PressedKeys { get; set; }
        public char PressedChar { get; set; }
        public IntentEnum Intention { get; set; }

    }
}
