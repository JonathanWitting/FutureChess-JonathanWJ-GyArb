//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FutureChess.Pieces
//{
//    class Queen_Piece : Base_Piece
//    {
//        public int BoardPositionX { get; set; } // The x position on the GameBoard
//        public int BoardPositionY { get; set; } // The y position on the GameBoard

//        public Queen_Piece(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY) :
//            base(texture, boardPositionX * texture.Width, boardPositionY * texture.Height, colorOverlay,
//                8, MoveTypes.ALL, 0f, 0f, CustomMoveOrders.NONE)
//        {
//            this.BoardPositionX = boardPositionX;
//            this.BoardPositionY = boardPositionY;
//        }

//        #region Alternative Solution
//        //public Queen_Piece(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY, float spaceBetweenTiles) :
//        //    base(texture, boardPositionX * spaceBetweenTiles, boardPositionY * spaceBetweenTiles, colorOverlay,
//        //        8, "ALL", 0f, 0f, "NONE")
//        //{
//        //    this.BoardPositionX = boardPositionX;
//        //    this.BoardPositionY = boardPositionY;
//        //}
//        #endregion Alternative Solution
//    }
//}
