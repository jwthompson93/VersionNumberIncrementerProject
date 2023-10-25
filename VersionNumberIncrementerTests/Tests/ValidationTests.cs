using VersionNumberIncrementer.Objects;
using VersionNumberIncrementer.Validation;

namespace VersionNumberIncrementerTests.Tests
{
    [TestClass]
    public class ValidationTests
    {
        

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 }, 3, 4)]
        public void TestValidationPasses(int[] versionNumberArray, 
            int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 
                major_release_position, minor_release_position);
            Assert.IsTrue(new VersionNumberValidator().Validate(versionNumber));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "Validates that at least one of the release position numbers are out of range")]
        [DataRow(new int[] { 5, 39, 8, 0 }, 4, 5)]
        public void TestValidationIsFalseIndexOutOfRange(int[] versionNumberArray, 
            int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 
                major_release_position, minor_release_position);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since Major and Minor Number Positions are the same")]
        [DataRow(new int[] { 5, 39, 8, 0 }, 3, 3)]
        public void TestValidationMajorMinorNumberIsSameException(int[] versionNumberArray, 
            int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 
                major_release_position, minor_release_position);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since Minor Number Position is lower than the Major Position")]
        [DataRow(new int[] { 5, 39, 8, 0 }, 3, 2)]
        public void TestValidationMinorNumberLowerThanMajorException(int[] versionNumberArray, 
            int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 
                major_release_position, minor_release_position);
            new VersionNumberValidator().Validate(versionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Throws Exception since release number is negative")]
        [DataRow(new int[] { 5, -39, 8, 0 }, 3, 2)]
        public void TestValidationReleaseNumberIsNegativeException(int[] versionNumberArray, 
            int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray, 
                major_release_position, minor_release_position);
            new VersionNumberValidator().Validate(versionNumber);
        }
    }
}
