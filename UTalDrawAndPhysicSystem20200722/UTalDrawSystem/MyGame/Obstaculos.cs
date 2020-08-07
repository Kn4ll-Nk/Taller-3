using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Obstaculos : UTGameObject
    {
        public Obstaculos(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
            objetoFisico.isTrigger = true;


            objetoFisico.agregarFFCirculo(25f, new Vector2(1,1));

        
           
        }
    }
}
