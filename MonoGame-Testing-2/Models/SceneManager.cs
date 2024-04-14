using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame_Testing_2.Models
{
    internal class SceneManager
    {
        public Scenes ActiveScene { get; private set; }
        private readonly Dictionary<Scenes, Scene> _scenes = [];


        public SceneManager(GameManager gameManager)
        {
            _scenes.Add(Scenes.SceneMenu, new SceneMenu(gameManager));
            _scenes.Add(Scenes.Scene1, new Scene1(gameManager));
            _scenes.Add(Scenes.Scene2, new Scene2(gameManager));

            ActiveScene = Scenes.SceneMenu;
            _scenes[ActiveScene].Activate();

        }

        public void SwitchScene(Scenes scene)
        {
            ActiveScene = scene;
            _scenes[ActiveScene].Activate();
        }

        public void Update(GameTime gameTime)
        {
            _scenes[ActiveScene].Update(gameTime);
        }

        public RenderTarget2D GetFrame(GameTime gameTime)
        {
            return _scenes[ActiveScene].GetFrame(gameTime);
        }

    }
}
