//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FutureChess.Pieces
//{
//    class Horse_Piece : Base_Piece
//    {
//        public int BoardPositionX { get; set; } // The x position on the GameBoard
//        public int BoardPositionY { get; set; } // The y position on the GameBoard

//        public Horse_Piece(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY) :
//            base(texture, boardPositionX * texture.Width, boardPositionY * texture.Height, colorOverlay,
//                3, MoveTypes.CUSTOM, 2f, 1f, CustomMoveOrders.BOTH)
//        {
//            this.BoardPositionX = boardPositionX;
//            this.BoardPositionY = boardPositionY;
//        }

//        #region Alternative Solution
//        //public Horse_Piece(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY, float spaceBetweenTiles) :
//        //    base(texture, boardPositionX * spaceBetweenTiles, boardPositionY * spaceBetweenTiles, colorOverlay,
//        //        3, "CUSTOM", 2f, 1f, "BOTH")
//        //{
//        //    this.BoardPositionX = boardPositionX;
//        //    this.BoardPositionY = boardPositionY;
//        //}
//        #endregion Alternative Solution
//    }
//}