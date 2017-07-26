using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class TowerOfHanoi
    {
        public void MoveDisks(int n)
        {
            Console.WriteLine("Source: [0]; Buffer: [1]; Destination: [2].\n");
            var towers = new Tower[3];
            for (int i = 0; i < 3; i++)
            {
                towers[i] = new Tower { Index = i };
            }
            for (int i = n - 1; i >= 0; i--)
            {
                towers[0].Disks.Push(i);
            }

            int total = towers[0].MoveDisks(n, towers[2], towers[1]);
            Console.WriteLine("\nTotal: {0}", total);
        }
    }
    public class Tower
    {
        public int Index { get; set; }
        public Stack<int> Disks { get; set; } = new Stack<int>();
        public void Add(int disk)
        {
            if (Disks.Count > 0 && disk > Disks.Peek()) throw new InvalidOperationException();
            Disks.Push(disk);
        }

        public int MoveTopTo(Tower dest)
        {
            if (Disks.Count > 0)
            {
                var top = Disks.Pop();
                dest.Add(top);
                Console.WriteLine("Move disk {0} from [{1}] to [{2}]", top, Index, dest.Index);
                return 1;
            }
            return 0;
        }

        public int MoveDisks(int numberOfTowers, Tower dest, Tower buffer)
        {
            if (numberOfTowers <= 0) return 0;

            int count = 0;

            count += MoveDisks(numberOfTowers - 1, buffer, dest);
            count += MoveTopTo(dest);
            count += buffer.MoveDisks(numberOfTowers - 1, dest, this);

            return count;
        }
    }
}
