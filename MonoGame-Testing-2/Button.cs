using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace MonoGame_Testing_2
{
    internal class Button
    {
        protected List<Texture2D> textures;
        public Vector2 Position { get; set; }
        private SpriteFont font { get; }
        
        private int imageIndex = 0;
        private float scale;
        private string text;
        private bool buttonPressedDown = false;
        public Rectangle Rectangle => new((int)(Position.X - textures[0].Width * scale / 2), (int)(Position.Y - textures[0].Height * scale / 2), (int)(textures[0].Width * scale), (int)(textures[0].Height * scale));

        public Button(List<Texture2D> texture, Vector2 position, float scale, string text, SpriteFont font)
        {
            this.textures = texture;
            Position = position;
            this.scale = scale;
            this.text = text;
            this.font = font;
        }

        public void Update()
        {
            if (InputManager.MouseRectangle.Intersects(Rectangle))
            {
                imageIndex = 1;
                if (InputManager.MouseLeftButtonClicked)
                {
                    buttonPressedDown = true;
                    Click();
                }

                if (!InputManager.MouseLeftButtonHold)
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
            Globals.SpriteBatch.Draw(textures[imageIndex], Position, null, Color.White, 0f, new Vector2(textures[0].Width / 2, textures[0].Height / 2), scale, SpriteEffects.None, 0f);

            Globals.DrawStringCentered(Globals.SpriteBatch, font, text, Position, Color.White);
            //Globals.SpriteBatch.DrawString(font, text, Position, Color.White);

            if (Globals.isDrawingOutline) {
                Globals.DrawOutline(Rectangle);
            }
            
        }
    }
}
