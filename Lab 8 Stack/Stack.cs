namespace Lab_8
{
    class Stack<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public int Size => list.Size;

        public void Push(T value)
        {
            list.Add(value);
        }
        public T Pop()
        {
            T value = list.Last;
            list.RemoveLast();
            return value;
        }
        public T Peek()
        {
            return list.Last;
        }
        public void Clear()
        {
            list = new LinkedList<T>();
        }
    }
}
