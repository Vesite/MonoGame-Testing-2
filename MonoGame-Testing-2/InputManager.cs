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

        public static bool MouseLeftButtonHold { get; private set; }
        public static bool MouseLeftButtonClicked { get; private set; }
        public static bool MouseRightButtonHold { get; private set; }
        public static bool MouseRightButtonClicked { get; private set; }

        public static Vector2 MousePosition { get; private set; }
        public static Rectangle MouseRectangle { get; private set; }

        public static bool KeyLeftHold { get; private set; }
        public static bool KeyRightHold { get; private set; }
        public static bool KeyDownHold { get; private set; }
        public static bool KeyUpHold { get; private set; }
        public static bool KeyLeftClicked { get; private set; }
        public static bool KeyRightClicked { get; private set; }
        public static bool KeyDownClicked { get; private set; }
        public static bool KeyUpClicked { get; private set; }

        public static bool KeyOClicked { get; private set; }

        public static void Update()
        {
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            #region Set Input Variables

            MouseLeftButtonHold = (mouseState.LeftButton == ButtonState.Pressed);
            MouseRightButtonHold = (mouseState.RightButton == ButtonState.Pressed);

            if ((mouseState.LeftButton == ButtonState.Pressed) && (prevMouseState.LeftButton == ButtonState.Released))
                MouseLeftButtonClicked = true;
            else
                MouseLeftButtonClicked = false;

            if ((mouseState.RightButton == ButtonState.Pressed) && (prevMouseState.RightButton == ButtonState.Released))
                MouseRightButtonClicked = true;
            else
                MouseRightButtonClicked = false;

            MousePosition = new(mouseState.X, mouseState.Y);
            MouseRectangle = new(mouseState.X, mouseState.Y, 1, 1);



            if ((keyState.IsKeyDown(Keys.Left)) && (prevKeyState.IsKeyUp(Keys.Left)))
                KeyLeftClicked = true;
            else
                KeyLeftClicked = false;

            if ((keyState.IsKeyDown(Keys.Right)) && (prevKeyState.IsKeyUp(Keys.Right)))
                KeyRightClicked = true;
            else
                KeyRightClicked = false;

            if ((keyState.IsKeyDown(Keys.Down)) && (prevKeyState.IsKeyUp(Keys.Down)))
                KeyDownClicked = true;
            else
                KeyDownClicked = false;

            if ((keyState.IsKeyDown(Keys.Up)) && (prevKeyState.IsKeyUp(Keys.Up)))
                KeyUpClicked = true;
            else
                KeyUpClicked = false;

            KeyLeftHold = keyState.IsKeyDown(Keys.Left);
            KeyRightHold = keyState.IsKeyDown(Keys.Right);
            KeyUpHold = keyState.IsKeyDown(Keys.Up);
            KeyDownHold = keyState.IsKeyDown(Keys.Down);


            if ((keyState.IsKeyDown(Keys.O)) && (prevKeyState.IsKeyUp(Keys.O)))
                KeyOClicked = true;
            else
                KeyOClicked = false;

            #endregion

            prevKeyState = keyState;
            prevMouseState = mouseState;
        }

    }
}
