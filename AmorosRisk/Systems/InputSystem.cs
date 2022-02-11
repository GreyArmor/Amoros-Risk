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
using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;

namespace AmorosRisk.Systems
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
			_mouseListener = new MouseListener();
			_mouseListener.MouseClicked += MouseListener_MouseClicked;
			_mouseListener.MouseDoubleClicked += MouseListener_MouseClicked;
			_mouseListener.MouseDown += MouseListener_MouseClicked;
			_mouseListener.MouseUp += MouseListener_MouseClicked;
		}

		private void MouseListener_MouseClicked(object sender, MouseEventArgs e)
		{
			lastMouseState = MouseExtended.GetState();
		}

		private void Window_KeyDown(object sender, InputKeyEventArgs e)
		{
			lastState = Keyboard.GetState();
			lastMouseState = MouseExtended.GetState();
		}

		long currentgmatime = 0;
		private double previousGametimeForMove = 0;

		int inputsTimeLimit = 30;

		private char lastCommand = char.MinValue;
		private KeyboardState lastState;
		private MouseStateExtended lastMouseState;
		private ComponentMapper<InputComponent> _inputComponentMapper;
		private ComponentMapper<InputReceiver> _inpurReceiverMapper;
		private MouseListener _mouseListener;

		private void WindowOnTextInput(object sender, TextInputEventArgs e)
		{
			lastCommand = e.Character;
			lastState = Keyboard.GetState();
			lastMouseState = MouseExtended.GetState();
		}

		public override void Update(GameTime gameTime)
		{
			if (game.Context != context) return;

			if (gameTime.TotalGameTime.TotalMilliseconds - previousGametimeForMove > inputsTimeLimit)
			{
				previousGametimeForMove = gameTime.TotalGameTime.TotalMilliseconds;
				foreach (var entity in ActiveEntities)
				{
					InputComponent inputComponent = _inputComponentMapper.Get(entity);
					InputReceiver receiver = _inpurReceiverMapper.Get(entity);
					if (receiver != null && inputComponent != null && lastState != default)
					{
						inputComponent.Intents.AddRange(translator.Translate(lastState.GetPressedKeys(), lastCommand, lastMouseState));
						lastCommand = char.MinValue;
						lastState = default;
						lastMouseState = default;
					}
					else
					{
						inputComponent.Intents.AddRange(translator.Translate(null, default, MouseExtended.GetState()));
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
