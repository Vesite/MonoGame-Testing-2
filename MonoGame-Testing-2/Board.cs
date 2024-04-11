using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Testing_2
{
    internal class Board : GameObject
    {

        private float speed;

        public Board(Texture2D texture, Vector2 position, float scale, float speed) : base(texture, position, scale)
        {
            this.speed = speed;
            
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects, List<int> indicesToRemove)
        {

            if (InputManager.keyLeftHold)
            {
                Position = new(Position.X - speed * Globals.Time, Position.Y);
            }
            if (InputManager.keyRightHold)
            {
                Position = new(Position.X + speed * Globals.Time, Position.Y);
            }
            if (InputManager.keyDownHold)
            {
                Position = new(Position.X, Position.Y + speed * Globals.Time);
            }
            if (InputManager.keyUpHold)
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
