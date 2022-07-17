 

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace AmorosRisk.Infrastructure.Input
{
    public enum IntentEnum
    {
        None,
        MouseMoving,
        MouseClick,
    }

    public class Intent
    {
        public Intent(List<Keys> pressedKeys, char pressedChar, MouseStateExtended mouseState, bool isMouseCommand)
        {
            this.PressedKeys = pressedKeys;
            this.PressedChar = pressedChar;
            this.MouseState = mouseState;
            IsMouseCommand = isMouseCommand;
        }
        public List<Keys> PressedKeys { get; set; }
        public char PressedChar { get; set; }
        public IntentEnum Intention { get; set; }

        public MouseStateExtended MouseState { get; set; }
        public bool IsMouseCommand { get; }
    }
}
