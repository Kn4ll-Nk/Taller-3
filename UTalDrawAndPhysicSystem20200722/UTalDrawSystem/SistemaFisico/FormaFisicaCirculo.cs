using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaFisico
{
    public class FormaFisicaCirculo : FormaFisica
    {
        public float radio;
        public FormaFisicaCirculo(float radio)
        {
            this.radio = radio;
        }
        public override bool colisiona(FormaFisica otra)
        {
            try
            {
                FormaFisicaCirculo otroCirculo = otra as FormaFisicaCirculo;
                if (otroCirculo != null)
                {
                    float distanciaCuadrada = (otroCirculo.pos - this.pos).LengthSquared();
                    float sumaRadios = this.radio + otroCirculo.radio;
                    if (distanciaCuadrada < sumaRadios * sumaRadios)
                    {
                        return true;
                    }
                    return false;
                }
                FormaFisicaRectangulo otroRectangulo = otra as FormaFisicaRectangulo;
                if (otroRectangulo != null)
                {
                    return otroRectangulo.colisiona(this);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
