using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    internal class GameObject
    {

        protected List<Texture2D> textures;
        //protected Texture2D pixel;
        public Vector2 Position { get; set; }
        public float scale;
        public Rectangle Rectangle => new((int)(Position.X - textures[0].Width * scale / 2), (int)(Position.Y - textures[0].Height * scale / 2), (int)(textures[0].Width * scale), (int)(textures[0].Height * scale));
        public int hp = 1;
        public int hp_max = 1;

        public GameObject(List<Texture2D> texture, Vector2 position, float scale)
        {
            this.textures = texture;
            this.Position = position;
            this.scale = scale;
        }

        public virtual void Update(GameTime gameTime, List<GameObject> gameObjects, List<int> indicesToRemove)
        {
            // Default implementation (do nothing)
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            // Default implementation
            Globals.SpriteBatch.Draw(textures[0], Position, null, Color.White, 0f, new Vector2(textures[0].Width / 2, textures[0].Height / 2), scale, SpriteEffects.None, 0f);
            if (Globals.isDrawingOutline)
                Globals.DrawOutline(Rectangle);
        }

        public bool UpdateHP(int amount, List<int> indicesToRemove)
        {
            hp += amount;

            if (hp <= 0)
            {
                // Kill this instance
                return true;
            }

            return false;
        }

    }
}
