using VersionNumberIncrementer.Options;
using VersionNumberIncrementer.Handler;
using VersionNumberIncrementer.Objects;
using VersionNumberIncrementer.Splitter;
using VersionNumberIncrementer.Validation;

namespace VersionNumberIncrementer.Process
{
    public class VersionNumberProcess
    {
        private VersionNumber versionNumberObject;
        private IVersionNumberHandler versionNumberHandler;
        private IOptions options;

        public VersionNumberProcess(IOptions options)
        {
            this.options = options;
            versionNumberHandler = new FileVersionNumberHandler(options.version_number_file);
        }

        public void Process()
        {
            // Obtains the Version Number from the source
            string versionNumberString = GetVersionNumber();

            // Splits the version number into an integer array
            int[] versionNumberArray = SplitVersionNumber(versionNumberString, options.version_number_separator);

            // Places the integer array into a VersionNumber object
            versionNumberObject = new VersionNumber(versionNumberArray, 
                options.major_release_position, options.minor_release_position);

            try
            {
                // Validates the version number
                new VersionNumberValidator().Validate(versionNumberObject);

                // Increments the version number
                IncrementVersionNumber(options.release_type, options.version_number_separator);

                // Writes the version number to file
                WriteVersionNumber(options.version_number_separator);
            }
            catch (Exception ex)
            {
                // If validation fails, an exception is thrown, the
                // message is outputted and the application is exited
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting...");
                System.Environment.Exit(0);
            }
        }

        // Gets the version number from the file specified
        private string GetVersionNumber()
        {
            string versionNumber = versionNumberHandler.ReadVersionNumber();
            Console.WriteLine("Current Version: {0}", versionNumber);

            return versionNumber;
        }

        // Splits the version number in an array to be processed
        private int[] SplitVersionNumber(string versionNumber, char separator)
        {
            VersionNumberSplitter versionNumberSplitter = new VersionNumberSplitter();
            int[] versionNumberArray = versionNumberSplitter.Split(versionNumber, separator);
            return versionNumberArray;
        }

        // Increments the version number based on the parameters passed
        private void IncrementVersionNumber(string release_type, char separator)
        {
            if(release_type.ToLower().Equals("major"))
            {
                versionNumberObject.incrementMajorVersion();
            }
            else if(release_type.ToLower().Equals("minor"))
            {
                versionNumberObject.incrementMinorVersion();
            }

            Console.WriteLine("New Version: {0}", versionNumberObject.getFormattedVersionNumber(separator));
        }

        // Writes the version number to the file
        private void WriteVersionNumber(char separator)
        {
            if(versionNumberHandler.WriteVersionNumber(versionNumberObject.getFormattedVersionNumber(separator)))
            {
                Console.WriteLine("New version written to file");
            }
            else
            {
                Console.WriteLine("Unable to write new version to file");
            }
        }
    }
}