using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void WordSort()
		{
			Assert.AreEqual("Boom Zoom", SimpleTest.MyTest.TextFormatter("Zoom Boom"));
		}

		[TestMethod]
		public void CaseSort()
		{
			Assert.AreEqual("Boom boom", SimpleTest.MyTest.TextFormatter("boom Boom"));
		}

		[TestMethod]
		public void RemoveInvalidChars()
		{
			Assert.AreEqual("b b", SimpleTest.MyTest.TextFormatter("b, b"));
		}

		[TestMethod]
		public void SimpleTest1()
		{
			Assert.AreEqual("baby Go go", SimpleTest.MyTest.TextFormatter("Go baby, go"));
		}

		[TestMethod]
		public void SimpleTest2()
		{
			Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.MyTest.TextFormatter("CBA, abc aBc ABC cba CBA."));
		}
	}
}