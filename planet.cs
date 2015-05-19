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
        int startingShipNumber = 10;
        int maxShipNumber = 50;
        int shipProductionRate = 1000;
        int shipNumber;
        int gameTimeElapsed = 0;

        //random generator for the class
        static Random rand = new Random();
        
        // drawing support
        Texture2D planetSprite;
        Rectangle drawRectangle;

        #endregion
     
        #region Constructors

        //starting home planet
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



        //neutral planets
        public Planet(int shipNumber, int maxShipNumber, int shipProductionRate, Texture2D planetSprite, int x, int y)
        {
            // Number of Ships orbiting planet at start
            this.shipNumber = startingShipNumber;

            // maximum number of ships in orbit which disables further production
            this.maxShipNumber = maxShipNumber;

            // Number of ships per second produced if beneath max supply limit
            this.shipProductionRate = shipProductionRate;

            this.planetSprite = planetSprite;
            InitializeDrawRectangle(planetSprite, x, y);

            for (int i = shipNumber; i < maxShipNumber; i++)
            {
                //every second add one to shipNumber until shipNumber == maxShipNumber
            }
        }
        #endregion

        #region Properties

        // gets the number of ships in orbit at start
        public int StartingShipNumber 
        {
            get { return startingShipNumber; } 
        }

        //gets the maximum ships in orbit for the planet
        public int MaxShipNumber 
        {
            get { return maxShipNumber; }
        }


        #endregion

        #region Methods
        
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
        private void InitializeDrawRectangle(Texture2D sprite, int x, int y)
        {
            drawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);
        }
    }
}
