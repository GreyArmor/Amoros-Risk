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

namespace AmorosRisk
{
	public class AmorosRiskGame : Game
	{
        private readonly Random random = new Random();

        GraphicsDeviceManager graphics;

        private int nativeScreenWidth;
        private int nativeScreenHeight;
        private RenderTarget2D renderTarget;

        private EmptyKeys.UserInterface.Generated.WindowRoot basicUI;
        private BasicUiRootViewModel viewModel;

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
          //  Window.AllowUserResizing = true;
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if (basicUI != null)
            {
                Viewport viewPort = GraphicsDevice.Viewport;
                basicUI.Resize(viewPort.Width, viewPort.Height);
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.IsMouseVisible = true;

            SpriteFont font = Content.Load<SpriteFont>("Segoe_UI_10_Regular");
            FontManager.DefaultFont = Engine.Instance.Renderer.CreateFont(font);
            Viewport viewport = GraphicsDevice.Viewport;
            basicUI = new EmptyKeys.UserInterface.Generated.WindowRoot(viewport.Width, viewport.Height);
            viewModel = new BasicUiRootViewModel();
            basicUI.DataContext = viewModel;

            FontManager.Instance.LoadFonts(Content);
            ImageManager.Instance.LoadImages(Content);
            SoundManager.Instance.LoadSounds(Content);
            EffectManager.Instance.LoadEffects(Content);

            RelayCommand command = new RelayCommand(new Action<object>(ExitEvent));

            RelayCommand resizeCommand = new RelayCommand(new Action<object>(OnResize));
            KeyBinding resizeBinding = new KeyBinding(resizeCommand, KeyCode.R, ModifierKeys.Control);
            basicUI.InputBindings.Add(resizeBinding);

            renderTarget = new RenderTarget2D(GraphicsDevice,
                100,
                100,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24Stencil8);

          //  viewModel.RenderTargetSource = new BitmapImage();
            var texture = Engine.Instance.Renderer.CreateTexture(renderTarget);
          //  viewModel.RenderTargetSource.Texture = texture;
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
           // debug.Update();
            basicUI.UpdateInput(gameTime.ElapsedGameTime.TotalMilliseconds);

           // viewModel.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            basicUI.UpdateLayout(gameTime.ElapsedGameTime.TotalMilliseconds);

            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.SetRenderTarget(renderTarget);
            //Color color = new Color();
            //color.A = 255;
            //color.R = (byte)random.Next(0, 255);
            //color.G = (byte)random.Next(0, 255);
            //color.B = (byte)random.Next(0, 255);
            //GraphicsDevice.Clear(color);
            //GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            basicUI.Draw(gameTime.ElapsedGameTime.TotalMilliseconds);
           // debug.Draw();
            base.Draw(gameTime);
        }
    }
}
