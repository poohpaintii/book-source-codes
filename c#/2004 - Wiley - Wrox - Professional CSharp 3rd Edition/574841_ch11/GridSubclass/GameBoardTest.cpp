#include "GameBoard.h"

class ChessPiece {};

int main(int argc, char** argv)
{
  GameBoard<ChessPiece> chessBoard;

  ChessPiece pawn;
  chessBoard.setElementAt(0, 0, pawn);
  chessBoard.move(0, 0, 0, 1);

  return (0);
}
