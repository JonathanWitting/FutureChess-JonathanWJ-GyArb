using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureChess.Board.Tiles
{
    public enum TileTypes
    {
        GROUND, WALL, VOID
    }

    class Base_Tile : GameObject
    {
        protected TileTypes tileType;

        // Base_Tile() Constructor
        public Base_Tile(Texture2D texture, float xPos, float yPos, Color colorOverlay, TileTypes tileType) :
            base(texture, xPos, yPos, colorOverlay)
        {
            this.tileType = tileType;
        }
    }
}
