using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame_Testing_2.Models;
using System;

namespace MonoGame_Testing_2
{
    public class GameManager
    {
        private readonly UIManager _ui = new();

        private readonly SceneManager _sceneManager;

        public GameManager()
        {
            _sceneManager = new(this);
        }

        public void Action1(object sender, EventArgs e)
        {
            _ui.Counter += 1;
        }
        public void Action2(object sender, EventArgs e)
        {
            _ui.Counter += 2;
        }
        public void Action3(object sender, EventArgs e)
        {
            _ui.Counter += 3;
        }

        public void Update(GameTime gameTime)
        {
            _ui.Update();

            // Spawn a new ball by clicking
            //if (InputManager.MouseRightButtonClicked)
            //{
            //    float radius = (float)random.NextDouble() * 60 + 20f;
            //    Vector2 direction = ConvertDirectionRadiansToVector2((float)(random.NextDouble() * 2 * Math.PI));
            //    float speed = (float)random.NextDouble() * 300 + 100;
            //    gameObjects.Add(new Ball1(new() { crystalBall }, InputManager.MousePosition, 1, radius, direction, speed));
            //}

            // Swap Between Scenes
            if (InputManager.KeyClicked(Keys.F1)) { _sceneManager.SwitchScene(Scenes.SceneMenu); }
            if (InputManager.KeyClicked(Keys.F2)) { _sceneManager.SwitchScene(Scenes.Scene1); }
            if (InputManager.KeyClicked(Keys.F3)) { _sceneManager.SwitchScene(Scenes.Scene2); }
            _sceneManager.Update(gameTime);

        }

        public void Draw(GameTime gameTime)
        {
            // So while getting the frame for each scene it uses "begin" and "end"
            var frame = _sceneManager.GetFrame(gameTime);

            Globals.SpriteBatch.Begin();

            Globals.SpriteBatch.Draw(frame, Vector2.Zero, Color.White);

            Globals.SpriteBatch.End();

            // TODO MOVE THIS TO SCENES
            // UI
            //_ui.Draw();

        }



        //private void SpawnWorldObjects()
        //{
        //    gameObjects.Add(new Board(new() { board }, new Vector2(400, 400), 2, 500));

        //    //_ui.AddButton(new(500, 500), "Button 1", 2, 90, 35).OnClick += Action1;
        //    //_ui.AddButton(new(200, 600), "Other Button", 2, 110, 35).OnClick += Action2;
        //    //_ui.AddButton(new(300, 800), "Click Me :)", 2, 50, 50).OnClick += Action3;
        //    //_ui.AddButton(new(200, 200), ":]", 4, 50, 50).OnClick += Action3;

        //    for (int x = 0; x < tiles.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < tiles.GetLength(1); y++)
        //        {
        //            if (tiles[x, y] == 0) continue;
        //            var posX = y * 64 + 32;
        //            var posY = x * 64 + 32;

        //            if (tiles[x, y] == 1)
        //            {
        //                var texture = blockDirt;
        //                var hp = 1;
        //                gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
        //            }
        //            else if (tiles[x, y] == 2)
        //            {
        //                var texture = blockBrick;
        //                var hp = 2;
        //                gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
        //            }
        //            else if (tiles[x, y] == 3)
        //            {
        //                var texture = blockMetal;
        //                var hp = 3;
        //                gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
        //            }
        //        }
        //    }
        //}

    }
}
