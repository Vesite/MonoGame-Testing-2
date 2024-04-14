using Microsoft.Xna.Framework;

namespace MonoGame_Testing_2.Models
{
    internal class SceneMenu : Scene
    {

        public SceneMenu(GameManager gameManager) : base(gameManager)
        {

        }

        protected override void Load()
        {

        }


        public override void Activate()
        {
            gameObjects.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
