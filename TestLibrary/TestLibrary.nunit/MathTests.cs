using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TestLibrary;

namespace Tests
{
	public class MathTests
	{
		private Math math;

		[SetUp]
		public void Setup()
		{
			this.math = new Math();
		}

		[Test]
		public void SimpleAddTest()
		{
			var result = this.math.SimpleAdd(1, 2);
			Assert.AreEqual(3, result);
		}

		[Test]
		public void SimpleAddTestWithFluentAssertion()
		{
			var result = this.math.SimpleAdd(1, 2);
			result.Should().Be(3);
		}

		[TestCase(1, 2, 3)]
		[TestCase(-1, 1, 0)]
		[TestCase(-1, -2, -3)]
		public void SimpleAddUsingAttributeTest(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}

		[TestCaseSource(nameof(SimpleAddTestDataProperty))]
		public void SimpleAddUsingDynamicDataProperty(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}

		[TestCaseSource(nameof(SimpleAddTestDataMethod))]
		public void SimpleAddUsingDynamicDataMethod(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}

		private static IEnumerable<object[]> SimpleAddTestDataProperty
		{
			get
			{
				yield return new object[] { 1, 2, 3 };
				yield return new object[] { -1, 1, 0 };
				yield return new object[] { -1, -2, -3 };
			}
		}

		private static IEnumerable<object[]> SimpleAddTestDataMethod()
		{
			yield return new object[] { 1, 2, 3 };
			yield return new object[] { -1, 1, 0 };
			yield return new object[] { -1, -2, -3 };
		}
	}
}