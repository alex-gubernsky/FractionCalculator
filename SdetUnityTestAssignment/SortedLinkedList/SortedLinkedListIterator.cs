using System;

namespace SdetUnityTestAssignment.SortedLinkedList
{
    public class SortedLinkedListIterator : IIterator
    {
        private Node _current;

        public SortedLinkedListIterator(Node head)
        {
            _current = head;
        }

        public bool HasNext()
        {
            return _current != null;
        }

        public int Next()
        {
            if (HasNext())
            {
                Node next = _current;
                _current = _current.Next;
                return next.Value;
            }

            throw new IndexOutOfRangeException("No more values");
        }
    }
}
