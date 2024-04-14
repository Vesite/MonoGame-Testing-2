using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    internal class BlockObject : GameObject
    {

        public BlockObject(List<Texture2D> textures, Vector2 position, float scale, int hp) : base(textures, position, scale)
        {
            this.hp = hp;
            this.hp_max = hp;
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {

            base.Draw(gameTime, _spriteBatch);

            // Breaking Texture
            if (!(hp == hp_max))
            {
                if (hp == 1)
                {
                    // Draw big cracks
                    Globals.DrawAtlasImage(_spriteBatch, textures[1], 2, 32, Position, 4, 0);
                }
                else if (hp >= 2)
                {
                    // Draw small cracks
                    Globals.DrawAtlasImage(_spriteBatch, textures[1], 2, 32, Position, 1, 0);
                }
            }


        }

    }
}
