using System;

namespace SdetUnityTestAssignment.FractionCalculator
{
    public static class FractionCalculator
    {
        public static Fraction Add(Fraction a, Fraction b)
        {
            int lcm = 0;
            if (a.Denominator == b.Denominator)
                lcm = a.Denominator;
            else
                lcm = LCM(a.Denominator, b.Denominator);
            int sum = checked(lcm / a.Denominator * a.Numerator + lcm / b.Denominator * b.Numerator);

            int gcd = GCD(sum, lcm);
            if (gcd > 1)
            {
                sum /= gcd;
                lcm /= gcd;
            }

            return new Fraction(sum, lcm);
        }

        public static Fraction Sub(Fraction a, Fraction b)
        {
            Fraction temp = new Fraction(-b.Numerator, b.Denominator);
            return Add(a, temp);
        }

        public static Fraction Mul(Fraction a, Fraction b)
        {
            int num = checked(a.Numerator * b.Numerator);
            int den = checked(a.Denominator * b.Denominator);

            int gcd = GCD(num, den);
            if (gcd > 1)
            {
                num /= gcd;
                den /= gcd;
            }

            return new Fraction(num, den);
        }

        public static Fraction Div(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException();

            Fraction temp = new Fraction(b.Denominator, b.Numerator);
            return Mul(a, temp);
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return GCD(b, a % b);
        }

        private static int LCM(int a, int b)
        {
            return Math.Abs(checked(a * b)) / GCD(a, b);
        }
    }
}
