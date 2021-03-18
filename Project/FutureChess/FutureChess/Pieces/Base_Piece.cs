using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureChess.Pieces
{
    enum MoveTypes { UP, DOWN, LEFT, RIGHT, UDLR, DIAGONAL, ALL, CUSTOM, NONE }
    enum CustomMoveOrders { XY, YX, BOTH, NONE }
    class Base_Piece : GameObject
    {
        protected int maxMoveAmount; // Max number of moves the piece can move each turn
        protected MoveTypes allowedMoveType; // [UP, DOWN, LEFT, RIGHT UDLR, DIAGONAL, ALL, CUSTOM]
        protected Vector2 customMove; // Change in the (x, y) or (y, x) positions for the custom move ((2, 1) == Normal chess horse), ((0, 0) == No customMove)
        protected CustomMoveOrders customMoveOrder; // [XY, YX, BOTH, NONE] which order the vector can be used. ((XY) == Only x, y), ((YX) == Only y, x), ((BOTH) == Both x, y and y, x), ((NONE) == there's no customMove)
        protected PieceType pieceType;

        #region Old
        //protected int maxMoveAmount; // Max number of moves the piece can move each turn
        //protected string allowedMoveType; // [UP, DOWN, LEFT, RIGHT UDLR, DIAGONAL, ALL, CUSTOM]
        //protected Vector2 customMove; // Change in the (x, y) or (y, x) positions for the custom move ((2, 1) == Normal chess horse), ((0, 0) == No customMove)
        //protected string customMoveOrder; // [XY, YX, BOTH, NONE] which order the vector can be used. ((XY) == Only x, y), ((YX) == Only y, x), ((BOTH) == Both x, y and y, x), ((NONE) == there's no customMove)
        #endregion Old

        // Base_Piece() Constructor
        public Base_Piece(Texture2D texture, float xPos, float yPos, Color colorOverlay, int maxMoveAmount, MoveTypes allowedMoveType, float customMoveX, float customMoveY, CustomMoveOrders customMoveOrder, PieceType pieceType) : 
            base(texture, xPos, yPos, colorOverlay)
        {
            this.maxMoveAmount = maxMoveAmount;
            this.allowedMoveType = allowedMoveType;
            this.customMove.X = customMoveX;
            this.customMove.Y = customMoveY;
            this.customMoveOrder = customMoveOrder;
            this.pieceType = pieceType;
        }
    }
}
