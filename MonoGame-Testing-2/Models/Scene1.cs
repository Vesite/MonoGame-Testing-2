using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGame_Testing_2.Models
{
    internal class Scene1 : Scene
    {
        private Texture2D crystalBall;

        public Scene1(GameManager gameManager) : base(gameManager)
        {

        }

        protected override void Load()
        {
            crystalBall = Globals.Content.Load<Texture2D>("crystal_ball");
        }


        public override void Activate()
        {
            gameObjects.Clear();

            float radius = 30f;
            Vector2 direction = Globals.ConvertDirectionRadiansToVector2((float)(Globals.RandomGenerator.NextDouble() * (Math.PI * 2)));
            float speed = 800f;
            gameObjects.Add(new Ball1(new() { crystalBall }, new(300, 300), 1, radius, direction, speed));
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
