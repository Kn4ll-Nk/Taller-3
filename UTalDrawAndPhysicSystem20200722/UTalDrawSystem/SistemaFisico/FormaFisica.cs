using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaFisico
{
    public abstract class FormaFisica
    {
        public Vector2 pos;
        public abstract bool colisiona(FormaFisica otra);
    }
}
