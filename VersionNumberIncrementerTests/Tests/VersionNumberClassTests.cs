using VersionNumberIncrementer.Objects;
using VersionNumberIncrementer.Validation;

namespace VersionNumberIncrementerTests.Tests
{
    [TestClass]
    public class VersionNumberClassTests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestGetFormattedVersionNumber(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 4);
            Assert.AreEqual("5.39.8.0", versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestVersionNumberIncrementMajorVersion(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 4);
            versionNumber.incrementMajorVersion();
            Assert.AreEqual("5.39.9.0", versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestVersionNumberIncrementMinorVersion(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 4);
            versionNumber.incrementMinorVersion();
            Assert.AreEqual("5.39.8.1", versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 2 })]
        public void TestVersionNumberIncrementMajorVersionResetMinorVersion(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 4);
            versionNumber.incrementMajorVersion();
            Assert.AreEqual("5.39.9.0", versionNumber.getFormattedVersionNumber('.'));
        }



        [TestMethod]
        [DataRow(new int[] { 5, 39, 8 })]
        public void TestVersionNumberVariableThreeIntegers(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 2, 3);
            versionNumber.incrementMajorVersion();
            Assert.AreEqual("5.40.0", versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39 })]
        public void TestVersionNumberVariableTwoIntegers(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 1, 2);
            versionNumber.incrementMajorVersion();
            Assert.AreEqual("6.0", versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestValidationPasses(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 4);
            Assert.IsTrue(new VersionNumberValidator().Validate(versionNumber));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "Validates that at least one of the release position numbers are out of range")]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestValidationIsFalseIndexOutOfRange(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 4, 5);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since Major and Minor Number Positions are the same")]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestValidationMajorMinorNumberIsSameException(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 3);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since Minor Number Position is lower than the Major Position")]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestValidationMinorNumberLowerThanMajorException(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 2);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since release number is negative")]
        [DataRow(new int[] { 5, 39, 8, 0 })]
        public void TestValidationReleaseNumberIsNegativeException(int[] versionNumberArray)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 3, 2);
            new VersionNumberValidator().Validate(versionNumber);
        }
    }
}
