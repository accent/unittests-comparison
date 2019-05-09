using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestLibrary.mstest
{
	public class AddClassDataAttribute : Attribute, ITestDataSource
	{
		public IEnumerable<object[]> GetData(MethodInfo methodInfo)
		{
			yield return new object[] { 1, 2, 3 };
			yield return new object[] { -1, 1, 0 };
			yield return new object[] { -1, -2, -3 };
		}

		public string GetDisplayName(MethodInfo methodInfo, object[] data)
		{
			return nameof(AddClassDataAttribute);
		}
	}
}
