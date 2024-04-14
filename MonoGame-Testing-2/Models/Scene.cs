using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame_Testing_2.Models
{
    internal abstract class Scene
    {
        protected readonly RenderTarget2D target;
        protected readonly GameManager gameManager;

        // All scenes will have this
        protected List<GameObject> gameObjects = new();
        protected List<int> indicesToRemove = new();

        public Scene(GameManager gameManager)
        {
            this.gameManager = gameManager;
            target = Globals.GetNewRenderTarget(); // Runs too early or something?
            Load();
        }

        protected abstract void Load();

        public abstract void Activate();


        public virtual void Update(GameTime gameTime)
        {
            // Update all objects
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime, gameObjects, indicesToRemove);
            }

            // Remove marked objects
            foreach (int index in indicesToRemove)
            {
                gameObjects.RemoveAt(index);
            }
            indicesToRemove.Clear();
        }

        protected virtual void Draw(GameTime gameTime)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(gameTime, Globals.SpriteBatch);
            }
        }

        public virtual RenderTarget2D GetFrame(GameTime gameTime)
        {
            Globals.GraphicsDevice.SetRenderTarget(target);
            Globals.GraphicsDevice.Clear(Color.Black);

            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            Draw(gameTime);

            // Draw UI Here?
            //_ui.Draw();

            Globals.SpriteBatch.End();

            Globals.GraphicsDevice.SetRenderTarget(null);
            return target;

        }


    }
}
