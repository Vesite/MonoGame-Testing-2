using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    public class Game1 : Game
    {

        private GameManager _gameManager;
        
        public Game1()
        {
            Globals.GraphicsDeviceManager = new GraphicsDeviceManager(this);
            

            IsMouseVisible = true;
            IsFixedTimeStep = false;

        }

        protected override void Initialize()
        {

            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.GraphicsDeviceManager.PreferredBackBufferWidth = 64 * 15;//GraphicsDevice.DisplayMode.Width;  // set this value to the desired width of your window
            Globals.GraphicsDeviceManager.PreferredBackBufferHeight = 64 * 15;//GraphicsDevice.DisplayMode.Height;   // set this value to the desired height of your window
            Globals.GraphicsDeviceManager.IsFullScreen = false;
            Globals.GraphicsDeviceManager.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            Globals.Content = new ContentManager(Services, "Content");

            _gameManager = new GameManager();

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
            
            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _gameManager.Draw(gameTime);

            Globals.SpriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
