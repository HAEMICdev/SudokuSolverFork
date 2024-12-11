using System;

namespace SudokuSolver {
  public static class SudokuSolver {
    public static SudokuBoard? Solve(SudokuBoard board) {
      return Solve(board, 0, 0);
    }

    private static SudokuBoard? Solve(SudokuBoard board, int i, int j) {
      BoardStatus status = board.Check();
      if (status == BoardStatus.Solved) return board;
      if (status == BoardStatus.Unsolvable) return null;
      
      int iNext = i;
      int jNext = j + 1;
      if (jNext >= board.size) {
        jNext = 0;
        iNext++;
      }

      if (board.IsFixedNumber(i, j)) {
        return Solve(board, iNext, jNext);
      } else {
        for (int n = 1; n <= board.size; n++) {
          board.SetNumber(i, j, n);
          if (Solve(board, iNext, jNext) is not null) {
            return board;
          }
        }
        board.SetNumber(i, j, 0);
        return null;
      }
    }
  }
}
