using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Testing_2
{
    public static class InputManager
    {
        private static KeyboardState keyState;
        private static KeyboardState prevKeyState;

        private static MouseState mouseState;
        private static MouseState prevMouseState;

        public static bool mouseLeftButtonHold;
        public static bool mouseLeftButtonClicked;
        public static bool mouseRightButtonHold;
        public static bool mouseRightButtonClicked;

        public static Vector2 mousePosition;
        public static Rectangle mouseRectangle;

        public static bool keyLeftHold;
        public static bool keyRightHold;
        public static bool keyDownHold;
        public static bool keyUpHold;
        public static bool keyLeftClicked;
        public static bool keyRightClicked;
        public static bool keyDownClicked;
        public static bool keyUpClicked;

        public static bool keyOClicked;


        public static void Update()
        {
            var keyState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            #region Set Input Variables

            mouseLeftButtonHold = (mouseState.LeftButton == ButtonState.Pressed);
            mouseRightButtonHold = (mouseState.RightButton == ButtonState.Pressed);

            if ((mouseState.LeftButton == ButtonState.Pressed) && (prevMouseState.LeftButton == ButtonState.Released))
                mouseLeftButtonClicked = true;
            else
                mouseLeftButtonClicked = false;

            if ((mouseState.RightButton == ButtonState.Pressed) && (prevMouseState.RightButton == ButtonState.Released))
                mouseRightButtonClicked = true;
            else
                mouseRightButtonClicked = false;

            mousePosition = new(mouseState.X, mouseState.Y);
            mouseRectangle = new(mouseState.X, mouseState.Y, 1, 1);



            if ((keyState.IsKeyDown(Keys.Left)) && (prevKeyState.IsKeyUp(Keys.Left)))
                keyLeftClicked = true;
            else
                keyLeftClicked = false;

            if ((keyState.IsKeyDown(Keys.Right)) && (prevKeyState.IsKeyUp(Keys.Right)))
                keyRightClicked = true;
            else
                keyRightClicked = false;

            if ((keyState.IsKeyDown(Keys.Down)) && (prevKeyState.IsKeyUp(Keys.Down)))
                keyDownClicked = true;
            else
                keyDownClicked = false;

            if ((keyState.IsKeyDown(Keys.Up)) && (prevKeyState.IsKeyUp(Keys.Up)))
                keyUpClicked = true;
            else
                keyUpClicked = false;

            keyLeftHold = keyState.IsKeyDown(Keys.Left);
            keyRightHold = keyState.IsKeyDown(Keys.Right);
            keyUpHold = keyState.IsKeyDown(Keys.Up);
            keyDownHold = keyState.IsKeyDown(Keys.Down);


            if ((keyState.IsKeyDown(Keys.O)) && (prevKeyState.IsKeyUp(Keys.O)))
                keyOClicked = true;
            else
                keyOClicked = false;

            #endregion

            prevKeyState = keyState;
            prevMouseState = mouseState;
        }

    }
}
