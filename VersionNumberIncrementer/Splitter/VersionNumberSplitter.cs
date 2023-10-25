using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionNumberIncrementer.Splitter
{
    public class VersionNumberSplitter
    {
        public int[] Split(string VersionNumber, char delimiter)
        {
            // Splits the array using a delimiter
            string[] VersionNumberStringArray = VersionNumber.Split(delimiter);
            // Creates an array of the same length to store the numeric values
            int[] versionNumberArray = new int[VersionNumberStringArray.Length];

            // Iterates through the VersionNumberString array and attempts to parse the String into an integer
            // If the parse fails, a FormatException is thrown
            for (int i = 0; i < VersionNumberStringArray.Length; i++)
            {
                if (!int.TryParse(VersionNumberStringArray[i], out versionNumberArray[i]))
                {
                    throw new FormatException();
                }
            }

            return versionNumberArray;
        }
    }
}
