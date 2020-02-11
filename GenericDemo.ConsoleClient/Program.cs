using System;
using GenericsDemo;
using NumberExtension;
using GenericDemo.Tests.Predicates;

namespace GenericDemo.ConsoleClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            var source = new int[] {12, 35, -65, 543, 23};
            source
                .FilterBy(new PredicateDigitAdapter(new PredicateDigit() { Digit = 5 }))
                .FilterBy(new OddPredicate());

            var doubleSource = new double[] { 12.24, 123.213, 2.234, 0.00321 };
            doubleSource.Transform(new DobleExtensionAdapter());
        }
    }
}