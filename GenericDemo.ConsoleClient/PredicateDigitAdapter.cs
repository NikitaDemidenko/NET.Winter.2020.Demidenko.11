using System;
using System.Collections.Generic;
using System.Text;
using GenericsDemo.Interfaces;
using NumberExtension;

namespace GenericDemo.ConsoleClient
{
    public class PredicateDigitAdapter : IPredicate
    {
        private readonly PredicateDigit predicate;

        public PredicateDigitAdapter(PredicateDigit predicate)
        {
            this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        public bool IsMatch(int value) => this.predicate.ContainsKey(value);
    }
}
