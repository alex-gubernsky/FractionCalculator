using System;

namespace SdetUnityTestAssignment.SortedLinkedList
{
    public interface IIterator
    {
        bool HasNext();
        int Next();
    }
}
