using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaAudio;
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

            AudioManager.PlaySong("MainGameSoundTrack", loop: true);
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
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 50, SB.GraphicsDevice.Viewport.Height / 4.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 1.95f, SB.GraphicsDevice.Viewport.Height / 1.2f);

                SB.DrawString(titulo, "Jueguito de la nave que destruye asteroides, y come rayitos\n", tituloPos, Color.White);
                SB.DrawString(mensaje, "-> Comienzas el juego con 5 vidas.\n" +
                    "-> Perderas una vida al quedarte al ser atrapado por la camara, ser golpeado por los \n" +
                    "asteroides, o ser atrapado por los agujeron negros en el camino.\n" +
                    "-> Puedes disparar a los asteroides para destruirlos. Estos daran 100 puntos\n" +
                    "-> Los disparos pueden ser absorbidos por los agujeros negros.\n" +
                    "-> Comer los rayos que encuentres en el camino aumentara tu nivel de Energia.\n" +
                    "-> El nivel maximo de enrgia es de 5.\n" +
                    "-> Morir reestablecera tu nivel de Energia a 1.\n" +
                    "-> Cada 5000 puntos que consigas obtendras una vida extra.\n" +
                    "\n" +
                    "-> Movimiento : \n" +
                    "       [W] -> Arriba\n" +
                    "       [A] -> Izquierda\n" +
                    "       [S] -> Abajo\n" +
                    "       [D] -> Derecha\n" +
                    "       [Space] -> Disparar\n" +
                    "-> Divertite ;D \n", mensajePos, Color.White);
                SB.DrawString(accion, "Presiona 'Enter' para comenzar.\n", accionPos, Color.White);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 2f, SB.GraphicsDevice.Viewport.Height / 1.1f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.White);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 3.4f, SB.GraphicsDevice.Viewport.Height / 2.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Jueguito de la nave que destruye asteroides, y come rayitos\n", tituloPos, Color.White);
                SB.DrawString(mensaje, "Score --> " + Game1.INSTANCE.ventanaJuego.score + "\n" +
                    "Tiempo Total --> " + Math.Round(Game1.INSTANCE.ventanaJuego.time, 2) + " Segundos\n" +
                    "Power Ups recogidos --> " + Game1.INSTANCE.ventanaJuego.ship.powerUpTotales, mensajePos, Color.White)
                    ;
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.White);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 4f, SB.GraphicsDevice.Viewport.Height / 1.15f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.White);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 5f, SB.GraphicsDevice.Viewport.Height / 3.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Jueguito de la nave que destruye asteroides, y come rayitos\n", tituloPos, Color.White);
                SB.DrawString(mensaje, "Grupo : 2.\n" +
                    "Integrantes : \n" +
                    "-> Kevin Ignacio Silva Kendall.\n" +
                    "-> Joaquin Rodrigo Ugarte Torres.\n" +
                    "Motor Utilizado : UTalPhysicsAndDrawSystem.\n" +
                    "Creador : Sven Von Brand.\n", mensajePos, Color.White);
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.White);
            }
         
        }
    }
}
