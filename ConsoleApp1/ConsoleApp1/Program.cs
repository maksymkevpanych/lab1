using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {

        public class ChessPiece
        {
            public string Type { get; set; }
            public string Color { get; set; }

            public virtual void Display(bool useUtf8)
            {
                if (useUtf8)
                {
                    Console.Write($"{GetUtf8Symbol()} ");
                }
                else
                {
                    Console.Write($"{Color[0]}{Type[0]} ");
                }
            }

            private string GetUtf8Symbol()
            {
                switch (Type)
                {
                    case "King":
                        return Color == "White" ? "♔" : "♚";
                    case "Queen":
                        return Color == "White" ? "♕" : "♛";
                    case "Bishop":
                        return Color == "White" ? "♗" : "♝";
                    case "Knight":
                        return Color == "White" ? "♘" : "♞";
                    case "Rook":
                        return Color == "White" ? "♖" : "♜";
                    case "Pawn":
                        return Color == "White" ? "♙" : "♟";
                    default:
                        return "";
                }
            }
        }

        public class King : ChessPiece
        {
            public King(string color)
            {
                Type = "King";
                Color = color;
            }
        }

        public class Queen : ChessPiece
        {
            public Queen(string color)
            {
                Type = "Queen";
                Color = color;
            }
        }

        public class Bishop : ChessPiece
        {
            public Bishop(string color)
            {
                Type = "Bishop";
                Color = color;
            }
        }

        public class Knight : ChessPiece
        {
            public Knight(string color)
            {
                Type = "Knight";
                Color = color;
            }
        }

        public class Rook : ChessPiece
        {
            public Rook(string color)
            {
                Type = "Rook";
                Color = color;
            }
        }

        public class Pawn : ChessPiece
        {
            public Pawn(string color)
            {
                Type = "Pawn";
                Color = color;
            }
        }

        public class ChessBoard
        {
            private ChessPiece[,] board = new ChessPiece[8, 8];

            public void AddPiece(int x, int y, ChessPiece piece)
            {
                board[x, y] = piece;
            }

            public void AddPieces(List<Tuple<int, int, ChessPiece>> pieces)
            {
                foreach (var pieceInfo in pieces)
                {
                    AddPiece(pieceInfo.Item1, pieceInfo.Item2, pieceInfo.Item3);
                }
            }

            public void Display(bool useUtf8)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] != null)
                        {
                            board[i, j].Display(useUtf8);
                        }
                        else
                        {
                            Console.Write(".  ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding=Encoding.UTF8;
            ChessBoard board = new ChessBoard();

            List<Tuple<int, int, ChessPiece>> initialPieces = new List<Tuple<int, int, ChessPiece>>()
            {
                new Tuple<int, int, ChessPiece>(0, 0, new Rook("White")),
                new Tuple<int, int, ChessPiece>(0, 1, new Knight("White")),
                new Tuple<int, int, ChessPiece>(0, 2, new Bishop("White")),
                new Tuple<int, int, ChessPiece>(0, 3, new Queen("White")),
                new Tuple<int, int, ChessPiece>(0, 4, new King("White")),
                new Tuple<int, int, ChessPiece>(0, 5, new Bishop("White")),
                new Tuple<int, int, ChessPiece>(0, 6, new Knight("White")),
                new Tuple<int, int, ChessPiece>(0, 7, new Rook("White")),

                new Tuple<int, int, ChessPiece>(1, 0, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 1, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 2, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 3, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 4, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 5, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 6, new Pawn("White")),
                new Tuple<int, int, ChessPiece>(1, 7, new Pawn("White")),

                new Tuple<int, int, ChessPiece>(7, 0, new Rook("Black")),
                new Tuple<int, int, ChessPiece>(7, 1, new Knight("Black")),
                new Tuple<int, int, ChessPiece>(7, 2, new Bishop("Black")),
                new Tuple<int, int, ChessPiece>(7, 3, new Queen("Black")),
                new Tuple<int, int, ChessPiece>(7, 4, new King("Black")),
                new Tuple<int, int, ChessPiece>(7, 5, new Bishop("Black")),
                new Tuple<int, int, ChessPiece>(7, 6, new Knight("Black")),
                new Tuple<int, int, ChessPiece>(7, 7, new Rook("Black")),

                new Tuple<int, int, ChessPiece>(6, 0, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 1, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 2, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 3, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 4, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 5, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 6, new Pawn("Black")),
                new Tuple<int, int, ChessPiece>(6, 7, new Pawn("Black")),
            };

            board.AddPieces(initialPieces);

            
            board.Display(true);
            Console.ReadLine();
        }
    }
}
