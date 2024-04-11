using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Testing_2
{
    internal class BlockObject : GameObject
    {

        private int hp;

        public BlockObject(Texture2D texture, Vector2 position, float scale, int hp) : base(texture, position, scale)
        {
            this.hp = hp;
        }


    }
}
