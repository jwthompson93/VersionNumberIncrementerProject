

namespace VersionNumberIncrementer.Handler
{
    public class FileVersionNumberHandler : IVersionNumberHandler
    {
        private string filePath;

        public FileVersionNumberHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public string ReadVersionNumber()
        {
            string versionNumber = "";


            try
            {
                // Extracts the contents of a file from a file
                // Trim will remove any of the /t /n or /r
                versionNumber = File.ReadAllText(filePath).Trim();
            }
            catch (FileNotFoundException ex)
            {
                // Prints a console error and exits the program when the file path
                // cannot be found
                Console.WriteLine("ERROR: File path not found: " + filePath);
                Console.WriteLine(ex.Message);
                System.Environment.Exit(0);
            }

            return versionNumber;
        }

        public bool WriteVersionNumber(string versionNumber)
        {
            try
            {
                // Writes the version number to a file and returns true if successful
                File.WriteAllText(filePath, versionNumber);
                return true;
            }
            catch (FileNotFoundException fnfex)
            {
                // Prints a console error and exits the program when the file path
                // cannot be found
                Console.WriteLine("ERROR: File path not found: " + filePath);
                Console.WriteLine(fnfex.Message);
                System.Environment.Exit(0);
            }
            catch (UnauthorizedAccessException uaex)
            {
                // Prints a console error and exits the program when the file doesn't
                // have permissions to write to the file
                Console.WriteLine("ERROR: Cannot write to file: " + filePath);
                Console.WriteLine(uaex.Message);
                System.Environment.Exit(0);
            }

            return false;
        }
    }
}
