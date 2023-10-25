using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionNumberIncrementer.Objects;

namespace VersionNumberIncrementer.Validation
{
    public class VersionNumberValidator : IValidator<VersionNumber>
    {
        // Conducts all of the validation
        public bool Validate(VersionNumber versionNumber)
        {
            int arrayLength = versionNumber.versionNumberArray.Length;
            if (!CheckIfVersionNumberIsInRange(arrayLength, versionNumber.majorNumberPosition) ||
                !CheckIfVersionNumberIsInRange(arrayLength, versionNumber.minorNumberPosition))
            {
                throw new IndexOutOfRangeException("Major or Minor number positions must be " +
                    "lower than or equal to the amount of numbers in the Version Number");
            }

            if(!CheckIfMajorIsLowestPosition(versionNumber.majorNumberPosition, versionNumber.minorNumberPosition))
            {
                throw new Exception("Minor release number must not be higher or equal to the Major Release number");
            }

            if (!CheckIfNumberIsNotNegative(versionNumber.versionNumberArray[versionNumber.majorNumberPosition])
                || !CheckIfNumberIsNotNegative(versionNumber.versionNumberArray[versionNumber.minorNumberPosition]))
            {
                throw new Exception("Release numbers should not be negative");
            }

            return true;
        }

        // Checks whether the release number is in range of the Version Number
        private bool CheckIfVersionNumberIsInRange(int arrayLength, int releaseNumberPosition)
        {
            return releaseNumberPosition + 1 <= arrayLength;
        }

        // Checks whether the Major release number is the lower in the
        // array than the Minor release number
        private bool CheckIfMajorIsLowestPosition(int majorReleasePosition, int minorReleasePosition)
        {
            return majorReleasePosition < minorReleasePosition;
        }

        private bool CheckIfNumberIsNotNegative(int releaseNumber)
        {
            return releaseNumber >= 0;
        }
    }
}
