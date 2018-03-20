using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Facebook
{
    public class FromCareerCup
    {
        #region Space
        public class Space
        {
            public SpaceType SpaceType { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public Space[] SpaceNeighbors { get; set; }
        }
        public enum SpaceType { EmptySpace, Tree, House }



        #endregion
        #region Is Celebrity


        /// <summary>
        /// Determines whether the specified people is celebrity.
        /// You're a celebrity if you know no one but everyone knows you.
        /// </summary>
        /// <param name="people">The people.</param>
        /// <param name="potential">The person that may or may not be a celeb.</param>
        /// <returns>
        ///   <c>true</c> if the specified people is celebrity; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCelebrity(int[] people, int potential, int celebIndex = -1)
        {
            // lo is potentially the celeb. Now confirm
            if (celebIndex == -1)
            {
                for (int i = 0; i < people.Length; i++)
                {
                    if (people[i] == potential)
                    {
                        celebIndex = i;
                        break;
                    }
                }
            }
            for (int i = 0; i < people.Length; i++)
            {
                // You're not if you know someone or someone does not know you
                if (celebIndex != i &&
                    (Knows(celebIndex, i) || !Knows(i, celebIndex)))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Finds the celebrity.
        /// You're a celebrity if you know no one but everyone knows you.
        /// </summary>
        /// <param name="people">The people.</param>
        /// <returns></returns>
        public static int FindTheCelebrity(int[] people)
        {
            // pick two from both ends and check
            int lo = 0, hi = people.Length - 1;
            while (lo < hi)
            {
                if (Knows(lo, hi))
                {
                    // a can't be the celebrity
                    lo++;
                }
                else if (Knows(hi, lo))
                {
                    // b can't be the celebrity
                    hi--;
                }
                else
                {
                    // b does not know a, so a can't be celeb
                    lo++;
                    // a does not know b, so b can't be celeb
                    hi--;
                }
            }

            // lo is potentially the celeb. Now confirm
            int potential = people[lo];
            bool isCeleb = IsCelebrity(people, potential, lo);
            return isCeleb ? potential : -1;
        }

        private static int[][] AdjMatrix = new[]
        {
            new[] {0,0,1,0 },
            new[] {0,0,1,0 },
            new[] {0,0,0,0 },
            new[] {0,0,1,0 }
        };
        /// <summary>
        /// Checks whether a knows b.
        /// </summary>
        /// <param name="a">Person a.</param>
        /// <param name="b">Person b.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private static bool Knows(int a, int b)
        {
            return AdjMatrix[a][b] == 1;
        } 
        #endregion

        /// <summary>
        /// Determines whether the specified words is ordered.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="ordering">The ordering.</param>
        /// <returns>
        ///   <c>true</c> if the specified words is ordered; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOrdered(string[] words, char[] ordering)
        {
            if (words[0][0] != ordering[0]) return false;

            int current = 0;
            for (int i = 1; i < words.Length; i++)
            {
                char first = words[i][0];
                if (first != ordering[current])
                {
                    current++;
                    if (current == ordering.Length || first != ordering[current])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public class MovingAvg
        {
            private int[] buffer;
            private int count;
            private int currentIndex;
            private int sum;
            public MovingAvg(int n)
            {
                count = n;
                buffer = new int[n];
                currentIndex = 0;
                sum = 0;
            }

            public double GetMovingAverage(int newNumber)
            {
                sum += newNumber;
                if (currentIndex == 0)
                    // remove the first
                    sum -= buffer[currentIndex];

                // O(1)
                buffer[currentIndex] = newNumber;
                currentIndex = (currentIndex + 1) % count;
                return (double)sum / count;

                // O(n)
                //buffer[currentIndex] = newNumber;
                //currentIndex = (currentIndex + 1) % count;
                //return buffer.Average(); //O(n)
            }
        }
    }
}
