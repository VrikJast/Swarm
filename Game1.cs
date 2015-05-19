using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Swarm
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        List<Texture2D> planetSprites = new List<Texture2D>(); 

        Random rand = new Random();

        MouseState mouse = Mouse.GetState();

        const int PLANET_NUMBER = 18;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;


            IsMouseVisible = true;
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

            // TODO: use this.Content to load your game content here
            //planetSprites.Add(Content.Load<Texture2D>("planet0"));
            //planetSprites.Add(Content.Load<Texture2D>("planet1")); 
            //planetSprites.Add(Content.Load<Texture2D>("planet2"));
            //planetSprites.Add(Content.Load<Texture2D>("planet3"));
            //planetSprites.Add(Content.Load<Texture2D>("planet4"));
            //planetSprites.Add(Content.Load<Texture2D>("planet5"));
            //planetSprites.Add(Content.Load<Texture2D>("planet6"));
            //planetSprites.Add(Content.Load<Texture2D>("planet7"));
            //planetSprites.Add(Content.Load<Texture2D>("planet8"));
            //planetSprites.Add(Content.Load<Texture2D>("planet9"));
            //planetSprites.Add(Content.Load<Texture2D>("planet10"));
            //planetSprites.Add(Content.Load<Texture2D>("planet11"));
            //planetSprites.Add(Content.Load<Texture2D>("planet12"));
            //planetSprites.Add(Content.Load<Texture2D>("planet13"));
            //planetSprites.Add(Content.Load<Texture2D>("planet14"));
            //planetSprites.Add(Content.Load<Texture2D>("planet15"));
            //planetSprites.Add(Content.Load<Texture2D>("planet16"));
            //planetSprites.Add(Content.Load<Texture2D>("planet17"));

            for (int i = 0; i < PLANET_NUMBER; i++)
            {
                planetSprites.Add(Content.Load<Texture2D>("planet" + i));
            }

            //Planet homePlanet = new Planet();
            //Planet neutralPlanet0 = new Planet(10, 10, 5000);
            //Planet neutralPlanet1 = new Planet(10, 10, 1000);
            //Planet neutralPlanet2 = new Planet(10, 50, 5000);
            //Planet enemyHomePlanet = new Planet();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            //GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //foreach (Texture2D planetSprite in planetSprites)
            //{
            //    planetSprite.Draw();
            //}

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
