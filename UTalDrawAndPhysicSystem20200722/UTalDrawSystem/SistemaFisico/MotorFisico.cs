using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaFisico
{
    public static class MotorFisico
    {
        public static List<ObjetoFisico> objetosFisicos = new List<ObjetoFisico>();
        public static void agregarObjetoFisico(ObjetoFisico of)
        {
            objetosFisicos.Add(of);
        }
        public static void removerObjetoFisico(ObjetoFisico of)
        {
            objetosFisicos.Remove(of);
        }
        public static void Update(GameTime gameTime)
        {
            foreach(ObjetoFisico of in objetosFisicos)
            {
                of.isColliding = false;
            }
            for(int i=0; i<objetosFisicos.Count;i++)
            {
                for(int j=i+1; j < objetosFisicos.Count; j++)
                {
                    ObjetoFisico objetoA = objetosFisicos[i];
                    ObjetoFisico objetoB = objetosFisicos[j];
                    if (objetoA.Colisiona(objetoB))
                    {
                        if(objetoA.OnCollision !=null && objetoB.GetObject != null)
                        {
                            objetoA.OnCollision(objetoB.GetObject());
                        }
                        if (objetoB.OnCollision != null && objetoA.GetObject != null)
                        {
                            objetoB.OnCollision(objetoA.GetObject());
                        }
                        if (!(objetoA.isTrigger || objetoB.isTrigger))
                        {

                            objetoA.isColliding = objetoB.isColliding = true;
                            Vector2 direccionBA = (objetoA.pos - objetoB.pos);
                            Vector2 VelocityBA = objetoA.vel + objetoB.vel;
                            //direccionBA.Normalize();
                            if (objetoA.isStatic)
                            {
                                objetoB.AplicaFuerza((-direccionBA + -VelocityBA) * 15f, (float)gameTime.ElapsedGameTime.TotalSeconds, true);
                            }
                            else if (!objetoB.isStatic)
                            {
                                objetoA.AplicaFuerza((direccionBA + VelocityBA) * 30f, (float)gameTime.ElapsedGameTime.TotalSeconds);
                            }
                            if (objetoB.isStatic)
                            {
                                objetoA.AplicaFuerza((direccionBA + -VelocityBA) * 15f, (float)gameTime.ElapsedGameTime.TotalSeconds, true);
                            }
                            else if (!objetoA.isStatic)
                            {
                                objetoB.AplicaFuerza((-direccionBA + VelocityBA) * 30f, (float)gameTime.ElapsedGameTime.TotalSeconds);
                            }
                        }
                    }
                }
                objetosFisicos[i].Update((float)gameTime.ElapsedGameTime.TotalSeconds); 
            }

        }
    }
}
