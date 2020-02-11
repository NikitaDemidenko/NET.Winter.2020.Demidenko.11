using GenericsDemo.Interfaces;

namespace GenericDemo.Tests.Predicates
{
    public class OddPredicate : IPredicate
    {
        public bool IsMatch(int value) => value % 2 != 0;
    }
}