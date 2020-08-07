using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Escena
    {
        public List<Dibujable> dibujables { get; private set; } = new List<Dibujable>();
        public List<Dibujable> dibujablesSuperior { get; private set; } = new List<Dibujable>();
        public List<Dibujable> dibujablesInferior { get; private set; } = new List<Dibujable>();

        public static Escena INSTANCIA;

        public Escena()
        {
            INSTANCIA = this;
        }
        public void agregarDib(Dibujable dib, bool isSuperior = false, bool isInferior = false)
        {
            if (isInferior)
            {
                dibujablesInferior.Add(dib);
            }
            else if (isSuperior)
            {
                dibujablesSuperior.Add(dib);
            }
            else
            {
                dibujables.Add(dib);
            }


           
            
        }
        public void removerDib(Dibujable dib)
        {
            dibujablesInferior.Remove(dib);
            dibujables.Remove(dib);
            dibujablesSuperior.Remove(dib);
        }
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
