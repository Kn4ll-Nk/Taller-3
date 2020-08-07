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

        SpriteFont main_menu;
        SpriteFont end_menu;


        public VentanaManager(ContentManager content)
        {        
            UTGameObjectsManager.Init();

            main_menu = content.Load<SpriteFont>("Main_menu");
            end_menu = content.Load<SpriteFont>("End_menu");

            

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
                    new Juego();
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
            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Start)
            {
                Vector2 main_menuPos = new Vector2(300, 300);
                SB.DrawString(main_menu, "jffdjksafhjkdanfjk", main_menuPos, Color.Black);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                Vector2 end_menuPos = new Vector2(300, 500);
                SB.DrawString(end_menu, "jfdjsiaofjdosaj", end_menuPos, Color.Black);       
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                Vector2 end_menuPos = new Vector2(400, 500);
                SB.DrawString(end_menu, "jfdjsiaofjdosaj", end_menuPos, Color.Black);
            }
         
        }
    }
}
