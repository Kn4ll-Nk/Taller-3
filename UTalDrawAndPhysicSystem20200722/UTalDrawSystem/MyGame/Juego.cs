using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class Juego : Escena
    { 
        public Camara camara { private set; get; }

        Texture2D fondo;

        SpriteFont timer;
        SpriteFont vidasActuales;
        SpriteFont puntajeTotal;
        SpriteFont powerUpLevel;
        Texture2D timerIcon;
        Texture2D vidasIcon;
        Texture2D powerUpIcon;
        Texture2D asteroidIcon;


        int difficultyLevel;
        double timeChangeDifficulty;

        int cameraSpeed;

        public int score;

        public Automovil auto;
        List<Background> listaFondo;
        List<Pelota> listaAsteroides;
        List<Agujero> listaAgujeros;
        List<Coleccionable> listaEnergy;

        List<Proyectil> listaProyectiles;

        Random rnd;
        public int n_Choques { private set; get; }
        bool collision_on;
        bool ganoVidas;
        public double time { private set; get; }
        double timeSpawnAsteroides;
        double timeSpawnAgujeros;
        double timeSpawnEnergy;
        int posYEnergy;

        public Juego(ContentManager content)
        {
            UTGameObjectsManager.Init();

            fondo = content.Load<Texture2D>("fondo");

            timer = content.Load<SpriteFont>("Titulo");
            vidasActuales = content.Load<SpriteFont>("Titulo");
            puntajeTotal = content.Load<SpriteFont>("Instrucciones");
            powerUpLevel = content.Load<SpriteFont>("Instrucciones");

            timerIcon = content.Load<Texture2D>("timer");
            vidasIcon = content.Load<Texture2D>("vida");
            powerUpIcon = content.Load<Texture2D>("energy");
            asteroidIcon = content.Load<Texture2D>("Asteroid");

            difficultyLevel = 1;
            cameraSpeed = 6;

            score = 0;

            listaFondo = new List<Background>();
            listaAsteroides = new List<Pelota>();
            listaAgujeros = new List<Agujero>();
            listaEnergy = new List<Coleccionable>();

            listaProyectiles = new List<Proyectil>();

            auto = new Automovil(content, "ship", new Vector2(450, Game1.INSTANCE.GraphicsDevice.Viewport.Height), 0.3f, UTGameObject.FF_form.Rectangulo);

            rnd = new Random();
            time = 0;
            timeChangeDifficulty = 0;
            timeSpawnAsteroides = 0;
            timeSpawnAgujeros = 0;
            timeSpawnEnergy = 0;

            n_Choques = 0;
            ganoVidas = false;

            camara = new Camara(new Vector2(0,0), .5f, 0);
            camara.HacerActiva();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Game)
            {
                time += gameTime.ElapsedGameTime.TotalSeconds;
                timeChangeDifficulty += gameTime.ElapsedGameTime.TotalSeconds;
                timeSpawnAsteroides += gameTime.ElapsedGameTime.TotalSeconds;
                timeSpawnAgujeros += gameTime.ElapsedGameTime.TotalSeconds;
                timeSpawnEnergy += gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (timeChangeDifficulty  >= 15)
            {
                timeChangeDifficulty = 0;
                difficultyLevel++;
                
                if (cameraSpeed < 10)
                {
                    //cameraSpeed += 1;
                }
            }

            camara.pos.X += cameraSpeed;

            if (auto.isShooting && auto.shootCD <= 0)
            {
                auto.isShooting = false;

                switch (auto.buffLevel)
                {
                    case 5:
                        auto.shootCD = 0.07f;
                        break;
                    default:
                        auto.shootCD = 0.1f;
                        break;
                }

                switch (auto.buffLevel)
                {
                    case 1:
                        listaProyectiles.Add(new Proyectil("rayo", auto.objetoFisico.pos, 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        break;

                    case 2:
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        break;

                    case 3:
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, -25, -0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", auto.objetoFisico.pos, 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 25, 0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        break;
                    case 4:
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, -25, -0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 25, 0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        break;
                    case 5:
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, -25, -0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y - 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 0, 0, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        listaProyectiles.Add(new Proyectil("rayo", new Vector2(auto.objetoFisico.pos.X, auto.objetoFisico.pos.Y + 10), 50, 25, 0.3925f, 1, UTGameObject.FF_form.Rectangulo, false, false));
                        break;
                }
            }
            if (listaProyectiles.Count > 0)
            {

                if (listaProyectiles.First<Proyectil>().isDestroyed)
                {
                    listaProyectiles.Remove(listaProyectiles.First<Proyectil>());
                }
                else if (listaProyectiles.First<Proyectil>().objetoFisico.pos.X > camara.pos.X + 200 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2)
                {
                    listaProyectiles.First<Proyectil>().Destroy();
                    listaProyectiles.Remove(listaProyectiles.First<Proyectil>());
                }

                Console.WriteLine(listaProyectiles.Count);
            }

            if (auto.objetoFisico.isColliding && !collision_on)
            {
                collision_on = true;
                n_Choques++;
            }
            else if (!auto.objetoFisico.isColliding)
            {
                collision_on = false;
            }

            /*SPAWNERS*********************************************************************************************************************************************************/
            /*
            if (camara.pos.X % 400 == 0)
            {
                listaFondo.Add(new Background("fondo", new Vector2(camara.pos.X + 800 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2, camara.pos.Y + Game1.INSTANCE.GraphicsDevice.Viewport.Height), 2, UTGameObject.FF_form.Rectangulo, true,  false, true));
                listaFondo.Last<Background>().objetoFisico.isTrigger = true;
            }

            if (listaFondo.Count > 0)
            {
                if (listaFondo.First<Background>().objetoFisico.pos.X < camara.pos.X - 400)
                {
                    listaFondo.First<Background>().Destroy();
                    listaFondo.Remove(listaFondo.First<Background>());
                }
            }
            */
            if (timeSpawnAgujeros > 4f)
            {

                listaAgujeros.Add(new Agujero("black_hole", new Vector2(camara.pos.X + 600 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2, rnd.Next((int)camara.pos.Y + 200, (int)camara.pos.Y - 200 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2)), 1, UTGameObject.FF_form.Circulo, false));

                timeSpawnAgujeros = 0;
            }
            if (listaAgujeros.Count > 0)
            {
                if (listaAgujeros.First<Agujero>().objetoFisico.pos.X < camara.pos.X - 200)
                {
                    listaAgujeros.First<Agujero>().Destroy();
                    listaAgujeros.Remove(listaAgujeros.First<Agujero>());
                }
            }

            if (timeSpawnAsteroides > 1.2f / difficultyLevel)
            {
                listaAsteroides.Add(new Pelota("Asteroid", new Vector2(camara.pos.X + 600 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2, rnd.Next((int)camara.pos.Y + 200, (int)camara.pos.Y - 200 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2)), 0.3f, UTGameObject.FF_form.Circulo, false, true));
                timeSpawnAsteroides = 0;
            }
            if (listaAsteroides.Count > 0)
            {
                if (listaAsteroides.First<Pelota>().objetoFisico.pos.X < camara.pos.X - 200)
                {
                    listaAsteroides.First<Pelota>().Destroy();
                    listaAsteroides.Remove(listaAsteroides.First<Pelota>());
                }
            }

            if (timeSpawnEnergy > 5f)
            {
                posYEnergy = rnd.Next((int)camara.pos.Y + 200, (int)camara.pos.Y - 200 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2);
                listaEnergy.Add(new Coleccionable("energy", new Vector2(camara.pos.X + 600 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2, posYEnergy), 0.1f, UTGameObject.FF_form.Circulo, false));
                timeSpawnEnergy = 0;
            }        
            if (listaEnergy.Count > 0)
            {
                if (listaEnergy.First<Coleccionable>().objetoFisico.pos.X < camara.pos.X - 200)
                {
                    listaEnergy.First<Coleccionable>().Destroy();
                    listaEnergy.Remove(listaEnergy.First<Coleccionable>());
                }
            }
            /*SPAWNERS*********************************************************************************************************************************************************/

            //Verifica si es alcanzado por la cámara.
            if (auto.objetoFisico.pos.X < camara.pos.X)
            {
                if (!auto.invulnerable)
                {
                    auto.invulnerable = true;
                    auto.objetoFisico.pos = auto.Respawn();
                }
            }
            //Evita que salga por la parte izquierda cuando el auto es invulnerable.
            if (auto.invulnerable && auto.objetoFisico.pos.X <= camara.pos.X + 30)
            {
                auto.objetoFisico.pos = new Vector2(camara.pos.X + 30, auto.objetoFisico.pos.Y);
            }
            
            //Evita que salga por la parte derecha
            if (auto.objetoFisico.pos.X >= camara.pos.X - 30 + Game1.INSTANCE.GraphicsDevice.Viewport.Width*2)
            {
                auto.objetoFisico.pos = new Vector2(camara.pos.X - 30 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 2, auto.objetoFisico.pos.Y);
            }

            //Evita que el auto salga por la parte superior de la pantalla.
            if (auto.objetoFisico.pos.Y <= camara.pos.Y + 75)
            {
                auto.objetoFisico.pos = new Vector2(auto.objetoFisico.pos.X, camara.pos.Y + 75 );
            }
            
            //Evita que el auto salga por la parte inferior de la pantalla.
            if (auto.objetoFisico.pos.Y >= camara.pos.Y - 75 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2)
            {
                auto.objetoFisico.pos = new Vector2(auto.objetoFisico.pos.X, camara.pos.Y - 75 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2);
            }

            //Gana vidas cada 25 monedas recogidas (supuestamente)
            if (auto.powerUpTotales > 0 && auto.powerUpTotales%25 == 0)   
            {
                if (!ganoVidas) //Limita las vidas ganadas cada 25 monedas a 1.
                {
                    ganoVidas = true;
                    auto.vidas++;
                }
            }
            else if(ganoVidas)  
            {
                ganoVidas = false;
            }

            //Envia a la pantalla final si se acaban las vidas
            if (auto.vidas <= 0)
            {
                Game1.INSTANCE.ChangeScene(Game1.Scene.End);
            }

        }
        public void Draw (SpriteBatch SB)
        {
            Vector2 timerPos;
            Vector2 vidasPos;
            Vector2 powerUpPos;
            Vector2 scorePos;

            timerPos = new Vector2(50, 25);
            vidasPos = new Vector2((Game1.INSTANCE.GraphicsDevice.Viewport.Width) - 100,25);
            powerUpPos = new Vector2(Game1.INSTANCE.GraphicsDevice.Viewport.Width / 4f, 25);
            scorePos = new Vector2(Game1.INSTANCE.GraphicsDevice.Viewport.Width / 2f, 25);

            SB.Draw(timerIcon, timerPos, null, Color.White, 0f, new Vector2(0, 0), new Vector2(0.05f,0.05f), SpriteEffects.None, 1f);
            SB.Draw(vidasIcon, vidasPos, null, Color.White, 0f, new Vector2(0, 0), new Vector2(0.05f, 0.05f), SpriteEffects.None, 1f);
            SB.Draw(powerUpIcon, powerUpPos, null, Color.White, 0f, new Vector2(0, 0), new Vector2(0.05f, 0.05f), SpriteEffects.None, 1f);

            SB.DrawString(timer, "    " + Math.Round(time,2), timerPos, Color.White);
            SB.DrawString(vidasActuales, "     x " + Game1.INSTANCE.ventanaJuego.auto.vidas, vidasPos, Color.White);
            SB.DrawString(powerUpLevel, "    Energy lvl: " + Game1.INSTANCE.ventanaJuego.auto.buffLevel, powerUpPos, Color.White);
            SB.DrawString(puntajeTotal, "    Score: " + Game1.INSTANCE.ventanaJuego.score, scorePos, Color.White);
        }

    }
}
