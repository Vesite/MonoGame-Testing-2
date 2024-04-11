using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace MonoGame_Testing_2
{
    internal class Button
    {
        protected List<Texture2D> textures;
        public Vector2 position { get; set; }
        //private Rectangle rectangle;
        private int imageIndex = 0;
        private float scale;
        private bool buttonPressedDown = false;
        public Rectangle Rectangle => new((int)(position.X - textures[0].Width * scale / 2), (int)(position.Y - textures[0].Height * scale / 2), (int)(textures[0].Width * scale), (int)(textures[0].Height * scale));


        public Button(List<Texture2D> texture, Vector2 position, float scale)
        {
            this.textures = texture;
            this.position = position;
            this.scale = scale;
            //rectangle = new Rectangle((int)position.X - textures.Width / 2, (int)position.Y - textures.Height / 2, textures.Width, textures.Height);
            
        }

        public void Update()
        {
            if (InputManager.mouseRectangle.Intersects(Rectangle))
            {
                imageIndex = 1;
                if (InputManager.mouseLeftButtonClicked)
                {
                    buttonPressedDown = true;
                    Click();
                }

                if (!InputManager.mouseLeftButtonHold)
                {
                    buttonPressedDown = false;
                }
            }
            else
            {
                buttonPressedDown = false;
                imageIndex = 0;
            }

            if (buttonPressedDown)
            {
                imageIndex = 2;
            }
        }

        public event EventHandler OnClick;

        private void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(textures[imageIndex], position, null, Color.White, 0f, new Vector2(textures[0].Width / 2, textures[0].Height / 2), scale, SpriteEffects.None, 0f);

            if (Globals.isDrawingOutline) {
                Globals.DrawOutline(Rectangle);
            }
            
        }
    }
}
