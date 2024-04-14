using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Testing_2
{
    public class Game1 : Game
    {

        private GameManager _gameManager;

        // Temp?
        //GraphicsDeviceManager game1GraphicsDeviceManager;

        public static Texture2D PixelTexture { get; private set; }

        public Game1()
        {

            //game1GraphicsDeviceManager = new GraphicsDeviceManager(this);

            // Initialize the graphics device manager
            GraphicsDeviceManager graphicsDeviceManager = new GraphicsDeviceManager(this);
            Globals.GraphicsDeviceManager = graphicsDeviceManager;


            IsMouseVisible = true;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {

            // This part needs to go a bit after the "Globals.GraphicsDeviceManager = graphicsDeviceManager;"
            Globals.GraphicsDevice = Globals.GraphicsDeviceManager.GraphicsDevice;

            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.GraphicsDeviceManager.PreferredBackBufferWidth = 64 * 15;// Width of window
            Globals.GraphicsDeviceManager.PreferredBackBufferHeight = 64 * 15; // Height of window
            Globals.GraphicsDeviceManager.IsFullScreen = false;
            Globals.GraphicsDeviceManager.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            //graphicsDevice = new GraphicsDeviceManager(this);

            Globals.Content = new ContentManager(Services, "Content");


            // Get graphics device before this (TEMP)
            _gameManager = new GameManager();

            PixelTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            PixelTexture.SetData(new Color[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {

            Globals.Update(gameTime);
            InputManager.Update();
            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _gameManager.Draw(gameTime);

            base.Draw(gameTime);
        }


    }
}
