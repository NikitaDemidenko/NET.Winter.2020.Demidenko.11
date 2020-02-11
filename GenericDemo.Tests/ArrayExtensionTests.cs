using GenericsDemo;
using GenericsDemo.Interfaces;
using Moq;
using NumberExtension;
using NUnit.Framework;

namespace GenericDemo.Tests
{
    [TestFixture]
    public class PredicateTests
    {
        private Mock<IPredicate> mockPredicate;

        private IPredicate predicate;

        [SetUp]
        public void Setup()
        {
            mockPredicate = new Mock<IPredicate>();

            mockPredicate
                .Setup(p => p.IsMatch(It.Is<int>(i => new PredicateDigit {Digit = 5}.ContainsKey(i))))
                .Returns(true);

            predicate = mockPredicate.Object;
        }

        [TestCase(55)]
        [TestCase(551)]
        [TestCase(-12551)]
        [TestCase(-90551)]
        public void IsMatchTests_Return_True(int value)
        {
            Assert.IsTrue(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestCase(109)]
        [TestCase(67632)]
        [TestCase(-120943)]
        [TestCase(-2113)]
        public void IsMatchTests_Return_False(int value)
        {
            Assert.IsFalse(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void FilterByTests()
        {
            var source = new int[] {12, 35, -65, 543, 23};

            var expected = new int[] {35, -65, 543};

            var actual = source.FilterBy(predicate);

            CollectionAssert.AreEqual(actual, expected);

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(5));
        }
    }
}