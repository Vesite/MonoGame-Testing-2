
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    internal class UIManager
    {
        private Texture2D button_c4_mouseover;
        private Texture2D button_c4_normal;
        private Texture2D button_c4_pressed;
        private SpriteFont UIFont { get; }


        private readonly List<Button> buttons = new();


        public int Counter { get; set; }

        public UIManager()
        {
            button_c4_mouseover = Globals.Content.Load<Texture2D>("button_c4_mouseover");
            button_c4_normal = Globals.Content.Load<Texture2D>("button_c4_normal");
            button_c4_pressed = Globals.Content.Load<Texture2D>("button_c4_pressed");
            UIFont = Globals.Content.Load<SpriteFont>("ui_font");
        }

        public Button AddButton(Vector2 position, string text, int scale, int width, int height)
        {
            List<Texture2D> textureList = new() { button_c4_normal, button_c4_mouseover, button_c4_pressed };
            Button b = new(textureList, position, text, UIFont, scale, width, height);
            buttons.Add(b);

            return b;
        }

        public void Update()
        {
            foreach (var item in buttons)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (var item in buttons)
            {
                item.Draw();
            }

            Globals.SpriteBatch.DrawString(UIFont, Counter.ToString(), new(10, 10), Color.White);

        }
    }
}
