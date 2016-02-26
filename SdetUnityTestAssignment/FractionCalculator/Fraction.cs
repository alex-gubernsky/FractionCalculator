using System;

namespace SdetUnityTestAssignment.FractionCalculator
{
    public interface IFraction
    {
        int Numerator { get; }
        int Denominator { get; }
    }

    public class Fraction : IFraction
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("denominator");

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            _numerator = numerator;
            _denominator = denominator;
        }

        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }

        public override string ToString()
        {
            if (_numerator == 0)
                return _numerator.ToString();
            return String.Format("{0}/{1}", _numerator, _denominator);
        }
    }
}
