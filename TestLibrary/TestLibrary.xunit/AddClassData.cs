using System.Collections;
using System.Collections.Generic;

namespace TestLibrary.xunit
{
	public class AddClassData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[] { 1, 2, 3 };
			yield return new object[] { -1, 1, 0 };
			yield return new object[] { -1, -2, -3 };
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
