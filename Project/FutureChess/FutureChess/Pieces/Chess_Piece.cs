using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutureChess.Pieces
{
    enum PieceType { Tower, Horse, Knight, Queen, King, Pawn, NONE }
    class Chess_Piece : Base_Piece
    {
        public int BoardPositionX { get; set; } // The x position on the GameBoard
        public int BoardPositionY { get; set; } // The y position on the GameBoard

        public PieceType PieceType;

        public Chess_Piece(Texture2D texture, Color colorOverlay, int boardPositionX, int boardPositionY, PieceType pieceType) :
            base(texture, boardPositionX * texture.Width, boardPositionY * texture.Height, colorOverlay,
                0, MoveTypes.NONE, 0f, 0f, CustomMoveOrders.NONE, PieceType.NONE)
        {
            BoardPositionX = boardPositionX;
            BoardPositionY = boardPositionY;

            switch (pieceType)
            {
                case PieceType.Tower:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 8;
                    base.allowedMoveType = MoveTypes.UDLR;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                case PieceType.Horse:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 3;
                    base.allowedMoveType = MoveTypes.CUSTOM;
                    base.customMove.X = 2f;
                    base.customMove.Y = 1f;
                    base.customMoveOrder = CustomMoveOrders.BOTH;
                    break;
                case PieceType.Knight:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 8;
                    base.allowedMoveType = MoveTypes.DIAGONAL;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                case PieceType.Queen:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 8;
                    base.allowedMoveType = MoveTypes.ALL;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                case PieceType.King:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 1;
                    base.allowedMoveType = MoveTypes.ALL;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                case PieceType.Pawn:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 1;
                    base.allowedMoveType = MoveTypes.UP;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                case PieceType.NONE:
                    PieceType = pieceType;
                    base.pieceType = pieceType;
                    base.maxMoveAmount = 0;
                    base.allowedMoveType = MoveTypes.NONE;
                    base.customMove.X = 0f;
                    base.customMove.Y = 0f;
                    base.customMoveOrder = CustomMoveOrders.NONE;
                    break;
                default:
                    break;
            }
        }

        // Move the chess-piece to a new board-position
        public void MovePiece(int newBoardPositionX, int newBoardPositionY)
        {
            BoardPositionX = newBoardPositionX;
            BoardPositionY = newBoardPositionY;
            MoveTo(newBoardPositionX * texture.Width, newBoardPositionY * texture.Height);
        }
    }
}
