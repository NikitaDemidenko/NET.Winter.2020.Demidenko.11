using GenericsDemo;
using GenericsDemo.Interfaces;
using Moq;
using NumberExtension;
using NUnit.Framework;
using static NumbersExtensions.DoubleExtension;

namespace GenericDemo.Tests
{
    [TestFixture]
    public class PredicateTests
    {
        private Mock<IPredicate<int>> mockPredicate;
        private IPredicate<int> predicate;

        private Mock<ITransformer<double, string>> mockTransformer;
        private ITransformer<double, string> transformer;

        private Mock<IComparer<int>> mockComparer;
        private IComparer<int> comparer;

        [SetUp]
        public void Setup()
        {
            mockPredicate = new Mock<IPredicate<int>>();

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

        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = new[] { 6, 5, 4, 3, 2, 1 })]
        [TestCase(new[] { int.MinValue, 324, 52, 214, 35, int.MaxValue }, ExpectedResult = new[] { int.MaxValue, 35, 214, 52, 324, int.MinValue })]
        [TestCase(new[] { 0, 0, 0, 0, 0, 1 }, ExpectedResult = new[] { 1, 0, 0, 0, 0, 0 })]
        public int[] ReverseTests(int[] source)
        {
            return source.Reverse();
        }

        [TestCase(new object[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = new[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new object[] { int.MinValue, 324, 52, 214, 35, int.MaxValue }, ExpectedResult = new[] { int.MinValue, 324, 52, 214, 35, int.MaxValue })]
        [TestCase(new object[] { 0, 0, 0, 0, 0, 1 }, ExpectedResult = new[] { 0, 0, 0, 0, 0, 1 })]
        public int[] TypeOfTests_Int(object[] source)
        {
            return source.TypeOf<int>();
        }

        [TestCase(new object[] { 1.41, 0.232, 3321.311, -123.123, 5.0, 6.1 }, ExpectedResult = new double[] { 1.41, 0.232, 3321.311, -123.123, 5.0, 6.1 })]
        [TestCase(new object[] { double.Epsilon, 324.123, 0.52, 2.21314, 35.123, 0.0 }, ExpectedResult = new double[] { double.Epsilon, 324.123, 0.52, 2.21314, 35.123, 0.0 })]
        [TestCase(new object[] { 0.012, 1230.0, 32.111, 0.0, 0.0, 0.91 }, ExpectedResult = new double[] { 0.012, 1230.0, 32.111, 0.0, 0.0, 0.91 })]
        public double[] TypeOfTests_Double(object[] source)
        {
            return source.TypeOf<double>();
        }
    }
}