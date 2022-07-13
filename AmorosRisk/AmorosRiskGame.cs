using EmptyKeys.UserInterface;
using EmptyKeys.UserInterface.Input;
using EmptyKeys.UserInterface.Media;
using EmptyKeys.UserInterface.Media.Effects;
using EmptyKeys.UserInterface.Media.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EmptyKeys.UserInterface.Generated;
using System;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using AmorosRisk.Infrastructure;
using AmorosRisk.Infrastructure.Input;
using AmorosRisk.Systems;
using AmorosRisk.Components.UIComponents;
using EmptyKeys.UserInterface.Mvvm;
using EmptyKeys.UserInterface.Controls;
using AmorosRisk.ViewModels;
using AmorosRisk.Components.IngameObjects;
using AmorosRisk.Components.Player;
using AmorosRisk.Components.Input;
using System.Drawing;
using AmorosRisk.Factories;
using AmorosRisk.WorldMaps;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Color = System.Drawing.Color;
using AmorosRisk.WorldMaps.Utility;

namespace AmorosRisk
{
	public class AmorosRiskGame : Game
	{
        private readonly Random random = new Random();

        GraphicsDeviceManager graphics;

        private int nativeScreenWidth;
        private int nativeScreenHeight;

        WindowRoot _root;
        RootViewModel _rootViewModel = new RootViewModel();
		private World _world;
        InGameMenu _ingameMenu;
        SpriteBatch spriteBatch;

        public SystemContext Context { get; set; } = SystemContext.MainMenu;
        public Commander Commander { get; set; }

        public WindowRoot UiRoot { get; private set; }
		public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
		public World World { get => _world; private set => _world = value; }

		private MainMenu _mainMenu;

		public AmorosRiskGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreparingDeviceSettings += graphics_PreparingDeviceSettings;
            graphics.DeviceCreated += graphics_DeviceCreated;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            Window.AllowUserResizing = true;
        }   

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if (_root != null)
			{
				Viewport viewport = GraphicsDevice.Viewport;
                _root.Resize(viewport.Width, viewport.Height);
			}
		}

        void graphics_DeviceCreated(object sender, EventArgs e)
        {
            Engine engine = new MonoGameEngine(GraphicsDevice, nativeScreenWidth, nativeScreenHeight);
        }

        private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            nativeScreenWidth = graphics.PreferredBackBufferWidth;
            nativeScreenHeight = graphics.PreferredBackBufferHeight;

            graphics.PreferMultiSampling = true;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.SynchronizeWithVerticalRetrace = true;
            graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = 8;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Context = SystemContext.MainMenu;
            Commander = new Commander();
            _world = new WorldBuilder()
                //ui systems setup
                .AddSystem(new InputSystem(new IngameKeyIntentTraslator(), this, SystemContext.InGame))
                .AddSystem(new InGameIntentSystem(this, SystemContext.InGame))
                .AddSystem(new UiInputSystem(this))

                .AddSystem(new CameraSystem(this, SystemContext.InGame))
                //map draw
                .AddSystem(new MapDrawSystem(this, SystemContext.InGame))
                .AddSystem(new UiDrawSystem(this))


                .Build();

            Viewport viewport = GraphicsDevice.Viewport;


            RelayCommand resizeCommand = new RelayCommand(new Action<object>(OnResize));
            KeyBinding resizeBinding = new KeyBinding(resizeCommand, KeyCode.R, ModifierKeys.Control);

            _root = new WindowRoot(viewport.Width, viewport.Height);


            _root.DataContext = _rootViewModel;
            UiRoot = _root;

            _mainMenu = new EmptyKeys.UserInterface.Generated.MainMenu();
            var viewModel = new MainMenuScreenViewModel(this);
            _mainMenu.DataContext = viewModel;

            _ingameMenu = new EmptyKeys.UserInterface.Generated.InGameMenu();
            var ingameViewModel = new InGameMenuViewModel(this);
            _ingameMenu.DataContext = ingameViewModel;

            _rootViewModel.ContentWindow = _mainMenu;

            _root.Resize(viewport.Width, viewport.Height);

            //create a map
            var mapSprite = new SpriteComponent() { SpritePath = "Content\\Maps\\StandardMap\\World_map_political_ISO.png", Size = new Vector2(viewport.Width * 2, viewport.Height * 2) };
            var mapPostion = new PositionComponent() { Position = new Vector2(0, 0) };
            var mapTag = new MapTag();

            var mapEntity = _world.CreateEntity();
            mapEntity.Attach(mapSprite);
            mapEntity.Attach(mapPostion);
            mapEntity.Attach(mapTag);

            MapEntityId = mapEntity.Id;

            var playerTag = new PlayerTag();
            var playerCameraTag = new CameraTag();
            var playerCameraPositon = new PositionComponent() { Position = new Vector2() };
            var inputComponent = new InputComponent();
            var inputReceiver = new InputReceiver();

            var playerEntity = _world.CreateEntity();
            playerEntity.Attach(playerTag);
            playerEntity.Attach(playerCameraTag);
            playerEntity.Attach(playerCameraPositon);
            playerEntity.Attach(inputComponent);
            playerEntity.Attach(inputReceiver);
            PlayerEntityId = playerEntity.Id;


            var bitmap = new Bitmap("Content\\Maps\\StandardMap\\World_map_political_ISO_MASK.png");
            var detectionColor = Color.FromArgb(255,255,16,240);
            var borderColor = Color.White;
            TerritoryHelper.DetectTerritories(borderColor, detectionColor, bitmap, out var hitboxMap, out var territories);

            var world = new WorldMaps.WorldMap();


            var connections = new List<TerritoryConnection>() {
                new TerritoryConnection() { FirstTerritory = "territory1", SecondTerritory = "territory2", ConnectionType = TerritoryConnectionType.ByLand },
                new TerritoryConnection() { FirstTerritory = "territory1", SecondTerritory = "territory3", ConnectionType = TerritoryConnectionType.ByLand },
                new TerritoryConnection() { FirstTerritory = "territory1", SecondTerritory = "territory4", ConnectionType = TerritoryConnectionType.BySea },
                new TerritoryConnection() { FirstTerritory = "territory2", SecondTerritory = "territory3", ConnectionType = TerritoryConnectionType.ByLand },
                new TerritoryConnection() { FirstTerritory = "territory2", SecondTerritory = "territory4", ConnectionType = TerritoryConnectionType.ByLand },
                new TerritoryConnection() { FirstTerritory = "territory3", SecondTerritory = "territory4", ConnectionType = TerritoryConnectionType.BySea }, };


            world.MapPathLocal = "test.png";
            world.MapTerritoryMaskPathLocal = "testmask.png";
            world.Territories.AddRange(territories);
            world.Connections = connections;
            world.HitboxBuffer = hitboxMap;
            mapEntity.Attach(world);
            mapEntity.Attach(new HighlightPolygonCollection(world, this));

            //XmlSerializer ser = new XmlSerializer(typeof(WorldMap));
            //ser.Serialize(File.OpenWrite("text.xml"), world);




            base.Initialize();
        }
        public int PlayerEntityId { get; private set; }
        public int MapEntityId { get; private set; }
        /// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
        {
            this.IsMouseVisible = true;

            SpriteFont font = Content.Load<SpriteFont>("Segoe_UI_10_Regular");
            FontManager.DefaultFont = Engine.Instance.Renderer.CreateFont(font);
                
            FontManager.Instance.LoadFonts(Content);
            ImageManager.Instance.LoadImages(Content);
            SoundManager.Instance.LoadSounds(Content);
            EffectManager.Instance.LoadEffects(Content);

            RelayCommand command = new RelayCommand(new Action<object>(ExitEvent));

        }

        private void OnResize(object obj)
        {
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
        }

        private void ExitEvent(object parameter)
        {
            Exit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (contextSwitchScheduled)
            {
                contextSwitchScheduled = false;
                Context = contextToChangeTo;
            }

            _world.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.DarkGray);
            _world.Draw(gameTime);
            base.Draw(gameTime);
        }

        SystemContext contextToChangeTo;
        bool contextSwitchScheduled;
	

		internal void ScheduleContextChange(SystemContext context)
		{
            contextSwitchScheduled = true;
            contextToChangeTo = context;

            switch (context)
            {
                case SystemContext.MainMenu:
                    _rootViewModel.ContentWindow = _mainMenu;
                    break;
                case SystemContext.InGame:
                    _rootViewModel.ContentWindow = _ingameMenu;
                    break;
                default:
                    break;
            }

        }
	}
}
