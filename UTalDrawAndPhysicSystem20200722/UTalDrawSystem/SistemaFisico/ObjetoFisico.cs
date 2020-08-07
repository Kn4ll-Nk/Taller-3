using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.SistemaFisico
{
    public class ObjetoFisico
    {
        public Dibujable dibujable;
        public bool isStatic = false;
        public bool isTrigger = false;
        public Vector2 pos { get { return dibujable.pos; } set{dibujable.pos = value; } }
        public Vector2 vel { get; private set; }
        public bool isColliding;
        public delegate void OnCollisionDelegate(Object obj);
        public delegate Object GetObjectDelegate();
        public OnCollisionDelegate OnCollision;
        public GetObjectDelegate GetObject;

        public class FFOffset
        {
            public FormaFisica ff;
            public Vector2 offset;
        }
        public List<FFOffset> formasFisicasOffset = new List<FFOffset>();
        public float masa = 1;
        public ObjetoFisico(Dibujable dibujable, float masa = 1)
        {
            this.dibujable = dibujable;
            this.masa = masa;
            MotorFisico.agregarObjetoFisico(this);
        }
        public void AddVelocity(Vector2 newVel)
        {
            if (!isColliding)
            {
                vel += newVel;
            }
        }
        public void SetVelocity(Vector2 newVel)
        {
            if (!isColliding)
            {
                vel = newVel;
            }
        }
        public void agregarFFCirculo(float radio, Vector2 offsetPos)
        {
            FormaFisica ff = new FormaFisicaCirculo(radio);
            FFOffset ffo = new FFOffset();
            ffo.ff = ff;
            ffo.offset = offsetPos;

            formasFisicasOffset.Add(ffo);
        }
        public void agregarFFRectangulo(float ancho,float alto, Vector2 offsetPos)
        {
            FormaFisica ff = new FormaFisicaRectangulo(ancho, alto);
            FFOffset ffo = new FFOffset();
            ffo.ff = ff;
            ffo.offset = offsetPos;

            formasFisicasOffset.Add(ffo);
        }
        public bool Colisiona(ObjetoFisico otro)
        {            
            bool resultadoColisiona = false;
            foreach(FFOffset ffo in formasFisicasOffset)
            {
                ffo.ff.pos = pos + ffo.offset;
                foreach(FFOffset otro_ffo in otro.formasFisicasOffset)
                {
                    otro_ffo.ff.pos = otro.pos + otro_ffo.offset;
                    resultadoColisiona = otro_ffo.ff.colisiona(ffo.ff);
                }
            }
            return resultadoColisiona;
        }
        public void AplicaFuerza(Vector2 fuerza,float deltaTiempoSeg, bool forceVel = false)
        {
            if (forceVel)
            {                
                vel = new Vector2(0,0);
            }
            //Console.WriteLine("Aplicación Fuerza: Fuerza");
            //Console.WriteLine(fuerza);
            Vector2 acel = fuerza / masa;
            vel += acel * deltaTiempoSeg;                        
        }
        public void Update(float deltaTiempoSeg)
        {
            pos += vel;
            vel = vel * .9f;
        }
        public void Destruir()
        {
            MotorFisico.removerObjetoFisico(this);
        }
    }
}
