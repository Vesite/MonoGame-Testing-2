using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace MonoGame_Testing_2
{
    
    internal class GameManager
    {

        #region Load Init

        private Texture2D crystalBall;
        private Texture2D board;
        private Texture2D blockDirt;
        private Texture2D blockBrick;
        private Texture2D blockMetal;

        public static Texture2D PixelTexture { get; private set; }

        #endregion

        private readonly UIManager _ui = new();
        private List<GameObject> gameObjects = new List<GameObject>();
        private Random random = new Random();

        public static readonly int[,] tiles =
        {
            {1, 1, 2, 3, 3, 2, 1, 1, 0, 0, 1, 1, 0, 0, 1},
            {1, 1, 2, 2, 2, 2, 1, 1, 0, 0, 1, 1, 0, 0, 1},
            {0, 0, 1, 2, 2, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1},
            {1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1}
        };

        private List<int> indicesToRemove = new List<int>();

        public GameManager()
        {

            #region Load Content Code

            crystalBall = Globals.Content.Load<Texture2D>("crystal_ball");
            board = Globals.Content.Load<Texture2D>("board");
            blockDirt = Globals.Content.Load<Texture2D>("block_dirt");
            blockBrick = Globals.Content.Load<Texture2D>("block_brick");
            blockMetal = Globals.Content.Load<Texture2D>("block_metal");

            PixelTexture = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
            PixelTexture.SetData(new Color[] { Color.White });

            #endregion

            spawnWorldObjects();
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
            if (InputManager.mouseRightButtonClicked)
            {
                float radius = (float)random.NextDouble() * 60 + 20f;
                Vector2 direction = ConvertDirectionRadiansToVector2((float)(random.NextDouble() * 2 * Math.PI));
                float speed = (float)random.NextDouble() * 300 + 100;
                gameObjects.Add(new Ball1(crystalBall, InputManager.mousePosition, 1, radius, direction, speed));
            }

            // Update all objects
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime, gameObjects, indicesToRemove);
            }

            // Remove marked objects
            foreach (int index in indicesToRemove)
            {
                gameObjects.RemoveAt(index);
            }
            indicesToRemove.Clear();
        }

        public void Draw(GameTime gameTime)
        {
            
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(gameTime, Globals.SpriteBatch);
            }

            // UI
            _ui.Draw();

        }



        public static Vector2 ConvertDirectionRadiansToVector2(float direction)
        {
            return new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction));
        }

        private void spawnWorldObjects()
        {
            gameObjects.Add(new Board(board, new Vector2(400, 400), 2, 500));

            _ui.AddButton(new(500, 500), 2).OnClick += Action1;
            _ui.AddButton(new(200, 600), 3).OnClick += Action2;
            _ui.AddButton(new(900, 800), 2).OnClick += Action3;

            //gameObjects.Add(new Button(button_c4_normal, new Vector2(600, 100), 1));

            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    if (tiles[x, y] == 0) continue;
                    var posX = y * 64 + 32;
                    var posY = x * 64 + 32;

                    if (tiles[x, y] == 1)
                    {
                        var texture = blockDirt;
                        var hp = 1;
                        gameObjects.Add(new BlockBasic(texture, new(posX, posY), 2, hp));
                    }
                    else if (tiles[x, y] == 2)
                    {
                        var texture = blockBrick;
                        var hp = 2;
                        gameObjects.Add(new BlockBasic(texture, new(posX, posY), 2, hp));
                    }
                    else if (tiles[x, y] == 3)
                    {
                        var texture = blockMetal;
                        var hp = 3;
                        gameObjects.Add(new BlockBasic(texture, new(posX, posY), 2, hp));
                    }
                }
            }
        }

    }
}
