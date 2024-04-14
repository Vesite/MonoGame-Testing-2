using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGame_Testing_2.Models
{
    internal class Scene2 : Scene
    {

        private Texture2D crystalBall;
        private Texture2D board;

        private Texture2D blockDirt;
        private Texture2D blockBrick;
        private Texture2D blockMetal;
        private Texture2D breakTexture;

        public static readonly int[,] tiles =
        {
            {1, 1, 2, 3, 3, 2, 1, 1, 0, 0, 1, 1, 0, 0, 1},
            {1, 1, 2, 2, 2, 2, 1, 1, 0, 0, 1, 1, 0, 0, 1},
            {0, 0, 1, 2, 2, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1},
            {1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
            {0, 0, 3, 3, 3, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3}
        };

        public Scene2(GameManager gameManager) : base(gameManager)
        {

        }

        protected override void Load()
        {
            crystalBall = Globals.Content.Load<Texture2D>("crystal_ball");
            board = Globals.Content.Load<Texture2D>("board");

            blockDirt = Globals.Content.Load<Texture2D>("block_dirt");
            blockBrick = Globals.Content.Load<Texture2D>("block_brick");
            blockMetal = Globals.Content.Load<Texture2D>("block_metal");
            breakTexture = Globals.Content.Load<Texture2D>("break");
        }


        public override void Activate()
        {
            gameObjects.Clear();

            // Create Scene Objects
            gameObjects.Add(new Board(new() { board }, new Vector2(500, 700), 2, 500));

            float radius = 30f;
            Vector2 direction = Globals.ConvertDirectionRadiansToVector2((float)(Globals.RandomGenerator.NextDouble() * (Math.PI * 2)));
            float speed = 800f;
            gameObjects.Add(new Ball1(new() { crystalBall }, new(700, 700), 1, radius, direction, speed));

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
                        gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
                    }
                    else if (tiles[x, y] == 2)
                    {
                        var texture = blockBrick;
                        var hp = 2;
                        gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
                    }
                    else if (tiles[x, y] == 3)
                    {
                        var texture = blockMetal;
                        var hp = 3;
                        gameObjects.Add(new BlockBasic(new() { texture, breakTexture }, new(posX, posY), 2, hp));
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
