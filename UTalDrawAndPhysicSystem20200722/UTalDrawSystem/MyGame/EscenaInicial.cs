using Microsoft.Xna.Framework;
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
        UTGameObject playerUTG;
        Camara camara;

        Automovil auto;
        List<Coleccionable> listaMonedas; 

        bool click = false;
        bool seeC2;
        bool spacePressed;

        int n_Choques;
        bool collision_on;
        double time = 0;




        public Juego()
        {
            UTGameObjectsManager.Init();

            listaMonedas = new List<Coleccionable>();

            auto = new Automovil("Auto", new Vector2(450, 400), 4, UTGameObject.FF_form.Circulo);

            new UTGameObject("Muro2", new Vector2(300, 400), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(900, 400), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(300, 700), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(900, 700), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(300, 1000), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(900, 1000), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(300, 1300), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(1000, 1200), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(400, 1500), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(700, 1500), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(1000, 1500), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(1300, 1200), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(1300, 1500), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(1600, 1200), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(1600, 1500), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1800, 1200), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(1900, 1500), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(2200, 1500), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(2400, 1400), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(2400, 1100), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(2000, 900), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(2300, 900), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1400, 1000), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1400, 700), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(2000, 700), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1400, 400), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(2000, 400), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1400, 100), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(2000, 100), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro2", new Vector2(1400, -200), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro2", new Vector2(2000, -200), 1, UTGameObject.FF_form.Rectangulo, true);

            new UTGameObject("Muro", new Vector2(1550, -400), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(1850, -400), 1, UTGameObject.FF_form.Rectangulo, true);

            /*PELOTAS**************************************************************************************************/

            new UTGameObject("obstaculo", new Vector2(451.0252f, 692.5721f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(729.0478f, 694.5721f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(579.0478f, 926.7676f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(714.3812f, 1296.573f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1354.681f, 1409.677f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(2223.635f, 1377.104f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(2091.635f, 1231.104f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1905.635f, 1107.104f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(2241.635f, 1053.104f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1550.839f, 980.4282f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1673.601f, 816.618f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1865.601f, 670.618f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1525.601f, 648.618f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1709.601f, 512.3312f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1873.601f, 378.3312f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1551.601f, 356.3312f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1767.601f, 203.3781f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1569.601f, 127.3781f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1867.731f, -54.39938f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1709.731f, -64.39938f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1543.731f, -64.39938f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1615.731f, -256.3994f), 0.02f, UTGameObject.FF_form.Circulo, false);
            new UTGameObject("obstaculo", new Vector2(1801.731f, -2603994f), 0.02f, UTGameObject.FF_form.Circulo, false);

            /*MONEDAS*****************************************************************************************************************/


            listaMonedas.Add(new Coleccionable("moneda", new Vector2(740.2859f, 1054.476f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1576.667f, 1302.191f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(2234.863f, 1218.269f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1540.868f, 1087.637f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1547.633f, 820.8824f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1831.249f, 514.5972f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1565.249f, 504.5972f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1633.058f, 241.2628f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1775.82f, -178.2617f), .1f, UTGameObject.FF_form.Circulo));
            listaMonedas.Add(new Coleccionable("moneda", new Vector2(1637.82f, -176.2617f), .1f, UTGameObject.FF_form.Circulo));


      
            camara = new Camara(new Vector2(0, 0), .5f, 0);
            camara.HacerActiva();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            /*
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camara.pos += new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * 100f, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camara.pos += new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * 100f, 0);
            }
            */

            time = gameTime.TotalGameTime.Seconds;

            camara.pos.X = auto.objetoFisico.pos.X - (Game1.INSTANCE.GraphicsDevice.Viewport.Width);
            camara.pos.Y = auto.objetoFisico.pos.Y - (Game1.INSTANCE.GraphicsDevice.Viewport.Height);

            if (auto.objetoFisico.isColliding && !collision_on)
            {
                collision_on = true;
                n_Choques++;
            }
            else if (!auto.objetoFisico.isColliding)
            {
                collision_on = false;


            }
            if(auto.puntaje == 1)
            {
                Game1.INSTANCE.ChangeScene(Game1.Scene.End);
                
            }


            //Console.WriteLine(n_Choques);

            //Console.WriteLine(listaMonedas.LongCount());

            /*if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                new VentanaManager();
            }
            /*
            if(!click && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                click = true;

                playerUTG = new Coleccionable("moneda", Camara.ActiveCamera.PosMouseEnCamara(), .1f, UTGameObject.FF_form.Circulo);

                //Console.WriteLine("new Coleccionable('moneda', new Vector2 (" + playerUTG.objetoFisico.pos.X + "," + playerUTG.objetoFisico.pos.Y + "), .1f, UTGameObject.FF_form.Circulo);");
            }
            if(Mouse.GetState().LeftButton == ButtonState.Released)
            {
                click = false;
            }
            */
        }
    }
}
