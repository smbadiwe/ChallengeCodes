using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class LinkedListImpl<T>
    {
        private LinkedListNode<T> head;
        public LinkedListImpl(LinkedListNode<T> head)
        {
            this.head = head;
        }

        public string Print()
        {
            var sb = new StringBuilder();
            var current = head;
            while (current != null)
            {
                sb.AppendFormat("{0} ", current.Value);
                current = current.Next;
            }
            return sb.ToString().TrimEnd();
        }

        public void Delete(T val)
        {
            // if it's the head
            if (head.Value.Equals(val))
            {
                head = head.Next;
                return;
            }
            LinkedListNode<T> previousNode = null, currentNode = head;
            while (currentNode != null && !currentNode.Value.Equals(val))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null) return; // => not found
            
            previousNode.Next = currentNode.Next;
        }

        public void DeleteLastOccurrenceOf(T val)
        {
            if (head != null)
            {
                //int pos = 0, posOfPrevOfItemToDelete = -1;
                //LinkedListNode<T> current = head;
                //while (current.Next != null)
                //{
                //    if (current.Next.Value.Equals(val))
                //    {
                //        posOfPrevOfItemToDelete = pos;
                //    }
                //    pos++;
                //    current = current.Next;
                //}

                //if (posOfPrevOfItemToDelete == -1)
                //{
                //    // then check if head == val
                //    if (head.Value.Equals(val))
                //    {
                //        // delete root
                //        head = head.Next;
                //    }
                //}
                //else
                //{
                //    current = head;
                //    LinkedListNode<T> prev = null;
                //    pos = 0;
                //    while (pos <= posOfPrevOfItemToDelete)
                //    {
                //        prev = current;
                //        current = current.Next;
                //        pos++;
                //    }
                //    prev.Next = current.Next;
                //    //current = prev;
                //}

                LinkedListNode<T> current = head, prevOfNodeToDelete = null;
                while (current.Next != null)
                {
                    if (current.Next.Value.Equals(val))
                    {
                        prevOfNodeToDelete = current;
                    }
                    current = current.Next;
                }

                if (prevOfNodeToDelete == null)
                {
                    //then check if head == val
                    if (head.Value.Equals(val))
                    {
                        // delete root
                        head = head.Next;
                    }
                }
                else
                {
                    prevOfNodeToDelete.Next = prevOfNodeToDelete.Next.Next;
                }
            }

        }

        public void DeleteAllOccurrencesOf(T val)
        {
            if (head != null)
            {
                LinkedListNode<T> current = head, prevOfNodeToDelete = null;
                while (current.Next != null)
                {
                    if (current.Next.Value.Equals(val))
                    {
                        prevOfNodeToDelete = current;
                        prevOfNodeToDelete.Next = prevOfNodeToDelete.Next.Next;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

                // Check the head
                if (head.Value.Equals(val))
                {
                    // delete root
                    head = head.Next;
                }
            }

        }

        public T DeleteLastItem()
        {
            T ans;
            if (head == null) throw new InvalidOperationException();
            if (head.Next == null) 
            {
                // only one item in list
                ans = head.Value;
                head = null;
                return ans;
            }
            LinkedListNode<T> current = head, prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            ans = current.Value;
            prev.Next = null;
            return ans;
        }

        public T DeleteFirstItem()
        {
            if (head == null) throw new InvalidOperationException();

            T ans = head.Value;
            head = head.Next;
            return ans;
        }

        /// <summary>
        /// Function to reverse the linked list. Note that this function may change the head
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public LinkedListNode<T> Reverse()
        {
            if (head == null || head.Next == null) return head;

            LinkedListNode<T> prev = null, next = null;
            LinkedListNode<T> current = head;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
