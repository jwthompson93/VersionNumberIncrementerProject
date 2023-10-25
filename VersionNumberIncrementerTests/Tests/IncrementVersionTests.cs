using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionNumberIncrementer.Objects;

namespace VersionNumberIncrementerTests.Tests
{
    [TestClass]
    public class IncrementVersionTests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 }, "5.39.8.0", 3, 4)]
        public void TestGetFormattedVersionNumber(int[] versionNumberArray,
            string expectedResult, int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray,
                major_release_position, minor_release_position);
            Assert.AreEqual(expectedResult, versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 }, "5.39.9.0", 3, 4)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "5.39.9.0", 3, 4)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "5.40.0.0", 2, 3)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "6.0.0.0", 1, 2)]
        [DataRow(new int[] { 5, 39, 8 }, "5.40.0", 2, 3)]
        [DataRow(new int[] { 5, 39, 8 }, "6.0.0", 1, 2)]
        [DataRow(new int[] { 5, 39 }, "6.0", 1, 2)]
        public void TestVersionNumberIncrementMajorVersion(int[] versionNumberArray,
            string expectedResult, int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray,
                major_release_position, minor_release_position);
            versionNumber.incrementMajorVersion();
            Assert.AreEqual(expectedResult, versionNumber.getFormattedVersionNumber('.'));
        }

        [TestMethod]
        [DataRow(new int[] { 5, 39, 8, 0 }, "5.39.8.1", 3, 4)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "5.39.8.3", 3, 4)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "5.39.9.0", 2, 3)]
        [DataRow(new int[] { 5, 39, 8, 2 }, "5.40.0.0", 1, 2)]
        [DataRow(new int[] { 5, 39, 8 }, "5.39.9", 2, 3)]
        [DataRow(new int[] { 5, 39, 8 }, "5.40.0", 1, 2)]
        [DataRow(new int[] { 5, 39 }, "5.40", 1, 2)]
        public void TestVersionNumberIncrementMinorVersion(int[] versionNumberArray,
            string expectedResult, int major_release_position, int minor_release_position)
        {
            VersionNumber versionNumber = new VersionNumber(versionNumberArray,
                major_release_position, minor_release_position);
            versionNumber.incrementMinorVersion();
            Assert.AreEqual(expectedResult, versionNumber.getFormattedVersionNumber('.'));
        }
    }
}
