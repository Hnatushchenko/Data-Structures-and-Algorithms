using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class LinkedList<T>
    {
        public int Size { get; private set; } = 0;

        private Node<T>? head;

        public void Add(T value)
        {
            if (head is null)
            {
                head = new Node<T> { Value = value };
            }
            else
            {
                Node<T> node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new Node<T> { Value = value };
            }
            Size++;
        }
        public T Last
        {
            get
            {
                if (head is null)
                {
                    throw new InvalidOperationException("The list is empty");
                }
                Node<T> node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }
        public void RemoveLast()
        {
            if (head is null)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else if (head.Next is null)
            {
                head = null;
            }
            else
            {
                Node<T> beforeLast = head;
                while (beforeLast.Next!.Next is not null)
                {
                    beforeLast = beforeLast.Next;
                }
                beforeLast.Next = null;
            }
            Size--;
        }
    }
}
