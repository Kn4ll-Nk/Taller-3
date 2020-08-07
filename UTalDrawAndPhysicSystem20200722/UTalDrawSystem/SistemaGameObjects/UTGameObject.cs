using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;

namespace UTalDrawSystem.SistemaGameObject
{    
    public class UTGameObject
    {
        public ObjetoFisico objetoFisico;
        Dibujable dibujable;
        public enum FF_form { Circulo, Rectangulo};
        public UTGameObject(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = false, bool isInferior = false)
        {
            dibujable = new Dibujable(imagen, pos, escala, isSuperior, isInferior);
            objetoFisico = new ObjetoFisico(dibujable);
            if (forma == FF_form.Circulo)
            {
                objetoFisico.agregarFFCirculo(dibujable.ancho/2f, new Vector2(0, 0));
            }
            else
            {
                objetoFisico.agregarFFRectangulo(dibujable.ancho, dibujable.alto, new Vector2(0, 0));
            }
            objetoFisico.isStatic = isStatic;
            objetoFisico.OnCollision = OnCollision;
            objetoFisico.GetObject = GetObject;


            UTGameObjectsManager.suscribirObjeto(this);
        }
        private void OnCollision(Object other)
        {
            UTGameObject otherUTG = other as UTGameObject;
            OnCollision(otherUTG);
        }
        public Object GetObject()
        {
            return this as Object;
        }

        public virtual void OnCollision(UTGameObject other)
        {

        }
        public void Destroy()
        {
            UTGameObjectsManager.DestruirObjeto(this);
        }
        public void OnDestroy()
        {
            dibujable.Destruir();
            objetoFisico.Destruir();
        }
        public virtual void Update(GameTime gameTime)
        {

        }

    }
}
