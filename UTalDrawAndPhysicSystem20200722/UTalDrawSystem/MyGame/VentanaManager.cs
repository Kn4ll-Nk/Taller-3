using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class VentanaManager : Escena
    {
        Camara camara;

        SpriteFont titulo;
        SpriteFont mensaje;
        SpriteFont accion;

        public VentanaManager(ContentManager content)
        {        
            UTGameObjectsManager.Init();

            titulo = content.Load<SpriteFont>("Titulo");
            mensaje = content.Load<SpriteFont>("Instrucciones");
            accion = content.Load<SpriteFont>("Accion");

            camara = new Camara(new Vector2(0, 0), .5f, 0);
            camara.HacerActiva();


        }

        public override void Update(GameTime gameTime)
        {
            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Start)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Game);
                    
                }
            }
            

            if(Game1.INSTANCE.ActiveScene == Game1.Scene.Start || Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.C))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Credits);                   
                }
            }

            if(Game1.INSTANCE.ActiveScene == Game1.Scene.End || Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Start);
                }
            }
        }

        public void Draw(SpriteBatch SB)
        {
            Vector2 tituloPos;
            Vector2 mensajePos;
            Vector2 accionPos;

            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Start)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 50, SB.GraphicsDevice.Viewport.Height / 4);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 3.8f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con cosas, y come monedas\n" +
                    "       (Descanse en paz el genio creativo detras del nombre.)\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, " COMO NO TE ENTERASTE TODAVIA! HA LLEGADO EL JUEGO ACLAMADO \n" +
                    "POR EL MISMISIMO PROFESOR! OSI OSI\n" +
                    "-> Comienzas el juego con 5 vidas.\n" +
                    "-> Perderas una vida al quedarte atras de la camara o caer en los agujeros del camino.\n" +
                    "-> Cuidado con las pelotas, pues rebotaras al chocar contra ellas.\n" +
                    "-> Cada 25 monedas que consigas obtendras una vida extra.\n" +
                    "-> El juego ya no tiene glitches, tampoco amor.\n" +
                    "\n" +
                    "-> Movimiento : [W]-[A]-[S]-[D]\n" +
                    "-> Frenar : [X] (o no presiones nada, es lo mismo).\n" +
                    "-> Diviertete ;D \n", mensajePos, Color.Black);
                SB.DrawString(accion, "Presiona 'Enter' para comenzar.\n", accionPos, Color.Black);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 4f, SB.GraphicsDevice.Viewport.Height / 1.15f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.Black);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 3.4f, SB.GraphicsDevice.Viewport.Height / 2.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con pelotas, muros y come monedas.\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, "Numero de Colisiones --> " + Game1.INSTANCE.ventanaJuego.n_Choques + "\n" +
                    "Tiempo Total --> " + Math.Round(Game1.INSTANCE.ventanaJuego.time, 2) + " Segundos\n" +
                    "Power Ups recogidos --> " + Game1.INSTANCE.ventanaJuego.auto.powerUpTotales, mensajePos, Color.Black)
                    ;
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.Black);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 4f, SB.GraphicsDevice.Viewport.Height / 1.15f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.Black);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 5f, SB.GraphicsDevice.Viewport.Height / 3.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con pelotas, muros y come monedas.\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, "Grupo : 2.\n" +
                    "Integrantes : \n" +
                    "-> Kevin Ignacio Silva Kendall.\n" +
                    "-> Joaquin Rodrigo Ugarte Torres.\n" +
                    "Motor Utilizado : UTalPhysicsAndDrawSystem.\n" +
                    "Creador : Sven Von Brand.\n", mensajePos, Color.Black);
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.Black);
            }
         
        }
    }
}
