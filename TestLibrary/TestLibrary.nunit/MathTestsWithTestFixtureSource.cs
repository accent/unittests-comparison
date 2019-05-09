using NUnit.Framework;

namespace TestLibrary.nunit
{
	[TestFixtureSource(typeof(AddClassFixtureData), "AddParams")]
	public class MathTestsWithTestFixtureSource
	{
		private int i1;
		private int i2;
		private int expected;
		private Math math;

		public MathTestsWithTestFixtureSource(int i1, int i2, int expected)
		{
			this.i1 = i1;
			this.i2 = i2;
			this.expected = expected;
		}

		[SetUp]
		public void Setup()
		{
			this.math = new Math();
		}

		[Test]
		public void AddWithTextFixtureSource()
		{
			int result = math.SimpleAdd(this.i1, this.i2);
			Assert.AreEqual(expected, result);
		}
	}
}
