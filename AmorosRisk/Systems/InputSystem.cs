using System;
using System.Collections.Generic;
using AmorosRisk;
using AmorosRisk.Components.Input;
using AmorosRisk.Infrastructure;
using AmorosRisk.Infrastructure.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace NamelessRogue.Engine.Systems
{
	public class InputSystem : EntityUpdateSystem
    {

        IKeyIntentTraslator translator;
        private readonly AmorosRiskGame game;
		private readonly SystemContext context;

		public InputSystem(IKeyIntentTraslator translator, AmorosRiskGame game, SystemContext context) : base(Aspect.All(typeof(InputComponent), typeof(InputReceiver)))
        {
            this.translator = translator;
            this.game = game;
            this.context = context;
            game.Window.TextInput += WindowOnTextInput;
            game.Window.KeyDown += Window_KeyDown;
        }

		private void Window_KeyDown(object sender, InputKeyEventArgs e)
		{
            lastState = Keyboard.GetState();
        }

		long currentgmatime = 0;
        private double previousGametimeForMove = 0;

        int inputsTimeLimit = 30;

        private char lastCommand = Char.MinValue;
        private KeyboardState lastState;
		private ComponentMapper<InputComponent> _inputComponentMapper;
		private ComponentMapper<InputReceiver> _inpurReceiverMapper;

		private void WindowOnTextInput(object sender, TextInputEventArgs e)
        {
            lastCommand = e.Character;
            lastState = Keyboard.GetState();
        }

		public override void Update(GameTime gameTime)
		{
            if (game.Context != context) return;

            if (gameTime.ElapsedGameTime.TotalMilliseconds - previousGametimeForMove > inputsTimeLimit)
            {
                previousGametimeForMove = gameTime.ElapsedGameTime.TotalMilliseconds;
                foreach (var entity in this.ActiveEntities)
                {
                    InputComponent inputComponent = _inputComponentMapper.Get(entity);
                    InputReceiver receiver = _inpurReceiverMapper.Get(entity);
                    if (receiver != null && inputComponent != null && lastState != default)
                    {
                        inputComponent.Intents.AddRange(translator.Translate(lastState.GetPressedKeys(), lastCommand));
                        lastCommand = Char.MinValue;
                        lastState = default;
                    }
                }
            }
        }

		public override void Initialize(IComponentMapperService mapperService)
		{
            _inputComponentMapper = mapperService.GetMapper<InputComponent>();
            _inpurReceiverMapper = mapperService.GetMapper<InputReceiver>();
        }
	}
}
