
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGame_Testing_2
{
    internal class UIManager
    {
        private Texture2D button_c4_mouseover;
        private Texture2D button_c4_normal;
        private Texture2D button_c4_pressed;

        private readonly List<Button> buttons = new();
        private SpriteFont ui_font { get; }
        public int Counter { get; set; }

        public UIManager()
        {
            button_c4_mouseover = Globals.Content.Load<Texture2D>("button_c4_mouseover");
            button_c4_normal = Globals.Content.Load<Texture2D>("button_c4_normal");
            button_c4_pressed = Globals.Content.Load<Texture2D>("button_c4_pressed");
            ui_font = Globals.Content.Load<SpriteFont>("ui_font");
        }

        public Button AddButton(Vector2 position, float scale)
        {
            var textureList = new List<Texture2D>() { button_c4_normal, button_c4_mouseover, button_c4_pressed };
            Button b = new Button(textureList, position, scale);
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

            Globals.SpriteBatch.DrawString(ui_font, Counter.ToString(), new(10, 10), Color.White);

        }
    }
}
