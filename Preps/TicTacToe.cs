using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class TicTacToe
    {
        public enum CellContent { Empty, X, O }

        private int totalPlays;
        private readonly int maxPlayCount;
        private readonly int minPlaysBeforeWinIsPossible;
        private readonly int size;
        private readonly CellContent[][] Board;
        public TicTacToe(int size = 3)
        {
            this.size = size;
            Board = new CellContent[size][];
            for (int i = 0; i < size; i++)
            {
                Board[i] = new CellContent[size];
            }
            totalPlays = 0;
            maxPlayCount = size * size;
            minPlaysBeforeWinIsPossible = size - 1 + size; // two players assumed
        }

        public void Start()
        {
            while (true)
            {
                Play(CellContent.X);
                Play(CellContent.O);
            }
        }

        private Tuple<int, int> GetPositionToPlay(CellContent c)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Board[i][j] == CellContent.Empty)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

        private void Play(CellContent c)
        {
            //No need since it's only used internally
            //if (c == CellContent.Empty) return;

            var nextIndex = GetPositionToPlay(c);
            if (nextIndex.Item1 == -1)
                throw new ArithmeticException("Draw");
            
            Board[nextIndex.Item1][nextIndex.Item2] = c;
            totalPlays++;
            if (totalPlays == maxPlayCount)
                throw new ArithmeticException("Draw");
            if (HasWon(c, nextIndex.Item1, nextIndex.Item2))
                throw new ArithmeticException($"Winner: {c}");
        }

        private bool HasWon(CellContent c, int row, int col)
        {
            if (totalPlays < minPlaysBeforeWinIsPossible) return false;

            int i = 0, j = 0;

            // check diagonals: 00 - nn
            if (row == col)
            {
                for (i = 0; i < size; i++)
                {
                    if (Board[i][i] != c) break;
                    if (i == size - 1)
                    {
                        return true; // cos it got to the end and all was same
                    }
                }
            }

            // check diagonals: n-1,0 - 0,n-1
            if (row + col == size - 1)
            {
                for (i = 0; i < size; i++)
                {
                    if (Board[i][size - 1 - i] != c) break;
                    if (i == size - 1)
                    {
                        return true; // cos it got to the end and all was same
                    }
                }
            }

            // check row
            for (j = 0; j < size; j++)
            {
                if (Board[row][j] != c) break;
                if (j == size - 1)
                {
                    return true; // cos it got to the end and all was same
                }
            }

            // check cols
            for (i = 0; i < size; i++)
            {
                if (Board[i][col] != c) break;
                if (i == size - 1)
                {
                    return true; // cos it got to the end and all was same
                }
            }

            return false;
        }
    }
}
