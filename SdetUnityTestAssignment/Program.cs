using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdetUnityTestAssignment.SortedLinkedList;
using SdetUnityTestAssignment.FractionCalculator;
using Calc = SdetUnityTestAssignment.FractionCalculator.FractionCalculator;
using SortedList = SdetUnityTestAssignment.SortedLinkedList.SortedLinkedList;

namespace SdetUnityTestAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // FractionCalculator usage sample:
            Console.WriteLine("FractionCalculator usage sample:\n");
            Console.WriteLine("Add: " + Calc.Add(new Fraction(1, 2), new Fraction(2, 3)));
            Console.WriteLine("Sub: " + Calc.Sub(new Fraction(5, 6), new Fraction(1, 3)));
            Console.WriteLine("Mul: " + Calc.Mul(new Fraction(1, 8), new Fraction(2, 5)));
            Console.WriteLine("Div: " + Calc.Div(new Fraction(1, 2), new Fraction(1, 3)));

            // SortedLinkedList usage sample:
            Console.WriteLine("\nSortedLinkedList usage sample:\n");
            SortedList list = new SortedList();
            list.Add(10);
            list.Add(3);
            list.Add(8);
            list.Add(5);
            list.Add(15);
            list.Add(1);
            list.Add(2);
            list.Add(-2);
            list.Add(200);
            list.Add(-1024);

            IIterator iterator = list.GetIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
