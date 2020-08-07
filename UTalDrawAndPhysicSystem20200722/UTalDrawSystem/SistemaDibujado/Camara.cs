using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Camara
    {
        public Vector2 pos;
        public Vector2 tam;
        public float escala;
        public float rot;
        public static Camara ActiveCamera;

        public Camara(Vector2 pos, float escala, float rot)
        {
            this.pos = pos;
            this.escala = escala;
            this.rot = rot;
            if (ActiveCamera == null)
            {
                ActiveCamera = this;
            }
        }

        public void Dibujar(SpriteBatch SB)
        {
            foreach(Dibujable dib in Escena.INSTANCIA.dibujables)
            {
                dib.Draw(SB, pos, rot, escala);
            }
            foreach (Dibujable dib in Escena.INSTANCIA.dibujablesSuperior)
            {
                dib.Draw(SB, pos, rot, escala);
            }
        }
        public bool EsCamaraActiva()
        {
            return (this == ActiveCamera);
        }
        public void HacerActiva()
        {
            ActiveCamera = this;
        }
        public Vector2 PosMouseEnCamara()
        {
            Point cameraPoint = Mouse.GetState().Position;
            Vector2 cameraRawPos = new Vector2(cameraPoint.X, cameraPoint.Y);
            return Rotate((cameraRawPos) / escala + pos, rot);
        }

        public Vector2 Rotate(Vector2 v, double degrees)
        {
            float sin = (float)Math.Sin(degrees);
            float cos = (float)Math.Cos(degrees);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}
