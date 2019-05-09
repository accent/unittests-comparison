using System.Collections.Generic;
using Xunit;

namespace TestLibrary.xunit
{
	public class MathTests
	{
		private Math math;

		public MathTests()
		{
			this.math = new Math();
		}

		[Fact]
		public void SimpleAddTest()
		{
			var result = this.math.SimpleAdd(1, 2);
			Assert.Equal(3, result);
		}

		[Theory]
		[InlineData(1, 2, 3)]
		[InlineData(-1, 1, 0)]
		[InlineData(-1, -2, -3)]
		public void SimpleAddUsingAttributeTest(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.Equal(expected, result);
		}

		[Theory]
		[MemberData(nameof(SimpleAddTestDataProperty))]
		public void SimpleAddUsingDynamicDataProperty(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.Equal(expected, result);
		}

		[Theory]
		[MemberData(nameof(SimpleAddTestDataMethod))]
		public void SimpleAddUsingDynamicDataMethod(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.Equal(expected, result);
		}

		[Theory]
		[ClassData(typeof(AddClassData))]
		public void SimpleAddUsingDynamicClass(int i1, int i2, int expected)
		{
			var result = this.math.SimpleAdd(i1, i2);
			Assert.Equal(expected, result);
		}

		public static IEnumerable<object[]> SimpleAddTestDataProperty
		{
			get
			{
				yield return new object[] { 1, 2, 3 };
				yield return new object[] { -1, 1, 0 };
				yield return new object[] { -1, -2, -3 };
			}
		}

		public static IEnumerable<object[]> SimpleAddTestDataMethod()
		{
			yield return new object[] { 1, 2, 3 };
			yield return new object[] { -1, 1, 0 };
			yield return new object[] { -1, -2, -3 };
		}
	}
}
