using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureChess.Board.Tiles
{
    class Void_Tile : Base_Tile
    {
        public int BoardPositionX { get; set; } // The x position on the GameBoard
        public int BoardPositionY { get; set; } // The y position on the GameBoard

        public Void_Tile(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY) :
            base(texture, boardPositionX * texture.Width, boardPositionY * texture.Height, colorOverlay, TileTypes.VOID)
        {
            this.BoardPositionX = boardPositionX;
            this.BoardPositionY = boardPositionY;
        }
    }
}