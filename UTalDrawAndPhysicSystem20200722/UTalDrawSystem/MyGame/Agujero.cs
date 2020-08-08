using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Agujero : UTGameObject
    {
        public Agujero(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
            objetoFisico.isTrigger = true;

            objetoFisico.agregarFFCirculo(25f, new Vector2(1,1));
  
        }
        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            Asteroide ball = other as Asteroide;
            Proyectil pry = other as Proyectil;

            if (col != null)
            {
                col.Destroy();                
            }
            if (ball != null )
            {
                ball.Destroy();;
            }
            if (pry != null )
            {
                pry.isDestroyed = true;
                pry.Destroy();;
            }
        }
    }
}
