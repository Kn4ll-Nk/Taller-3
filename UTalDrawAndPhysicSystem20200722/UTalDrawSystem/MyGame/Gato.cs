using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Automovil : UTGameObject
    {
        public int puntaje = 0;

        public Automovil(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
        }
        public override void Update(GameTime gameTime)
        {
            float vel;
            // 1.57 90 grados 
            // 3.14 180 grados 
            // 4.71 240 grados 
            // 6.28 360 grados 
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                vel = 0;
            }
            else
            {
                vel = 100;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //Console.WriteLine("D");

                objetoFisico.dibujable.rot = 1.57f;
                objetoFisico.AddVelocity(new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objetoFisico.dibujable.rot = 4.71f;
                objetoFisico.AddVelocity(new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = 0f;
                objetoFisico.AddVelocity(new Vector2(0, -(float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = 3.14f;
                objetoFisico.AddVelocity(new Vector2(0, (float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = 1.57f / 2f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = -1.57f / 2f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = 1.57f / 2f + 1.57f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = -1.57f / 2f - 1.57f;
            }



            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                Destroy();
            }

        }
        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;            

            if (col != null)
            {
                col.Destroy();
                puntaje++;
                Console.WriteLine(puntaje);
            }
        }
    }
}
