using NUnit.Framework;
using System.Collections;

namespace TestLibrary.nunit
{
	public class AddClassFixtureData
	{
		public static IEnumerable AddParams
		{
			get
			{
				yield return new TestFixtureData(1, 2, 3);
				yield return new TestFixtureData(-1, 1, 0);
				yield return new TestFixtureData(-1, -2, -3);
			}
		}
	}
}
