using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaAudio;
using UTalDrawSystem.SistemaGameObject;
using static UTalDrawSystem.SistemaAudio.AudioManager;

namespace UTalDrawSystem.MyGame
{
    class Proyectil : UTGameObject
    {
        float vel_X;
        float vel_Y;
        public bool isDestroyed;

        Sounds disparoRayo;

        public Proyectil(string imagen, Vector2 pos, float velX, float velY, float rot, float escala, FF_form forma, bool isStatic = false, bool isSuperior = false) : base(imagen, pos, escala, forma, isStatic, isSuperior)
        {
            vel_X = velX;
            vel_Y = velY;
            objetoFisico.dibujable.rot = rot;
            isDestroyed = false;
            objetoFisico.isTrigger = true;

        }

        public override void Update(GameTime gameTime)
        {
            objetoFisico.pos += new Vector2(vel_X, vel_Y);
        }

        public override void OnCollision(UTGameObject other)
        {
            Asteroide ball = other as Asteroide;

            if (ball != null)
            {
                ball.hp -= 1;

                //Console.WriteLine(ball.hp);
                isDestroyed = true;
                Destroy();
            }
        }
    }
}
