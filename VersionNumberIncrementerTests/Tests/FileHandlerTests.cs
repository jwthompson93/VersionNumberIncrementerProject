using VersionNumberIncrementer.Handler;

namespace VersionNumberIncrementerTests.Tests
{
    [TestClass]
    public class FileHandlerTests
    {
        private readonly string filePath;
        private readonly string testOutFilePath;

        public FileHandlerTests()
        {
            filePath = "..\\..\\..\\ProductInfo.txt";
            testOutFilePath = "..\\..\\..\\ProductInfo_test.txt";
        }

        [TestMethod]
        public void TestReadFileIsNotNull()
        {
            Console.WriteLine(filePath);
            IVersionNumberHandler versionNumberExtractor = new FileVersionNumberHandler(filePath);
            string versionNumber = versionNumberExtractor.ReadVersionNumber();
            Assert.IsNotNull(versionNumber);
        }

        [TestMethod]
        public void TestReadFileIsRetreivable()
        {
            Console.WriteLine(filePath);
            IVersionNumberHandler versionNumberExtractor = new FileVersionNumberHandler(filePath);
            string versionNumber = versionNumberExtractor.ReadVersionNumber();
            Assert.AreEqual("5.39.13.0", versionNumber);
        }


        [TestMethod]
        public void TestWriteFile()
        {
            Console.WriteLine(filePath);
            IVersionNumberHandler versionNumberExtractor = new FileVersionNumberHandler(testOutFilePath);
            bool isWritten = versionNumberExtractor.WriteVersionNumber("5.39.8.1");
            Assert.IsTrue(isWritten);
        }
    }
}