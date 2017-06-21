using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LisT<T>
    {
        private ListNode<T> front;
        private ListNode<T> back;
        private string name;
        public int Count
        {
            get
            {
                int count = 0;
                ListNode<T> current = back;
                while(current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
        /// <summary>
        /// Check if the list is empty by viewing the front element.
        /// </summary>
        /// <returns>boolean</returns>
        public bool IsEmpty
        {
            get
            {
                return front == null;
            }
        }

        /// <summary>
        /// Get an item in the list by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Object of type T.</returns>
        public T this[int index]
        {
            get
            {
                ListNode<T> current = back;
                for (int i = 0; i < index; i++)
                {
                    if (current == null)
                        throw new EmptyLisTException();
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                ListNode<T> current = back;
                for (int i = 0; i < index; i++)
                {
                    if (current == null)
                        throw new EmptyLisTException();
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        /// <summary>
        /// Create a list of T with listName.
        /// </summary>
        /// <param name="listName"></param>
        public LisT(string listName)
        {
            name = listName;
            front = null;
            back = null;
        }
        /// <summary>
        /// Create a list of type T.
        /// </summary>
        public LisT() : this("list")
        {

        }
        /// <summary>
        /// Drops an item onto the top of the list.
        /// </summary>
        /// <param name="item"></param>
        public void Drop(T item)
        {
            if (IsEmpty)
                back = front = new ListNode<T>(item);
            else
                back = new ListNode<T>(item, back);
        }
        /// <summary>
        /// Lifts an item off of the top of the list.
        /// </summary>
        /// <exception cref="EmptyLisTException">EmptyLisTException</exception>
        /// <param name="item"></param>
        public T Lift(T item)
        {
            if (IsEmpty)
                throw new EmptyLisTException();
            T itemToBeRemoved = back.Data;
            if (back == front)
                back = front = null;
            else
                back = back.Next;
            return itemToBeRemoved;
        }
        /// <summary>
        /// Place an item at the bottom of the list.
        /// </summary>
        /// <param name="item"></param>
        public void Raise(T item)
        {
            if (IsEmpty)
                back = front = new ListNode<T>(item);
            else
                front = front.Next = new ListNode<T>(item);

        }
        /// <summary>
        /// Digs out the item from the bottom of a list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Item of T.</returns>
        public T Dig(T item)
        {
            if (IsEmpty)
                throw new EmptyLisTException();
            T itemToBeRemoved = front.Data;
            if (back == front)
                back = front = null;
            else
            {
                ListNode<T> current = back;
                while (current.Next != front)
                    current = current.Next;
                front = current;
                current.Next = null;
            }
            return itemToBeRemoved;
        }

        /// <summary>
        /// Applies the action on each element in the list.
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action)
        {
            ListNode<T> current = back;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }

        public T SelectFirst(Predicate<T> predicate)
        {
            ListNode<T> current = back;
            while (current != null)
            {
                if (predicate(current.Data))
                    return current.Data;
            }
            return default(T);
        }
    }
}
