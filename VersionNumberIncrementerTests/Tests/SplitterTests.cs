using VersionNumberIncrementer.Splitter;

namespace VersionNumberIncrementerTests.Tests
{
    [TestClass]
    public class SplitterTests
    {
        private readonly VersionNumberSplitter versionNumberSplitter;
        public readonly char split = '.';

        public SplitterTests()
        {
            versionNumberSplitter = new VersionNumberSplitter();
        }

        [TestMethod]
        [DataRow("5.39.8.0")]
        public void TestSplitValidVersionNumber(string versionNumber)
        {
            int[] versionNumberArray = versionNumberSplitter.Split(versionNumber, split);
            Assert.IsTrue(new int[] { 5, 39, 8, 0 }.SequenceEqual(versionNumberArray));
        }



        [TestMethod]
        [DataRow("5.39.8.0L")]
        [ExpectedException(typeof(FormatException),
            "Attempted parsing of a string to an int was thrown correctly.")]
        public void TestSplitInvalidVersionNumber(string versionNumber)
        {
            versionNumberSplitter.Split(versionNumber, split);
        }
    }
}
