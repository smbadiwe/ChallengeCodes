using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
// Source: https://kunuk.wordpress.com/2012/12/23/backtracking-knights-tour-with-c/
namespace Preps
{

    /// <summary>
    /// Author: Kunuk Nykjaer
    /// Backtracking Algorithm in C#
    /// Knight's Tour on NxN board
    /// </summary>
    public partial class HackerRank
    {

        // Init config
        static readonly Config config = new Config
        {
            MaxSolutions = 1,
        };

        // Composition root
        static int BackTrackSearch(int n, int a, int b)
        {

            var board = new ChessBoard(n, a, b);
            // Init data
            var P = new Data(config);
            // Init backtrack algo
            var bt = new Backtrack(board, P);
            // Find solutions
            int shortest = bt.Run();
            return shortest;
        }
    }

    class Backtrack
    {
        readonly ChessBoard _board;
        private readonly Data _p;
        public int ShortestPathLength
        {
            get
            {
                return _p.Solutions.Count > 0
                    ? _p.Solutions.Min(x => x.Count) - 1
                    : -1;
            }
        }

        public Backtrack(ChessBoard board, Data P)
        {
            _board = board;
            _p = P;
        }

        void UndoLastMove(Data P)
        {
            if (P.ExitBacktrack) return;
            P.RemoveLast();
        }

        /*     
        wikipedia:
        http://en.wikipedia.org/wiki/Backtracking

        procedure bt(P,c)
            if reject(P,c) then return        
            if accept(P,c) then output(P,c)                                  
            s ← first(P,c)
            while s ≠ Λ do
                bt(P,s)
                s ← next(P,s)
            end while

            // backtrack starts here 
         end procedure
        */

        // O(?)
        void Bt(Data P, Vector c)
        {
            Cell last = P.Path.Last(); // last visited
            Cell next = last.AddVector(c);
            if (Reject(P, next)) { return; }

            // Add path data
            P.Add(next);
            last = P.Path.Last(); // last visited, updated

            if (ThisIsTheGoal(last))
            {
                SaveResult(P);
            }

            var s = First(P, last);

            while (s.Id > 0)
            { // while not null
                Bt(P, s);
                s = Next(P, s);
            }

            // Leaf, dead end, backtrack, roll back path data
            UndoLastMove(P);
        }

        /// <summary>
        /// O(1) AKA AcceptSolution - return true if c is a solution of P, and false otherwise.
        /// </summary>
        /// <param name="last">P.Path.Last();</param>
        /// <returns></returns>
        bool ThisIsTheGoal(Cell last)
        {
            // Accept condition
            return (last.X == _board.Size - 1 && last.Y == _board.Size - 1);
        }

        // O(1) - return true only if the partial candidate c is not worth completing.
        bool Reject(Data P, Cell candidate)
        {
            // Custom early exit
            if (P.ExitBacktrack)
            {
                return true;
            }

            if (P.Visited.Contains(candidate))
            {
                return true;
            }
            if (candidate.X != candidate.Y && P.Visited.Contains(new Cell(candidate.Y, candidate.X)))
            {
                return true;
            }

            return !_board.IsInsideBoard(candidate);
        }

        /// <summary>
        /// Run and return the shortest path
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            Cell init = new Cell(0, 0); // init pos
            _p.Add(init);

            var first = First(_p, init);
            Bt(_p, first);
            return ShortestPathLength;
        }

        // Use the solution c of P, as appropriate to the application.
        void SaveResult(Data P)
        {
            P.Solutions.Add(P.Path.ToList());
            if (P.Solutions.Count >= P.Config.MaxSolutions)
            {
                P.ExitBacktrack = true;
            }
        }

        /// <summary>
        /// First valid child from path. 
        /// O(1)
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        Vector First(Data P, Cell last)
        {
            var filtered = new List<Vector>();
            foreach (var move in _board.Moves)
            {
                var next = last.AddVector(move);
                if (!_board.IsInsideBoard(next)) continue;
                if (P.Visited.Contains(next)) continue;

                if (ThisIsTheGoal(next)) return move;

                filtered.Add(move);
            }
            return filtered.FirstOrDefault();
        }

        /// <summary>
        /// Next sibling from current leaf
        /// </summary>
        /// <param name="P"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        Vector Next(Data P, Vector c)
        {
            Cell last = P.Path.Last(); // last visited, as updated
            if (ThisIsTheGoal(last)) return default(Vector);
            var filtered = new List<Vector>();
            foreach (var move in _board.Moves)
            {
                var next = last.AddVector(move);
                if (!_board.IsInsideBoard(next)) continue;
                if (P.Visited.Contains(next)) continue;

                if (move.Id <= c.Id) continue;

                if (ThisIsTheGoal(next)) return move;

                filtered.Add(move);
            }
            return filtered.FirstOrDefault();
        }
    }

    class ChessBoard
    {
        // Define move of Knight
        public readonly Vector[] Moves;

        public int A;
        public int B;
        private readonly string[][] _board;
        public int Size { get; private set; }
        public ChessBoard(int size, int a, int b)
        {
            Size = size;
            A = a;
            B = b;
            // Board is only used for printing display
            _board = new string[Size][];

            for (var i = 0; i < _board.Length; i++)
            {
                _board[i] = new string[Size];
            }
            // NB: Both cannot go back. Hence no - -.
            if (A == B)
            {
                Moves = new[] {
                    new Vector(+A, +B),
                    new Vector(+A, -B),
                    new Vector(-A, +B)
                };
            }
            else
            {
                Moves = new[] {
                    new Vector(+A, +B),
                    new Vector(+A, -B),
                    new Vector(-A, +B),
                    new Vector(+B, +A),
                    new Vector(+B, -A),
                    new Vector(-B, +A)
                };
            }
        }

        // Get valid moves within board
        public Vector[] GetValidMoves(Cell cell)
        {
            return Moves.Where(v => IsInsideBoard(cell.AddVector(v))).ToArray();
        }

        public bool IsInsideBoard(Cell c)
        {
            return c.X >= 0 && c.X < Size && c.Y >= 0 && c.Y < Size;
        }
    }

    class Data
    {
        public bool ExitBacktrack { get; set; }
        public Config Config;

        public readonly List<Cell> Path = new List<Cell>();
        public readonly HashSet<Cell> Visited = new HashSet<Cell>();
        public readonly List<List<Cell>> Solutions = new List<List<Cell>>();
        public readonly HashSet<string> PathTried = new HashSet<string>();

        public Data(Config config)
        {
            Config = config;
        }

        // O(1)
        public void RemoveLast()
        {
            Cell cell = Path.Last(); // O(1)
            Visited.Remove(cell); // O(1)
            Path.RemoveAt(Path.Count - 1); // O(1) remove last
        }

        // O(1) or O(n)
        public void Add(Cell cell)
        {
            Visited.Add(cell);
            Path.Add(cell);
            PathTried.Add((PathTried.Count + 1).ToString());
        }
    }

    class Config
    {
        public int MaxSolutions { get; set; }
    }

    // Position on board
    struct Cell
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Cell AddVector(Vector v)
        {
            return new Cell(X + v.X, Y + v.Y);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("[{0},{1}]", X, Y);
        }
        public override bool Equals(object obj)
        {
            try
            {
                var other = (Cell)obj;
                return GetHashCode() == other.GetHashCode();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    // Move definition
    struct Vector
    {
        private static int _count = 1;
        public int Id; // { get; private set; }

        public int X; // { get; set; }
        public int Y; // { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
            Id = _count++;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("[{0},{1}]", X, Y);
        }
        public override bool Equals(object obj)
        {
            try
            {
                var other = (Vector)obj;
                return GetHashCode() == other.GetHashCode();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
