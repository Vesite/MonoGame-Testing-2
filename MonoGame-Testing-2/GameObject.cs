using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace MonoGame_Testing_2
{
    internal class GameObject
    {
        
        protected Texture2D texture;
        protected Texture2D pixel;
        public Vector2 Position { get; set; }
        public float scale;
        public Rectangle Rectangle => new((int)(Position.X - texture.Width * scale / 2), (int)(Position.Y - texture.Height * scale / 2), (int)(texture.Width * scale), (int)(texture.Height * scale));
        

        public GameObject(Texture2D texture, Vector2 position, float scale)
        {
            this.texture = texture;
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
            Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0f);
            if (Globals.isDrawingOutline)
                Globals.DrawOutline(Rectangle);
        }

    }
}
