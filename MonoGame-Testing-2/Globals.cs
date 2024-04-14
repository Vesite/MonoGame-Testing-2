using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Testing_2
{
    public static class Globals
    {
        public static ContentManager Content { get; set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static bool Paused = false;

        public static float Time { get; private set; }
        public static bool isDrawingOutline { get; private set; } = false;
        public static Point WindowSize { get; } = new Point(64 * 15, 64 * 15);

        public static Random RandomGenerator { get; } = new Random();




        public static RenderTarget2D GetNewRenderTarget()
        {
            return new RenderTarget2D(Globals.GraphicsDevice, WindowSize.X, WindowSize.Y);
        }

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
            if (InputManager.KeyClicked(Keys.O))
            {
                isDrawingOutline = !isDrawingOutline;
            }
        }

        public static void DrawOutline(Rectangle rectangle)
        {
            var col = Color.Yellow;
            // Draw top line
            Globals.SpriteBatch.Draw(Game1.PixelTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1), col);
            // Draw bottom line
            Globals.SpriteBatch.Draw(Game1.PixelTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - 1, rectangle.Width, 1), col);
            // Draw left line
            Globals.SpriteBatch.Draw(Game1.PixelTexture, new Rectangle(rectangle.X, rectangle.Y, 1, rectangle.Height), col);
            // Draw right line
            Globals.SpriteBatch.Draw(Game1.PixelTexture, new Rectangle(rectangle.X + rectangle.Width - 1, rectangle.Y, 1, rectangle.Height), col);
        }

        public static void DrawStringCentered(this SpriteBatch spriteBatch, SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            // Measure the size of the text
            Vector2 textSize = spriteFont.MeasureString(text);

            Vector2 centeredPosition = position - textSize / 2;

            spriteBatch.DrawString(spriteFont, text, centeredPosition, color);
        }

        public static void DrawAtlasImage(SpriteBatch spritebatch, Texture2D texture, float scale, int image_width, Vector2 position, int image_index, float rotation)
        {

            Rectangle sourceRectangle = new(0 + image_index * image_width, 0, image_width, texture.Height);

            Rectangle destinationRectangle = new((int)(position.X - image_width * scale / 2), (int)(position.Y - texture.Height * scale / 2),
                                                 (int)(image_width * scale), (int)(texture.Height * scale));

            // Calculate the origin for rotation (center of the sprite)
            //Vector2 origin = new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2);
            Vector2 origin = new(0, 0);
            spritebatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, rotation, origin, SpriteEffects.None, 0);

        }

        public static Vector2 ConvertDirectionRadiansToVector2(float direction)
        {
            return new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction));
        }
    }
}
