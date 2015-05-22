using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Swarm
{
    /// <summary>
    /// Planet objects
    /// </summary>
    class Planet
    {
        #region Fields

        /// <summary>
        /// Fields
        /// </summary>

        bool active = true;

        // ship spawn support
        int startingShipNumber = 10;
        int maxShipNumber = 50;
        int shipProductionRate = 1000;
        int elapsedSpawnMilliseconds = 0;
        int shipNumber;
       

        //random generator for the class
        static Random rand = new Random();
        
        // drawing support
        Texture2D planetSprite;
        Rectangle drawRectangle;

        #endregion
     
        #region Constructors

        //testing planet
        public Planet(Texture2D planetSprite, int x, int y)
        {
            //sprite to use for planet image
            this.planetSprite = planetSprite;

            InitializeDrawRectangle(planetSprite, x, y);
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shipNumber">starting number of ships</param>
        /// <param name="maxShipNumber">max number of ships before spawning is disabled</param>
        /// <param name="shipProductionRate">number of milliseconds before new ship is spawned</param>
        /// <param name="planetSprite">sprite</param>
        /// <param name="x">x position of center</param>
        /// <param name="y">y position of center</param>
        public Planet(int shipNumber, int maxShipNumber, int shipProductionRate, Texture2D planetSprite, int x, int y) 
        {
            // Number of Ships orbiting planet at start
            this.startingShipNumber = 10;

            // maximum number of ships in orbit which disables further production
            this.maxShipNumber = 50;

            // milliseconds elaspsed before producing 1 ship if beneath max supply limit
            this.shipProductionRate = 1000;

            // total number of ships in orbit from start
            //int shipNumber = startingShipNumber + number of ships produced over time;

            //sprite to use for planet image
            this.planetSprite = planetSprite;

            InitializeDrawRectangle(planetSprite, x, y);

        }



        ////neutral planets
        //public Planet(int shipNumber, int maxShipNumber, int shipProductionRate, Texture2D planetSprite, int x, int y)
        //{
        //    // Number of Ships orbiting planet at start
        //    this.shipNumber = startingShipNumber;

        //    // maximum number of ships in orbit which disables further production
        //    this.maxShipNumber = maxShipNumber;

        //    // Number of ships per second produced if beneath max supply limit
        //    this.shipProductionRate = shipProductionRate;

        //    this.planetSprite = planetSprite;
        //    InitializeDrawRectangle(planetSprite, x, y);

        //    for (int i = shipNumber; i < maxShipNumber; i++)
        //    {
        //        //every second add one to shipNumber until shipNumber == maxShipNumber
        //    }
        //}
        #endregion

        #region Properties

        /// <Summary>
        /// gets and sets if ship spawning is active
        /// </Summary>
        public bool Active 
        {
            get { return active; }
            set { active = value; }
        }
        /// <Summary>
        ///gets draw rectangle
        /// </Summary>
        public Rectangle DrawRectangle 
        {
            get { return drawRectangle; }
        }

        /// <Summary>
        ///gets the number of ships in orbit at start
        /// </Summary>
        public int StartingShipNumber 
        {
            get { return startingShipNumber; } 
        }

        /// <Summary>
        ///gets the maximum ships in orbit for the planet
        /// </Summary>
        public int MaxShipNumber 
        {
            get { return maxShipNumber; }
        }


        #endregion

        #region Methods

       /// <summary>
       /// Updates the planet
       /// </summary>
       /// <param name="gameTime"></param>
        /// <param name="mouse"></param>
        public void Update(GameTime gameTime, MouseState mouse)
        {
            // spawn new ships
            elapsedSpawnMilliseconds += gameTime.ElapsedGameTime.Milliseconds;

            if (shipNumber > maxShipNumber) 
            {
                if (elapsedSpawnMilliseconds >= shipProductionRate)
                {
                    elapsedSpawnMilliseconds = 0;
                    
                    // spawn new ship
                    shipNumber++;
                }
            }

            // mouse hover and click support 
            // add code to display number of active ships and maxShipNumber when planet drawRectangle contains mouse pointer
            // add code to select number of ships with three click system first click activates 
            //second click distance from center of sprite = % of ships selected 
            //third click on other planet sends ships

        }

    
        /// <summary>
        /// Draws the planet
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(planetSprite, drawRectangle, Color.White);
            
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the planet
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="spriteName">the name of the sprite for the planet</param>
        /// <param name="x">the x location of the center of the planet</param>
        /// <param name="y">the y location of the center of the planet</param>
        private void LoadContent(ContentManager contentManager, string spriteName, 
            int x, int y)
        {
            // load content and set remainder of draw rectangle
            planetSprite = contentManager.Load<Texture2D>(spriteName);
            InitializeDrawRectangle(planetSprite, x, y);
            
        }
        
       

        /// <summary>
        /// Initializes the draw rectangle
        /// </summary>
        /// <param name="sprite">the sprite for the planet</param>
        /// <param name="x">the x location of the center of the planet</param>
        /// <param name="y">the y location of the center of the planet</param>
        private void InitializeDrawRectangle(Texture2D planetSprite, int x, int y)
        {
            drawRectangle = new Rectangle(x - planetSprite.Width / 2,
                y - planetSprite.Height / 2, planetSprite.Width,
                planetSprite.Height);
        }
        #endregion
    }
}
