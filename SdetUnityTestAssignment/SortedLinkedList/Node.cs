using System;

namespace SdetUnityTestAssignment.SortedLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
