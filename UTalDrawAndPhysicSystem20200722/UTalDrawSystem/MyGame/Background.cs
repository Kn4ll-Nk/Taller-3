using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Background : UTGameObject
    {
        public Background(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = false, bool isInferior = false) : base(imagen, pos, escala, forma, isStatic, isSuperior, isInferior)
        {
            objetoFisico.isTrigger = true;
        }
        public override void Update(GameTime gameTime)
        {
            objetoFisico.pos += new Vector2(5f, 0);
        }

    }
}
