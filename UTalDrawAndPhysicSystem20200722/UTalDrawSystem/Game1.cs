using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using UTalDrawSystem.MyGame;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics { private set; get; }
        public SpriteBatch spriteBatch;

        VentanaManager ventanaInicio;
        VentanaManager ventanaFinal;
        VentanaManager ventanaCreditos;

        Texture2D imagenFondo;

        public Juego ventanaJuego;

        public enum Scene { Start, Game, End, Credits };

        public Scene ActiveScene = Scene.Start;

        public static Game1 INSTANCE;
        public Game1()
        {
            INSTANCE = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }
        public void ChangeScene(Scene newScene)
        {
            ActiveScene = newScene;

            if (ActiveScene == Scene.Start)
            {
                ventanaInicio = new VentanaManager(Content);
            }
            if (ActiveScene == Scene.Game)
            {
                ventanaJuego = new Juego(Content);
            }            
            if (ActiveScene == Scene.End)
            {
                ventanaFinal = new VentanaManager(Content);
            }
            if (ActiveScene == Scene.Credits)
            {
                ventanaCreditos = new VentanaManager(Content);
            }

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            imagenFondo = Content.Load<Texture2D>("space_intro");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ventanaInicio = new VentanaManager(Content);




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            //Console.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your update logic here
            Escena.INSTANCIA?.Update(gameTime);
            MotorFisico.Update(gameTime);
            UTGameObjectsManager.Update(gameTime);
            

            base.Update(gameTime);
            
        
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(imagenFondo, new Vector2(0,0), Color.White);

            Camara.ActiveCamera.Dibujar(spriteBatch);
            if(ActiveScene == Scene.Start)
            {
                ventanaInicio.Draw(spriteBatch);                
            }
            if(ActiveScene == Scene.Game)
            {
                ventanaJuego.Draw(spriteBatch);
                GraphicsDevice.Clear(Color.Black);

            }
            if (ActiveScene == Scene.End)
            {
                ventanaFinal.Draw(spriteBatch);
            }
            if(ActiveScene == Scene.Credits)
            {
                ventanaCreditos.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);


        }
    }
}
