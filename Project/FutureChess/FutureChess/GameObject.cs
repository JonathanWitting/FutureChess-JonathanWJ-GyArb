using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureChess
{
    class GameObject
    {
        #region Constants
        private float startAlignmentAddOn = 0f; // Distance to add to the texture from the top and left side
        #region FutureConstants
        //private float textureWidthMultiplier = 2f; // Change in the texture's width-size
        //private float textureHeightMultiplier = 2f; // Change in the texture's height-size
        #endregion FutureConstants
        #endregion Constants

        // Variables
        protected Texture2D texture; // Object Texture
        protected Vector2 position; // Object Position
        protected Color colorOverlay; // Object ColorOverlay
        protected Rectangle textureRectangle; // Object Rectangle

        // GameObject() Constructor
        public GameObject(Texture2D texture, float xPos, float yPos, Color colorOverlay)
        {
            this.texture = texture;
            this.position.X = xPos + startAlignmentAddOn;
            this.position.Y = yPos + startAlignmentAddOn;
            this.colorOverlay = colorOverlay;
            this.textureRectangle = new Rectangle((int)(xPos + startAlignmentAddOn), (int)(yPos + startAlignmentAddOn), texture.Width, texture.Height);
        }

        // Draw()
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, colorOverlay);
        }

        // Move(), Moves the object to a new position
        public void MoveTo(float newPositionX, float newPositionY)
        {
            position.X = newPositionX;
            position.Y = newPositionY;
            textureRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void ChangeColor(Color newColor)
        {
            colorOverlay = newColor;
        }

        // GameObject Characteristics
        public float xPosition { get { return position.X; } }
        public float yPosition { get { return position.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }
        public Rectangle TextureRectangle { get { return textureRectangle; } }
    }
}
