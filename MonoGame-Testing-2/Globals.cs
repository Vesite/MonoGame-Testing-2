using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace MonoGame_Testing_2
{
    public static class Globals
    {
        public static ContentManager Content { get; set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        
        public static SpriteBatch SpriteBatch { get; set; }

        public static bool Paused = false;

        public static float Time {  get; private set; }
        public static bool isDrawingOutline { get; private set; } = false;


        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
            if (InputManager.keyOClicked)
            {
                isDrawingOutline = !isDrawingOutline;
            }
        }



        public static void DrawOutline(Rectangle rectangle)
        {
            var col = Color.Yellow;
            // Draw top line
            Globals.SpriteBatch.Draw(GameManager.PixelTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1), col);
            // Draw bottom line
            Globals.SpriteBatch.Draw(GameManager.PixelTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - 1, rectangle.Width, 1), col);
            // Draw left line
            Globals.SpriteBatch.Draw(GameManager.PixelTexture, new Rectangle(rectangle.X, rectangle.Y, 1, rectangle.Height), col);
            // Draw right line
            Globals.SpriteBatch.Draw(GameManager.PixelTexture, new Rectangle(rectangle.X + rectangle.Width - 1, rectangle.Y, 1, rectangle.Height), col);
        }

    }
}
