using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Pelota : UTGameObject
    {
        public int hp;
        public Pelota(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = true) : base(imagen, pos, escala, forma, isStatic, isSuperior = true)
        {
            hp = 5;
        }

        public override void Update(GameTime gameTime)
        {
            if (hp <= 0)
            {
                Game1.INSTANCE.ventanaJuego.score  += 100;
                Destroy();
            }
        }

    }
}
