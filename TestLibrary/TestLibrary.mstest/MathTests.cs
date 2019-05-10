using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestLibrary.mstest
{
	[TestClass]
	public class MathTests
	{
		private Math math;

		[TestInitialize]
		public void Initialize()
		{
			this.math = new Math();
		}

		[TestMethod]
		public void SimpleAddTest()
		{
			var result = this.math.SimpleAdd(1, 2);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void SimpleAddTestWithFluentAssertion()
		{
			var result = this.math.SimpleAdd(1, 2);
			result.Should().Be(3);
		}

		[TestMethod]
		[DataRow(1, 2, 3)]
		[DataRow(-1, 1, 0)]
		[DataRow(-1, -2, -3)]
		public void SimpleAddUsingAttributeTest(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		[DynamicData(nameof(SimpleAddTestDataProperty), DynamicDataSourceType.Property)]
		public void SimpleAddUsingDynamicDataProperty(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		[DynamicData(nameof(SimpleAddTestDataMethod), DynamicDataSourceType.Method)]
		public void SimpleAddUsingDynamicDataMethod(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		[AddClassData]
		public void SimpleAddUsingCustomAttribute(int i1, int i2, int expected)
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
