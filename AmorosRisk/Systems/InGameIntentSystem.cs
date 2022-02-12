using System;
using System.Collections.Generic;
using System.Text;
using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Components.Input;
using AmorosRisk.Components.Player;
using AmorosRisk.Infrastructure;
using AmorosRisk.Infrastructure.Commands;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;


namespace AmorosRisk.Systems
{
	internal class InGameIntentSystem : EntityUpdateSystem
	{
		private AmorosRiskGame game;
		private SystemContext context;
		private ComponentMapper<InputComponent> _inputComponentMapper;
		private ComponentMapper<CameraTag> _cameraTagMapper;
		private ComponentMapper<PositionComponent> _positionMapper;

		public InGameIntentSystem(AmorosRiskGame game, SystemContext context) : base(Aspect.All(typeof(InputComponent), typeof(InputReceiver)))
		{	
			this.game = game;
			this.context = context;
		}
		public override void Initialize(IComponentMapperService mapperService)
		{
			_inputComponentMapper = mapperService.GetMapper<InputComponent>();
			_cameraTagMapper = mapperService.GetMapper<CameraTag>();
			_positionMapper = mapperService.GetMapper<PositionComponent>();
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var entity in ActiveEntities)
			{
				var input = _inputComponentMapper.Get(entity);
				foreach (var intent in input.Intents)
				{
					switch (intent.Intention)
					{
						case Infrastructure.Input.IntentEnum.MouseMoving:

							//todo: move to contants storage file
							const int cameraScrollSpeed = 25;

							Vector2 moveDirection = Vector2.Zero;

							var viewportWidth = game.GraphicsDevice.Viewport.Width;
							var viewportHeight = game.GraphicsDevice.Viewport.Height;

							var tenthOfWidth = viewportWidth / 20;
							var tenthOfHeight = viewportHeight / 20;

							var mousePosition = new Vector2(intent.MouseState.X, intent.MouseState.Y);

							if (mousePosition.X <= tenthOfWidth)
							{
								moveDirection += Vector2.UnitX;
							}
							if (mousePosition.X >= viewportWidth - tenthOfWidth)
							{
								moveDirection += -Vector2.UnitX;
							}
							if (mousePosition.Y <= tenthOfHeight)
							{
								moveDirection += Vector2.UnitY;
							}
							if(mousePosition.Y >= viewportHeight - tenthOfHeight)
							{
								moveDirection += -Vector2.UnitY;
							}
							if (moveDirection != -Vector2.Zero)
							{
								moveDirection.Normalize();
							}

							var playerComeraPostion = _positionMapper.Get(game.PlayerEntityId);


							var newPosition = playerComeraPostion.Position + (moveDirection * cameraScrollSpeed);

							var mapSprite = game.World.GetEntity(game.MapEntityId).Get<SpriteComponent>();


							if (newPosition.Y < -mapSprite.Size.Y + viewportHeight)
							{
								newPosition.Y = -mapSprite.Size.Y + viewportHeight;
							}
							if (newPosition.Y > 0)
							{
								newPosition.Y = 0;
							}


							if (newPosition.X < -mapSprite.Size.X)
							{
								newPosition.X += mapSprite.Size.X;
							}
							if (newPosition.X > mapSprite.Size.X)
							{
								newPosition.X -= mapSprite.Size.X;
							}


							var cameraCommand = new CameraMoveCommand(newPosition);
							game.Commander.EnqueueCommand(cameraCommand);
							break;
						default:
							break;
					}
				}
			}
		}
	}
}
