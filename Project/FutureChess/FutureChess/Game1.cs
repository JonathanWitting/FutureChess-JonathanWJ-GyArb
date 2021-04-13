using FutureChess.Board.Tiles;
using FutureChess.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FutureChess
{
    // Buggar

    // boardGrid uppdateras inte altid
    // Player2 (Vit) kan inte döda med bönder innan bonden flyttats från spawn

    // Buggar

    // TODO

    // boardGrid uppdateras när en pjäs flyttas *
    // Att pjäser kan döda varandra *
    // Döda pjäser flyttas från brädet *

    // Adda resten av pjäsernas moves i GetPossiblePositions
    // Skapa funktion som kollar om någon av kungarna är i shack

    // TODO

    public class Game1 : Game
    {
        // Gets all the positions possible for the Chess_Piece
        private List<Vector2> GetPossiblePositions(Chess_Piece currentPiece, Dictionary<Vector2, gridTileTypes> boardGrid, playerIndex currentPlayer)
        {
            List<Vector2> allPossiblePositions = new List<Vector2>();

            if (currentPlayer == playerIndex.Player1)
            {
                switch (currentPiece.PieceType)
                {
                    case PieceType.Tower:
                        break;

                    case PieceType.Horse:
                        if (currentPiece.BoardPositionX + 2 <= 7 && currentPiece.BoardPositionY + 1 >= 0 && boardGrid[new Vector2(currentPiece.BoardPositionX + 2, currentPiece.BoardPositionY + 1)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 2, currentPiece.BoardPositionY + 1));
                        } // 2 Right, 1 Forward
                        if (currentPiece.BoardPositionX + 2 <= 7 && currentPiece.BoardPositionY - 1 >= 0 && boardGrid[new Vector2(currentPiece.BoardPositionX + 2, currentPiece.BoardPositionY - 1)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 2, currentPiece.BoardPositionY - 1));
                        } // 2 Right, 1 Backward

                        if (currentPiece.BoardPositionX - 2 >= 0 && currentPiece.BoardPositionY + 1 <= 7 && boardGrid[new Vector2(currentPiece.BoardPositionX - 2, currentPiece.BoardPositionY + 1)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 2, currentPiece.BoardPositionY + 1));
                        } // 2 Left, 1 Forward
                        if (currentPiece.BoardPositionX - 2 >= 0 && currentPiece.BoardPositionY - 1 >= 0 && boardGrid[new Vector2(currentPiece.BoardPositionX - 2, currentPiece.BoardPositionY - 1)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 2, currentPiece.BoardPositionY - 1));
                        } // 2 Left, 1 Backward

                        if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionY - 2 >= 0 && boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY - 2)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY - 2));
                        } // 1 Right, 2 Backward
                        if (currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY - 2 >= 0 && boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY - 2)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY - 2));
                        } // 1 Left, 2 Backward

                        if (currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY + 2 <= 7 && boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 2)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 2));
                        } // 1 Left, 2 Forward
                        if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionY + 2 <= 7 && boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 2)] != gridTileTypes.Player1)
                        {
                            allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 2));
                        } // 1 Right, 2 Forward
                        break;
                        
                    case PieceType.Knight:
                        break;
                    case PieceType.Queen:
                        break;
                    case PieceType.King:
                        break;

                    case PieceType.Pawn:
                        if (currentPiece.BoardPositionY == 1) // If the pawn hasn't moved since the game started
                        {
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 1)] == gridTileTypes.Empty
                                && boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 2)] == gridTileTypes.Empty)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 2));
                            } // 2 Forward
                        }

                        if (currentPiece.BoardPositionY + 1 <= 7)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 1)] == gridTileTypes.Empty)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 1));
                            } // 1 Forward

                        if (currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY + 1 <= 7)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 1)] == gridTileTypes.Player2)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 1));
                            } // 1 Left, 1 Forward

                        if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionY + 1 <= 7)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 1)] == gridTileTypes.Player2)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 1));
                            } // 1 Right, 1 Forward

                        //if (currentPiece.BoardPositionY + 1 <= 7 && currentPiece.BoardPositionY + 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 1)] == gridTileTypes.Empty)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY + 1));
                        //    } // 1 Forward

                        //if (currentPiece.BoardPositionX - 1 <= 7 && currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY - 1 <= 7 && currentPiece.BoardPositionY - 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 1)] == gridTileTypes.Player2)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 1));
                        //    } // 1 Left, 1 Forward

                        //if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionX + 1 >= 0 && currentPiece.BoardPositionY + 1 <= 7 && currentPiece.BoardPositionY + 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 1)] == gridTileTypes.Player2)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 1));
                        //    } // 1 Right, 1 Forward
                        break;

                    case PieceType.NONE:
                        break;
                    default:
                        break;
                }
            }

            if (currentPlayer == playerIndex.Player2)
            {
                switch (currentPiece.PieceType)
                {
                    case PieceType.Tower:
                        break;

                    case PieceType.Horse:
                        break;

                    case PieceType.Knight:
                        break;

                    case PieceType.Queen:
                        break;

                    case PieceType.King:
                        break;

                    case PieceType.Pawn:
                        if (currentPiece.BoardPositionY == 6) // If the pawn hasn't moved since the game started
                        {
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 1)] == gridTileTypes.Empty
                                && boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 2)] == gridTileTypes.Empty)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 2));
                            } // 2 Forward
                        }

                        if (currentPiece.BoardPositionY - 1 >= 0)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 1)] == gridTileTypes.Empty)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 1));
                            } // 1 Forward

                        if (currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY - 1 >= 0)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY - 1)] == gridTileTypes.Player1)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY - 1));
                            } // 1 Left, 1 Forward

                        if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionY - 1 >= 0)
                            if (boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY - 1)] == gridTileTypes.Player1)
                            {
                                allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY - 1));
                            } // 1 Right, 1 Forward

                        //if (currentPiece.BoardPositionY + 1 <= 7 && currentPiece.BoardPositionY - 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 1)] == gridTileTypes.Empty)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX, currentPiece.BoardPositionY - 1));
                        //    } // 1 Forward

                        //if (currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionX - 1 >= 0 && currentPiece.BoardPositionY - 1 < 7 && currentPiece.BoardPositionY - 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY - 1)] == gridTileTypes.Player1)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX - 1, currentPiece.BoardPositionY + 1));
                        //    } // 1 Left, 1 Forward

                        //if (currentPiece.BoardPositionX + 1 <= 7 && currentPiece.BoardPositionX + 1 >= 0 && currentPiece.BoardPositionY + 1 < 7 && currentPiece.BoardPositionY + 1 >= 0)
                        //    if (boardGrid[new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY - 1)] == gridTileTypes.Player1)
                        //    {
                        //        allPossiblePositions.Add(new Vector2(currentPiece.BoardPositionX + 1, currentPiece.BoardPositionY + 1));
                        //    } // 1 Right, 1 Forward
                        break;

                    case PieceType.NONE:
                        break;
                    default:
                        break;
                }
            }

            // Fill the list

            return allPossiblePositions;
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        // BoardTiles
        #region Map 1
        Board_Tile[] m1_Board_Tiles_Array; // Array with all of the Board_Tile objects for Map 1

        #region Tiles (0, 0) To (7, 0)
        Board_Tile m1_BoardTile_1;
        Board_Tile m1_BoardTile_2;
        Board_Tile m1_BoardTile_3;
        Board_Tile m1_BoardTile_4;
        Board_Tile m1_BoardTile_5;
        Board_Tile m1_BoardTile_6;
        Board_Tile m1_BoardTile_7;
        Board_Tile m1_BoardTile_8;
        #endregion Tiles (0, 0) To (7, 0)
        
        #region Tiles (0, 1) To (7, 1)
        Board_Tile m1_BoardTile_9;
        Board_Tile m1_BoardTile_10;
        Board_Tile m1_BoardTile_11;
        Board_Tile m1_BoardTile_12;
        Board_Tile m1_BoardTile_13;
        Board_Tile m1_BoardTile_14;
        Board_Tile m1_BoardTile_15;
        Board_Tile m1_BoardTile_16;
        #endregion Tiles (0, 1) To (7, 1)
        
        #region Tiles (0, 2) To (7, 2)
        Board_Tile m1_BoardTile_17;
        Board_Tile m1_BoardTile_18;
        Board_Tile m1_BoardTile_19;
        Board_Tile m1_BoardTile_20;
        Board_Tile m1_BoardTile_21;
        Board_Tile m1_BoardTile_22;
        Board_Tile m1_BoardTile_23;
        Board_Tile m1_BoardTile_24;
        #endregion Tiles (0, 2) To (7, 2)

        #region Tiles (0, 3) To (7, 3)
        Board_Tile m1_BoardTile_25;
        Board_Tile m1_BoardTile_26;
        Board_Tile m1_BoardTile_27;
        Board_Tile m1_BoardTile_28;
        Board_Tile m1_BoardTile_29;
        Board_Tile m1_BoardTile_30;
        Board_Tile m1_BoardTile_31;
        Board_Tile m1_BoardTile_32;
        #endregion Tiles (0, 3) To (7, 3)
        
        #region Tiles (0, 4) To (7, 4)
        Board_Tile m1_BoardTile_33;
        Board_Tile m1_BoardTile_34;
        Board_Tile m1_BoardTile_35;
        Board_Tile m1_BoardTile_36;
        Board_Tile m1_BoardTile_37;
        Board_Tile m1_BoardTile_38;
        Board_Tile m1_BoardTile_39;
        Board_Tile m1_BoardTile_40;
        #endregion Tiles (0, 4) To (7, 4)
        
        #region Tiles (0, 5) To (7, 5)
        Board_Tile m1_BoardTile_41;
        Board_Tile m1_BoardTile_42;
        Board_Tile m1_BoardTile_43;
        Board_Tile m1_BoardTile_44;
        Board_Tile m1_BoardTile_45;
        Board_Tile m1_BoardTile_46;
        Board_Tile m1_BoardTile_47;
        Board_Tile m1_BoardTile_48;
        #endregion Tiles (0, 5) To (7, 5)
        
        #region Tiles (0, 6) To (7, 6)
        Board_Tile m1_BoardTile_49;
        Board_Tile m1_BoardTile_50;
        Board_Tile m1_BoardTile_51;
        Board_Tile m1_BoardTile_52;
        Board_Tile m1_BoardTile_53;
        Board_Tile m1_BoardTile_54;
        Board_Tile m1_BoardTile_55;
        Board_Tile m1_BoardTile_56;
        #endregion Tiles (0, 6) To (7, 6)
        
        #region Tiles (0, 7) To (7, 7)
        Board_Tile m1_BoardTile_57;
        Board_Tile m1_BoardTile_58;
        Board_Tile m1_BoardTile_59;
        Board_Tile m1_BoardTile_60;
        Board_Tile m1_BoardTile_61;
        Board_Tile m1_BoardTile_62;
        Board_Tile m1_BoardTile_63;
        Board_Tile m1_BoardTile_64;
        #endregion Tiles (0, 7) To (7, 7)
        #endregion Map 1

        // Pieces
        #region Pieces
        #region Player 1
        Chess_Piece p1_KingPiece; // Player1, King_Piece
        Chess_Piece p1_QueenPiece; // Player1 Queen_Piece
        Chess_Piece p1_KnightPiece_1; // Player1 Knight_Piece
        Chess_Piece p1_KnightPiece_2; // Player1 Knight_Piece
        Chess_Piece p1_HorsePiece_1; // Player1 Horse_Piece
        Chess_Piece p1_HorsePiece_2; // Player1 Horse_Piece
        Chess_Piece p1_TowerPiece_1; // Player1 Tower_Piece
        Chess_Piece p1_TowerPiece_2; // Player1 Tower_Piece
        Chess_Piece p1_PawnPiece_1; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_2; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_3; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_4; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_5; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_6; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_7; // Player1 Pawn_Piece
        Chess_Piece p1_PawnPiece_8; // Player1 Pawn_Piece

        Dictionary<Vector2, Chess_Piece> p1_Pieces_Dictionary;
        #endregion Player 1
        
        #region Player 2
        Chess_Piece p2_KingPiece; // Player1, King_Piece
        Chess_Piece p2_QueenPiece; // Player1 Queen_Piece
        Chess_Piece p2_KnightPiece_1; // Player1 Knight_Piece
        Chess_Piece p2_KnightPiece_2; // Player1 Knight_Piece
        Chess_Piece p2_HorsePiece_1; // Player1 Horse_Piece
        Chess_Piece p2_HorsePiece_2; // Player1 Horse_Piece
        Chess_Piece p2_TowerPiece_1; // Player1 Tower_Piece
        Chess_Piece p2_TowerPiece_2; // Player1 Tower_Piece
        Chess_Piece p2_PawnPiece_1; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_2; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_3; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_4; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_5; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_6; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_7; // Player1 Pawn_Piece
        Chess_Piece p2_PawnPiece_8; // Player1 Pawn_Piece

        Dictionary<Vector2, Chess_Piece> p2_Pieces_Dictionary;
        #endregion Player 2
        #endregion Pieces

        // Update
        #region Update Constants, Variables
        // Constants
        enum gridTileTypes { Player1, Player2, Empty }
        enum playerIndex { Player1, Player2 }
        Color highlightColor = Color.Gray;
        // Variables
        int p1_deathPositionX = 10;
        int p1_deathPositionY = 0;
        int p2_deathPositionX = 10;
        int p2_deathPositionY = 7;
        int p1_deadAmount = 0;
        int p2_deadAmount = 0;

        #region Input
        MouseState currentMouseState;
        MouseState lastMouseState;
        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;
        #endregion Input
        Dictionary<Vector2, gridTileTypes> boardGrid_Dictionary;
        playerIndex currentPlayer;
        bool isPieceSelected;
        bool noNewSelectedPiece;
        Vector2 selectedPiecePosition;
        Vector2 selectedNewPosition;
        List<Vector2> possibleNewPositions;
        #endregion Update Constants, Variables

        // Paths
        string PATH_BOARDTILES;
        string PATH_PIECES;

        // Constants
        float SPACEBETWEENTILES = 164f;
        Vector2 POSITIONTEXT = new Vector2(1600, 540);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            // Sets the window's width-size to fullscreen
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; //_graphics.PreferredBackBufferWidth = 1920;
            // Sets the window's height-size to fullscreen
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; //_graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            #region Graphics Settings
            //_graphics.IsFullScreen = true; // Makes the window fullscreen
            _graphics.ApplyChanges();
            #endregion Graphics Settings

            #region Update Variables
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();

            // Initialize the BoardGrid for Map 1
            boardGrid_Dictionary = new Dictionary<Vector2, gridTileTypes>()
            {
                { new Vector2(0, 0), gridTileTypes.Player1 }, // Player1 : Tower1
                { new Vector2(1, 0), gridTileTypes.Player1 }, // Player1 : Horse1
                { new Vector2(2, 0), gridTileTypes.Player1 }, // Player1 : Knight1
                { new Vector2(3, 0), gridTileTypes.Player1 }, // Player1 : King
                { new Vector2(4, 0), gridTileTypes.Player1 }, // Player1 : Queen
                { new Vector2(5, 0), gridTileTypes.Player1 }, // Player1 : Knight2
                { new Vector2(6, 0), gridTileTypes.Player1 }, // Player1 : Horse2
                { new Vector2(7, 0), gridTileTypes.Player1 }, // Player1 : Tower2

                { new Vector2(0, 1), gridTileTypes.Player1 }, // Player1 : Pawn1
                { new Vector2(1, 1), gridTileTypes.Player1 }, // Player1 : Pawn2
                { new Vector2(2, 1), gridTileTypes.Player1 }, // Player1 : Pawn3
                { new Vector2(3, 1), gridTileTypes.Player1 }, // Player1 : Pawn4
                { new Vector2(4, 1), gridTileTypes.Player1 }, // Player1 : Pawn5
                { new Vector2(5, 1), gridTileTypes.Player1 }, // Player1 : Pawn6
                { new Vector2(6, 1), gridTileTypes.Player1 }, // Player1 : Pawn7
                { new Vector2(7, 1), gridTileTypes.Player1 }, // Player1 : Pawn8

                { new Vector2(0, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(1, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(2, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(3, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(4, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(5, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(6, 2), gridTileTypes.Empty }, // Empty
                { new Vector2(7, 2), gridTileTypes.Empty }, // Empty
                
                { new Vector2(0, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(1, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(2, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(3, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(4, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(5, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(6, 3), gridTileTypes.Empty }, // Empty
                { new Vector2(7, 3), gridTileTypes.Empty }, // Empty

                { new Vector2(0, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(1, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(2, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(3, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(4, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(5, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(6, 4), gridTileTypes.Empty }, // Empty
                { new Vector2(7, 4), gridTileTypes.Empty }, // Empty
                
                { new Vector2(0, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(1, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(2, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(3, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(4, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(5, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(6, 5), gridTileTypes.Empty }, // Empty
                { new Vector2(7, 5), gridTileTypes.Empty }, // Empty

                { new Vector2(0, 6), gridTileTypes.Player2 }, // Player2 : Pawn1
                { new Vector2(1, 6), gridTileTypes.Player2 }, // Player2 : Pawn2
                { new Vector2(2, 6), gridTileTypes.Player2 }, // Player2 : Pawn3
                { new Vector2(3, 6), gridTileTypes.Player2 }, // Player2 : Pawn4
                { new Vector2(4, 6), gridTileTypes.Player2 }, // Player2 : Pawn5
                { new Vector2(5, 6), gridTileTypes.Player2 }, // Player2 : Pawn6
                { new Vector2(6, 6), gridTileTypes.Player2 }, // Player2 : Pawn7
                { new Vector2(7, 6), gridTileTypes.Player2 }, // Player2 : Pawn8

                { new Vector2(0, 7), gridTileTypes.Player1 }, // Player2 : Tower1
                { new Vector2(1, 7), gridTileTypes.Player1 }, // Player2 : Horse1
                { new Vector2(2, 7), gridTileTypes.Player1 }, // Player2 : Knight1
                { new Vector2(3, 7), gridTileTypes.Player1 }, // Player2 : King
                { new Vector2(4, 7), gridTileTypes.Player1 }, // Player2 : Queen
                { new Vector2(5, 7), gridTileTypes.Player1 }, // Player2 : Knight2
                { new Vector2(6, 7), gridTileTypes.Player1 }, // Player2 : Horse2
                { new Vector2(7, 7), gridTileTypes.Player1 }, // Player2 : Tower2
            };

            isPieceSelected = false;
            selectedPiecePosition = new Vector2(0, 0);
            selectedNewPosition = new Vector2(0, 0);
            currentPlayer = playerIndex.Player1;
            #endregion Update Variables

            #region Paths
            PATH_BOARDTILES = "Images/BoardTiles/";
            PATH_PIECES = "Images/Pieces/";
            #endregion Paths

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/textFontFC");

            // TODO: use this.Content to load your game content here
            // Board Tiles
            #region Map 1
            #region Tiles (0, 0) To (7, 0)
            m1_BoardTile_1 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 0, 0, TileTypes.GROUND);
            m1_BoardTile_2 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 1, 0, TileTypes.GROUND);
            m1_BoardTile_3 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 2, 0, TileTypes.GROUND);
            m1_BoardTile_4 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 3, 0, TileTypes.GROUND);
            m1_BoardTile_5 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 4, 0, TileTypes.GROUND);
            m1_BoardTile_6 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 5, 0, TileTypes.GROUND);
            m1_BoardTile_7 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 6, 0, TileTypes.GROUND);
            m1_BoardTile_8 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 7, 0, TileTypes.GROUND);
            #endregion Tiles (0, 0) To (7, 0)
            
            #region Tiles (0, 1) To (7, 1)
            m1_BoardTile_9 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 0, 1, TileTypes.GROUND);
            m1_BoardTile_10 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 1, 1, TileTypes.GROUND);
            m1_BoardTile_11 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 2, 1, TileTypes.GROUND);
            m1_BoardTile_12 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 3, 1, TileTypes.GROUND);
            m1_BoardTile_13 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 4, 1, TileTypes.GROUND);
            m1_BoardTile_14 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 5, 1, TileTypes.GROUND);
            m1_BoardTile_15 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 6, 1, TileTypes.GROUND);
            m1_BoardTile_16 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 7, 1, TileTypes.GROUND);
            #endregion Tiles (0, 1) To (7, 1)
            
            #region Tiles (0, 2) To (7, 2)
            m1_BoardTile_17 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 0, 2, TileTypes.GROUND);
            m1_BoardTile_18 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 1, 2, TileTypes.GROUND);
            m1_BoardTile_19 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 2, 2, TileTypes.GROUND);
            m1_BoardTile_20 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 3, 2, TileTypes.GROUND);
            m1_BoardTile_21 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 4, 2, TileTypes.GROUND);
            m1_BoardTile_22 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 5, 2, TileTypes.GROUND);
            m1_BoardTile_23 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 6, 2, TileTypes.GROUND);
            m1_BoardTile_24 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 7, 2, TileTypes.GROUND);
            #endregion Tiles (0, 2) To (7, 2)
            
            #region Tiles (0, 3) To (7, 3)
            m1_BoardTile_25 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 0, 3, TileTypes.GROUND);
            m1_BoardTile_26 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 1, 3, TileTypes.GROUND);
            m1_BoardTile_27 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 2, 3, TileTypes.GROUND);
            m1_BoardTile_28 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 3, 3, TileTypes.GROUND);
            m1_BoardTile_29 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 4, 3, TileTypes.GROUND);
            m1_BoardTile_30 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 5, 3, TileTypes.GROUND);
            m1_BoardTile_31 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 6, 3, TileTypes.GROUND);
            m1_BoardTile_32 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 7, 3, TileTypes.GROUND);
            #endregion Tiles (0, 3) To (7, 3)
            
            #region Tiles (0, 4) To (7, 4)
            m1_BoardTile_33 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 0, 4, TileTypes.GROUND);
            m1_BoardTile_34 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 1, 4, TileTypes.GROUND);
            m1_BoardTile_35 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 2, 4, TileTypes.GROUND);
            m1_BoardTile_36 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 3, 4, TileTypes.GROUND);
            m1_BoardTile_37 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 4, 4, TileTypes.GROUND);
            m1_BoardTile_38 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 5, 4, TileTypes.GROUND);
            m1_BoardTile_39 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 6, 4, TileTypes.GROUND);
            m1_BoardTile_40 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 7, 4, TileTypes.GROUND);
            #endregion Tiles (0, 4) To (7, 4)
            
            #region Tiles (0, 5) To (7, 5)
            m1_BoardTile_41 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 0, 5, TileTypes.GROUND);
            m1_BoardTile_42 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 1, 5, TileTypes.GROUND);
            m1_BoardTile_43 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 2, 5, TileTypes.GROUND);
            m1_BoardTile_44 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 3, 5, TileTypes.GROUND);
            m1_BoardTile_45 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 4, 5, TileTypes.GROUND);
            m1_BoardTile_46 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 5, 5, TileTypes.GROUND);
            m1_BoardTile_47 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 6, 5, TileTypes.GROUND);
            m1_BoardTile_48 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 7, 5, TileTypes.GROUND);
            #endregion Tiles (0, 5) To (7, 5)
            
            #region Tiles (0, 6) To (7, 6)
            m1_BoardTile_49 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 0, 6, TileTypes.GROUND);
            m1_BoardTile_50 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 1, 6, TileTypes.GROUND);
            m1_BoardTile_51 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 2, 6, TileTypes.GROUND);
            m1_BoardTile_52 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 3, 6, TileTypes.GROUND);
            m1_BoardTile_53 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 4, 6, TileTypes.GROUND);
            m1_BoardTile_54 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 5, 6, TileTypes.GROUND);
            m1_BoardTile_55 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 6, 6, TileTypes.GROUND);
            m1_BoardTile_56 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 7, 6, TileTypes.GROUND);
            #endregion Tiles (0, 6) To (7, 6)
            
            #region Tiles (0, 7) To (7, 7)
            m1_BoardTile_57 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 0, 7, TileTypes.GROUND);
            m1_BoardTile_58 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 1, 7, TileTypes.GROUND);
            m1_BoardTile_59 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 2, 7, TileTypes.GROUND);
            m1_BoardTile_60 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 3, 7, TileTypes.GROUND);
            m1_BoardTile_61 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 4, 7, TileTypes.GROUND);
            m1_BoardTile_62 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 5, 7, TileTypes.GROUND);
            m1_BoardTile_63 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalDarkTile"), Color.White, 6, 7, TileTypes.GROUND);
            m1_BoardTile_64 = new Board_Tile(Content.Load<Texture2D>(PATH_BOARDTILES + "normalLightTile"), Color.White, 7, 7, TileTypes.GROUND);
            #endregion Tiles (0, 7) To (7, 7)

            m1_Board_Tiles_Array = new Board_Tile[64]
            {
                m1_BoardTile_1, m1_BoardTile_2, m1_BoardTile_3, m1_BoardTile_4, m1_BoardTile_5, m1_BoardTile_6, m1_BoardTile_7, m1_BoardTile_8,
                m1_BoardTile_9, m1_BoardTile_10, m1_BoardTile_11, m1_BoardTile_12, m1_BoardTile_13, m1_BoardTile_14, m1_BoardTile_15, m1_BoardTile_16,
                m1_BoardTile_17, m1_BoardTile_18, m1_BoardTile_19, m1_BoardTile_20, m1_BoardTile_21, m1_BoardTile_22, m1_BoardTile_23, m1_BoardTile_24,
                m1_BoardTile_25, m1_BoardTile_26, m1_BoardTile_27, m1_BoardTile_28, m1_BoardTile_29, m1_BoardTile_30, m1_BoardTile_31, m1_BoardTile_32,
                m1_BoardTile_33, m1_BoardTile_34, m1_BoardTile_35, m1_BoardTile_36, m1_BoardTile_37, m1_BoardTile_38, m1_BoardTile_39, m1_BoardTile_40,
                m1_BoardTile_41, m1_BoardTile_42, m1_BoardTile_43, m1_BoardTile_44, m1_BoardTile_45, m1_BoardTile_46, m1_BoardTile_47, m1_BoardTile_48,
                m1_BoardTile_49, m1_BoardTile_50, m1_BoardTile_51, m1_BoardTile_52, m1_BoardTile_53, m1_BoardTile_54, m1_BoardTile_55, m1_BoardTile_56,
                m1_BoardTile_57, m1_BoardTile_58, m1_BoardTile_59, m1_BoardTile_60, m1_BoardTile_61, m1_BoardTile_62, m1_BoardTile_63, m1_BoardTile_64,
            };
            #endregion Map 1

            // Load Pieces
            #region Player 1
            p1_TowerPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPiece"), Color.White, 0, 0, PieceType.Tower);
            p1_HorsePiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePiece"), Color.White, 1, 0, PieceType.Horse);
            p1_KnightPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPiece"), Color.White, 2, 0, PieceType.Knight);
            p1_KingPiece = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "kingPiece"), Color.White, 3, 0, PieceType.King);
            p1_QueenPiece = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "queenPiece"), Color.White, 4, 0, PieceType.Queen);
            p1_KnightPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPiece"), Color.White, 5, 0, PieceType.Knight);
            p1_HorsePiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePiece"), Color.White, 6, 0, PieceType.Horse);
            p1_TowerPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPiece"), Color.White, 7, 0, PieceType.Tower);

            p1_PawnPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 0, 1, PieceType.Pawn);
            p1_PawnPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 1, 1, PieceType.Pawn);
            p1_PawnPiece_3 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 2, 1, PieceType.Pawn);
            p1_PawnPiece_4 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 3, 1, PieceType.Pawn);
            p1_PawnPiece_5 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 4, 1, PieceType.Pawn);
            p1_PawnPiece_6 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 5, 1, PieceType.Pawn);
            p1_PawnPiece_7 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 6, 1, PieceType.Pawn);
            p1_PawnPiece_8 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 7, 1, PieceType.Pawn);

            p1_Pieces_Dictionary = new Dictionary<Vector2, Chess_Piece>()
            {
                { new Vector2(p1_TowerPiece_1.xPosition, p1_TowerPiece_1.yPosition), p1_TowerPiece_1 },
                { new Vector2(p1_HorsePiece_1.xPosition, p1_HorsePiece_1.yPosition), p1_HorsePiece_1 },
                { new Vector2(p1_KnightPiece_1.xPosition, p1_KnightPiece_1.yPosition), p1_KnightPiece_1 },
                { new Vector2(p1_KingPiece.xPosition, p1_KingPiece.yPosition), p1_KingPiece },
                { new Vector2(p1_QueenPiece.xPosition, p1_QueenPiece.yPosition), p1_QueenPiece },
                { new Vector2(p1_KnightPiece_2.xPosition, p1_KnightPiece_2.yPosition), p1_KnightPiece_2 },
                { new Vector2(p1_HorsePiece_2.xPosition, p1_HorsePiece_2.yPosition), p1_HorsePiece_2 },
                { new Vector2(p1_TowerPiece_2.xPosition, p1_TowerPiece_2.yPosition), p1_TowerPiece_2 },

                { new Vector2(p1_PawnPiece_1.xPosition, p1_PawnPiece_1.yPosition), p1_PawnPiece_1 },
                { new Vector2(p1_PawnPiece_2.xPosition, p1_PawnPiece_2.yPosition), p1_PawnPiece_2 },
                { new Vector2(p1_PawnPiece_3.xPosition, p1_PawnPiece_3.yPosition), p1_PawnPiece_3 },
                { new Vector2(p1_PawnPiece_4.xPosition, p1_PawnPiece_4.yPosition), p1_PawnPiece_4 },
                { new Vector2(p1_PawnPiece_5.xPosition, p1_PawnPiece_5.yPosition), p1_PawnPiece_5 },
                { new Vector2(p1_PawnPiece_6.xPosition, p1_PawnPiece_6.yPosition), p1_PawnPiece_6 },
                { new Vector2(p1_PawnPiece_7.xPosition, p1_PawnPiece_7.yPosition), p1_PawnPiece_7 },
                { new Vector2(p1_PawnPiece_8.xPosition, p1_PawnPiece_8.yPosition), p1_PawnPiece_8 },
            };
            #endregion Player 1
            
            #region Player 2
            p2_TowerPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPieceW"), Color.White, 0, 7, PieceType.Tower);
            p2_HorsePiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePieceW"), Color.White, 1, 7, PieceType.Horse);
            p2_KnightPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPieceW"), Color.White, 2, 7, PieceType.Knight);
            p2_KingPiece = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "kingPieceW"), Color.White, 3, 7, PieceType.King);
            p2_QueenPiece = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "queenPieceW"), Color.White, 4, 7, PieceType.Queen);
            p2_KnightPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPieceW"), Color.White, 5, 7, PieceType.Knight);
            p2_HorsePiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePieceW"), Color.White, 6, 7, PieceType.Horse);
            p2_TowerPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPieceW"), Color.White, 7, 7, PieceType.Tower);

            p2_PawnPiece_1 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 0, 6, PieceType.Pawn);
            p2_PawnPiece_2 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 1, 6, PieceType.Pawn);
            p2_PawnPiece_3 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 2, 6, PieceType.Pawn);
            p2_PawnPiece_4 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 3, 6, PieceType.Pawn);
            p2_PawnPiece_5 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 4, 6, PieceType.Pawn);
            p2_PawnPiece_6 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 5, 6, PieceType.Pawn);
            p2_PawnPiece_7 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 6, 6, PieceType.Pawn);
            p2_PawnPiece_8 = new Chess_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPieceW"), Color.White, 7, 6, PieceType.Pawn);

            p2_Pieces_Dictionary = new Dictionary<Vector2, Chess_Piece>()
            {
                { new Vector2(p2_TowerPiece_1.xPosition, p2_TowerPiece_1.yPosition), p2_TowerPiece_1 },
                { new Vector2(p2_HorsePiece_1.xPosition, p2_HorsePiece_1.yPosition), p2_HorsePiece_1 },
                { new Vector2(p2_KnightPiece_1.xPosition, p2_KnightPiece_1.yPosition), p2_KnightPiece_1 },
                { new Vector2(p2_KingPiece.xPosition, p2_KingPiece.yPosition), p2_KingPiece },
                { new Vector2(p2_QueenPiece.xPosition, p2_QueenPiece.yPosition), p2_QueenPiece },
                { new Vector2(p2_KnightPiece_2.xPosition, p2_KnightPiece_2.yPosition), p2_KnightPiece_2 },
                { new Vector2(p2_HorsePiece_2.xPosition, p2_HorsePiece_2.yPosition), p2_HorsePiece_2 },
                { new Vector2(p2_TowerPiece_2.xPosition, p2_TowerPiece_2.yPosition), p2_TowerPiece_2 },

                { new Vector2(p2_PawnPiece_1.xPosition, p2_PawnPiece_1.yPosition), p2_PawnPiece_1 },
                { new Vector2(p2_PawnPiece_2.xPosition, p2_PawnPiece_2.yPosition), p2_PawnPiece_2 },
                { new Vector2(p2_PawnPiece_3.xPosition, p2_PawnPiece_3.yPosition), p2_PawnPiece_3 },
                { new Vector2(p2_PawnPiece_4.xPosition, p2_PawnPiece_4.yPosition), p2_PawnPiece_4 },
                { new Vector2(p2_PawnPiece_5.xPosition, p2_PawnPiece_5.yPosition), p2_PawnPiece_5 },
                { new Vector2(p2_PawnPiece_6.xPosition, p2_PawnPiece_6.yPosition), p2_PawnPiece_6 },
                { new Vector2(p2_PawnPiece_7.xPosition, p2_PawnPiece_7.yPosition), p2_PawnPiece_7 },
                { new Vector2(p2_PawnPiece_8.xPosition, p2_PawnPiece_8.yPosition), p2_PawnPiece_8 },
            };
            #endregion Player 2

            #region Alternative Solution (Declaration)
            //p1_TowerPiece_1 = new Tower_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPiece"), Color.White, 0, 0, SPACEBETWEENTILES);
            //p1_HorsePiece_1 = new Horse_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePiece"), Color.White, 1, 0, SPACEBETWEENTILES);
            //p1_KnightPiece_1 = new Knight_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPiece"), Color.White, 2, 0, SPACEBETWEENTILES);
            //p1_KingPiece = new King_Piece(Content.Load<Texture2D>(PATH_PIECES + "kingPiece"), Color.White, 3, 0, SPACEBETWEENTILES);
            //p1_QueenPiece = new Queen_Piece(Content.Load<Texture2D>(PATH_PIECES + "queenPiece"), Color.White, 4, 0, SPACEBETWEENTILES);
            //p1_KnightPiece_2 = new Knight_Piece(Content.Load<Texture2D>(PATH_PIECES + "knightPiece"), Color.White, 5, 0, SPACEBETWEENTILES);
            //p1_HorsePiece_2 = new Horse_Piece(Content.Load<Texture2D>(PATH_PIECES + "horsePiece"), Color.White, 6, 0, SPACEBETWEENTILES);
            //p1_TowerPiece_2 = new Tower_Piece(Content.Load<Texture2D>(PATH_PIECES + "towerPiece"), Color.White, 7, 0, SPACEBETWEENTILES);

            //p1_PawnPiece_1 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 0, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_2 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 1, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_3 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 2, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_4 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 3, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_5 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 4, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_6 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 5, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_7 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 6, 1, SPACEBETWEENTILES);
            //p1_PawnPiece_8 = new Pawn_Piece(Content.Load<Texture2D>(PATH_PIECES + "pawnPiece"), Color.White, 7, 1, SPACEBETWEENTILES);
            #endregion Alternative Solution (Declaration)
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            lastMouseState = currentMouseState;
            lastKeyboardState = currentKeyboardState;
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();

            // TESTING
            //Vector2 testVector2 = new Vector2(0, 0);

            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                // Check if a piece has been selected and then move it if possible
                if (isPieceSelected)
                {
                    noNewSelectedPiece = true;

                    // Check if the player is trying to select a new piece or move the current selectedPiece
                    // Check which player's turn it is
                    if (currentPlayer == playerIndex.Player1)
                    {
                        // Check if the click was meant to select a Piece
                        foreach (KeyValuePair<Vector2, Chess_Piece> cPiece in p1_Pieces_Dictionary)
                        {
                            if (cPiece.Value.TextureRectangle.Contains(currentMouseState.X, currentMouseState.Y))
                            {
                                isPieceSelected = true;
                                noNewSelectedPiece = false; // There was already a slectedPiece so the player clicked on another new piece

                                // Reset the color of the BoardTile behind the selectedPiece color (Remove the highlight)
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(Color.White);
                                    }
                                }

                                selectedPiecePosition = cPiece.Key; // Update the currently selectedPiece's position as the selectedPiecePosition

                                // Change the BoardTile behind the selectedPiece to the highlight color
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(highlightColor);
                                    }
                                }
                                // Get a list of all the possible positions
                                possibleNewPositions = GetPossiblePositions(p1_Pieces_Dictionary[selectedPiecePosition], boardGrid_Dictionary, currentPlayer);
                            };
                        }
                    }

                    else if (currentPlayer == playerIndex.Player2)
                    {
                        // Check if the click was meant to select a Piece
                        foreach (KeyValuePair<Vector2, Chess_Piece> cPiece in p2_Pieces_Dictionary)
                        {
                            if (cPiece.Value.TextureRectangle.Contains(currentMouseState.X, currentMouseState.Y))
                            {
                                isPieceSelected = true;
                                noNewSelectedPiece = false; // There was already a slectedPiece so the player clicked on another new piece

                                // Reset the color of the BoardTile behind the selectedPiece color (Remove the highlight)
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(Color.White);
                                    }
                                }

                                selectedPiecePosition = cPiece.Key; // Update the currently selectedPiece's position as the selectedPiecePosition

                                // Change the BoardTile behind the selectedPiece to the highlight color
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(highlightColor);
                                    }
                                }
                                // Get a list of all the possible positions
                                possibleNewPositions = GetPossiblePositions(p2_Pieces_Dictionary[selectedPiecePosition], boardGrid_Dictionary, currentPlayer);
                            };
                        }
                    }

                    if (noNewSelectedPiece)
                    {
                        // Get the selectedNewPosion
                        int boardArray_Index = 0;
                        int cBoardArray_Index = 0;
                        foreach (Board_Tile cBoardTile in m1_Board_Tiles_Array)
                        {
                            if (cBoardTile.TextureRectangle.Contains(currentMouseState.X, currentMouseState.Y))
                            {
                                selectedNewPosition = new Vector2(cBoardTile.BoardPositionX, cBoardTile.BoardPositionY);
                                boardArray_Index = cBoardArray_Index;
                            }
                            cBoardArray_Index++;
                        }

                        // CHECK IF THE NEW POSITION IS AVAILABLE (EMPTY OR OCCUPIED BY ENEMY)
                        // IF YES : MOVE PIECE, UPDATE DICTIONARY
                        if (currentPlayer == playerIndex.Player1)
                        {
                            foreach (Vector2 cPossiblePosition in possibleNewPositions)
                            {
                                // If the selectedNewPosition == ANY Possible Positions
                                if (cPossiblePosition == selectedNewPosition)
                                {
                                    // Reset the color of the BoardTile behind the selectedPiece color (Remove the highlight)
                                    foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                    {
                                        if (cBaseTile.BoardPositionX == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                        {
                                            cBaseTile.ChangeColor(Color.White);
                                        }
                                    }
                                    // Move the piece to its new position
                                    p1_Pieces_Dictionary[selectedPiecePosition].MovePiece(m1_Board_Tiles_Array[boardArray_Index].BoardPositionX, m1_Board_Tiles_Array[boardArray_Index].BoardPositionY);
                                    // Update the currentPiece position in the dictionary
                                    p1_Pieces_Dictionary[selectedNewPosition] = p1_Pieces_Dictionary[selectedPiecePosition]; // Player1_Pieces Dictionary

                                    // Move the killed player2_piece if the new position is on a player2_piece
                                    if (boardGrid_Dictionary[selectedNewPosition] == gridTileTypes.Player2)
                                    {
                                        foreach (var cPiece in p2_Pieces_Dictionary.Keys)
                                        {
                                            if (p2_Pieces_Dictionary[cPiece].BoardPositionX == selectedNewPosition.X && p2_Pieces_Dictionary[cPiece].BoardPositionY == selectedNewPosition.Y)
                                            {
                                                // Move the dead piece of the board
                                                p2_Pieces_Dictionary[cPiece].MovePiece(p2_deathPositionX + p2_deadAmount, p2_deathPositionY);
                                                break;
                                            }
                                        }
                                    }

                                    // Get the right element in boardGrid_Dictionary and update it
                                    foreach (var cPos in boardGrid_Dictionary.Keys)
                                    {
                                        if (cPos.X == selectedNewPosition.X && cPos.Y == selectedNewPosition.Y)
                                        {
                                            // Set the new piecePosition to Player1
                                            boardGrid_Dictionary[cPos] = gridTileTypes.Player1;
                                            break;
                                        }
                                        // Set the old piecePosition to Empty
                                        else if (cPos.X == selectedPiecePosition.X && cPos.Y == selectedPiecePosition.Y)
                                        {
                                            boardGrid_Dictionary[cPos] = gridTileTypes.Empty;
                                            break;
                                        }
                                    }

                                    // Remove the old piece-pair from the dictionary
                                    p1_Pieces_Dictionary.Remove(selectedPiecePosition); // Player1_Pieces Dictionary
                                    isPieceSelected = false;

                                    currentPlayer = playerIndex.Player2; // Change to the other player's turn (player1 to player2)
                                }
                            }
                        }
                    
                        else if (currentPlayer == playerIndex.Player2)
                        {
                            foreach (Vector2 cPossiblePosition in possibleNewPositions)
                            {
                                // If the selectedNewPosition == ANY Possible Positions
                                if (cPossiblePosition == selectedNewPosition)
                                {
                                    // Reset the color of the BoardTile behind the selectedPiece color (Remove the highlight)
                                    foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                    {
                                        if (cBaseTile.BoardPositionX == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                        {
                                            cBaseTile.ChangeColor(Color.White);
                                        }
                                    }
                                    // Move the piece to its new position
                                    p2_Pieces_Dictionary[selectedPiecePosition].MovePiece(m1_Board_Tiles_Array[boardArray_Index].BoardPositionX, m1_Board_Tiles_Array[boardArray_Index].BoardPositionY);
                                    // Update the currentPiece position in the dictionary
                                    p2_Pieces_Dictionary[selectedNewPosition] = p2_Pieces_Dictionary[selectedPiecePosition]; // Player2_Pieces Dictionary

                                    // Move the killed player1_piece if the new position is on a player1_piece
                                    if (boardGrid_Dictionary[selectedNewPosition] == gridTileTypes.Player1)
                                    {
                                        foreach (var cPiece in p1_Pieces_Dictionary.Keys)
                                        {
                                            if (p1_Pieces_Dictionary[cPiece].BoardPositionX == selectedNewPosition.X && p1_Pieces_Dictionary[cPiece].BoardPositionY == selectedNewPosition.Y)
                                            {
                                                // Move the dead piece of the board
                                                p1_Pieces_Dictionary[cPiece].MovePiece(p1_deathPositionX + p1_deadAmount, p1_deathPositionY);
                                                break;
                                            }
                                        }
                                    }

                                    // Get the right element in boardGrid_Dictionary and update it
                                    foreach (var cPos in boardGrid_Dictionary.Keys)
                                    {
                                        if (cPos.X == selectedNewPosition.X && cPos.Y == selectedNewPosition.Y)
                                        {
                                            // Set the new piecePosition to Player2
                                            boardGrid_Dictionary[cPos] = gridTileTypes.Player2;
                                            break;
                                        }
                                        // Set the old piecePosition to Empty
                                        else if (cPos.X == selectedPiecePosition.X && cPos.Y == selectedPiecePosition.Y)
                                        {
                                            boardGrid_Dictionary[cPos] = gridTileTypes.Empty;
                                            break;
                                        }
                                    }

                                    // Remove the old piece-pair from the dictionary
                                    p2_Pieces_Dictionary.Remove(selectedPiecePosition); // Player1_Pieces Dictionary
                                    isPieceSelected = false;

                                    currentPlayer = playerIndex.Player1; // Change to the other player's turn (player2 to player1)
                                }
                            }
                        }
                    }
                }
                else // If there isn't a selectedPiece
                {
                    // Check which player's turn it is
                    if (currentPlayer == playerIndex.Player1)
                    {
                        // Check if the click was meant to select a Piece
                        foreach (KeyValuePair<Vector2, Chess_Piece> cPiece in p1_Pieces_Dictionary)
                        {
                            if (cPiece.Value.TextureRectangle.Contains(currentMouseState.X, currentMouseState.Y))
                            {
                                isPieceSelected = true;
                                selectedPiecePosition = cPiece.Key; // Update the currently selectedPiece's position as the selectedPiecePosition

                                // Change the BoardTile behind the selectedPiece to the highlight color
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(highlightColor);
                                    }
                                }
                                // Get a list of all the possible positions
                                possibleNewPositions = GetPossiblePositions(p1_Pieces_Dictionary[selectedPiecePosition], boardGrid_Dictionary, currentPlayer);
                            };
                        }
                    }
                    
                    else if (currentPlayer == playerIndex.Player2)
                    {
                        // Check if the click was meant to select a Piece
                        foreach (KeyValuePair<Vector2, Chess_Piece> cPiece in p2_Pieces_Dictionary)
                        {
                            if (cPiece.Value.TextureRectangle.Contains(currentMouseState.X, currentMouseState.Y))
                            {
                                isPieceSelected = true;
                                selectedPiecePosition = cPiece.Key; // Update the currently selectedPiece's position as the selectedPiecePosition

                                // Change the BoardTile behind the selectedPiece to the highlight color
                                foreach (Board_Tile cBaseTile in m1_Board_Tiles_Array)
                                {
                                    if (cBaseTile.BoardPositionX == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionX && cBaseTile.BoardPositionY == p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionY)
                                    {
                                        cBaseTile.ChangeColor(highlightColor);
                                    }
                                }
                                // Get a list of all the possible positions
                                possibleNewPositions = GetPossiblePositions(p2_Pieces_Dictionary[selectedPiecePosition], boardGrid_Dictionary, currentPlayer);
                            };
                        }
                    }
                }
            }

            //if (lastKeyboardState.IsKeyDown(Keys.Space) && currentKeyboardState.IsKeyUp(Keys.Space))
            //{
            //    p1_Pieces_Dictionary[testVector2].MovePiece(0, 4);
            //}
            // TESTING

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draw the selectedPiece's position as text
            if (currentPlayer == playerIndex.Player1 && p1_Pieces_Dictionary.ContainsKey(selectedPiecePosition))
                _spriteBatch.DrawString(_font, "X: " + p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionX + " Y: " + p1_Pieces_Dictionary[selectedPiecePosition].BoardPositionY, POSITIONTEXT, Color.Black);
            else if (currentPlayer == playerIndex.Player2 && p2_Pieces_Dictionary.ContainsKey(selectedPiecePosition))
                _spriteBatch.DrawString(_font, "X: " + p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionX + " Y: " + p2_Pieces_Dictionary[selectedPiecePosition].BoardPositionY, POSITIONTEXT, Color.Black);

            //_spriteBatch.DrawString(_font, "X: " + selectedPiecePosition.X, POSITIONTEXT, Color.Black);

            // Board Tiles
            #region Map 1
            foreach (Board_Tile boardTile in m1_Board_Tiles_Array)
            {
                boardTile.Draw(_spriteBatch);
            }
            #endregion Map 1

            // Pieces
            #region Player 1
            p1_TowerPiece_1.Draw(_spriteBatch);
            p1_HorsePiece_1.Draw(_spriteBatch);
            p1_KnightPiece_1.Draw(_spriteBatch);
            p1_KingPiece.Draw(_spriteBatch);
            p1_QueenPiece.Draw(_spriteBatch);
            p1_KnightPiece_2.Draw(_spriteBatch);
            p1_HorsePiece_2.Draw(_spriteBatch);
            p1_TowerPiece_2.Draw(_spriteBatch);

            p1_PawnPiece_1.Draw(_spriteBatch);
            p1_PawnPiece_2.Draw(_spriteBatch);
            p1_PawnPiece_3.Draw(_spriteBatch);
            p1_PawnPiece_4.Draw(_spriteBatch);
            p1_PawnPiece_5.Draw(_spriteBatch);
            p1_PawnPiece_6.Draw(_spriteBatch);
            p1_PawnPiece_7.Draw(_spriteBatch);
            p1_PawnPiece_8.Draw(_spriteBatch);
            #endregion Player 1
            
            #region Player 2
            p2_TowerPiece_1.Draw(_spriteBatch);
            p2_HorsePiece_1.Draw(_spriteBatch);
            p2_KnightPiece_1.Draw(_spriteBatch);
            p2_KingPiece.Draw(_spriteBatch);
            p2_QueenPiece.Draw(_spriteBatch);
            p2_KnightPiece_2.Draw(_spriteBatch);
            p2_HorsePiece_2.Draw(_spriteBatch);
            p2_TowerPiece_2.Draw(_spriteBatch);

            p2_PawnPiece_1.Draw(_spriteBatch);
            p2_PawnPiece_2.Draw(_spriteBatch);
            p2_PawnPiece_3.Draw(_spriteBatch);
            p2_PawnPiece_4.Draw(_spriteBatch);
            p2_PawnPiece_5.Draw(_spriteBatch);
            p2_PawnPiece_6.Draw(_spriteBatch);
            p2_PawnPiece_7.Draw(_spriteBatch);
            p2_PawnPiece_8.Draw(_spriteBatch);
            #endregion Player 2

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
