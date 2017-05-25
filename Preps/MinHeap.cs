using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class PriorityHeap
    {
        private int[] _items;
        private int _size;
        private int _capacity;
        private Func<int, int, bool> compare;

        public PriorityHeap(int capacity, bool maxheap = false)
        {
            _items = new int[capacity];
            _size = 0;
            _capacity = capacity;
            if (maxheap)
            {
                compare = (i, j) => j < i;
            }
            else
            {
                compare = (i, j) => i < j;
            }
        }

        private void HeapifyUp()
        {
            int i = _size - 1;
            while (HasParent(i) && compare(_items[i], _items[Parent(i)]))
            {
                Swap(i, Parent(i));
                i = Parent(i); // walk upwards
            }
        }

        private void HeapifyDown()
        {
            int i = 0;
            // While there are chile nodes. 
            //NB: If there's no left node, there certainly will be no right node
            while (HasLeft(i))
            {
                int small = Left(i);
                if (HasRight(i) && compare(_items[Right(i)], _items[small]))
                    small = Right(i);

                if (compare(_items[i], _items[small]))
                    break;

                Swap(i, small);
                i = small;
            }
        }

        private int Left(int i) { return 2 * i + 1; }

        private int Right(int i) { return 2 * i + 2; }

        private int Parent(int i) { return (i - 1) / 2; }

        private bool HasLeft(int i) { return Left(i) < _size; }

        private bool HasRight(int i) { return Right(i) < _size; }

        private bool HasParent(int i) { return i > 0; } // SAME AS:{ return Parent(i) >= 0; }

        private void Swap(int i, int j)
        {
            int temp = _items[i];
            _items[i] = _items[j];
            _items[j] = temp;
        }

        public void Add(int item)
        {
            ExsureExtraCapacity();
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        private void ExsureExtraCapacity()
        {
            if (_size == _capacity)
            {
                var newList = new int[_capacity * 2];
                Array.Copy(_items, newList, _size);
                _items = newList;
            }
        }

        public int Count
        {
            get { return _size; }
        }

        public int Peek()
        {
            return _items[0];
        }

        public int Remove()
        {
            int temp = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return temp;
        }
    }
}
