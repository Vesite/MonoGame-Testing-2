using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    internal class Board : GameObject
    {

        private float speed;

        public Board(List<Texture2D> textures, Vector2 position, float scale, float speed) : base(textures, position, scale)
        {
            this.speed = speed;

        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects, List<int> indicesToRemove)
        {

            if (InputManager.KeyDown(Keys.Left))
            {
                Position = new(Position.X - speed * Globals.Time, Position.Y);
            }
            if (InputManager.KeyDown(Keys.Right))
            {
                Position = new(Position.X + speed * Globals.Time, Position.Y);
            }
            if (InputManager.KeyDown(Keys.Down))
            {
                Position = new(Position.X, Position.Y + speed * Globals.Time);
            }
            if (InputManager.KeyDown(Keys.Up))
            {
                Position = new(Position.X, Position.Y - speed * Globals.Time);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            base.Draw(gameTime, _spriteBatch);
        }

    }
}
