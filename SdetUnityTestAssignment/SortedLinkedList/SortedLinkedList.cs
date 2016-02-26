using System;

namespace SdetUnityTestAssignment.SortedLinkedList
{
    public class SortedLinkedList : IIterable
    {
        public Node Head { get; set; }
        public int Count { get; set; }

        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                Head = newNode;
                Count++;
                return;
            }

            if (data < Head.Value)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null && current.Next.Value < data)
                {
                    current = current.Next;
                }

                Node next = current.Next;
                newNode.Next = next;
                current.Next = newNode;
            }

            Count++;
        }

        public IIterator GetIterator()
        {
            return new SortedLinkedListIterator(Head);
        }
    }
}
