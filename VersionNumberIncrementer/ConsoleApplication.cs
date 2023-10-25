
using CommandLine;
using VersionNumberIncrementer.Options;
using VersionNumberIncrementer.Process;

namespace ConsoleApplication
{
    public class ConsoleApplication
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<IOptions>(args)
                .WithParsed(Run);
        }

        private static void Run(IOptions opts)
        {
            string release_type = opts.release_type.ToLower();

            // Determines whether the input is valid for the version_type
            if (release_type.Equals("major") || release_type.Equals("minor"))
            {
                VersionNumberProcess versionNumberProcess = 
                    new VersionNumberProcess(opts);
                versionNumberProcess.Process();
            }
            else
            {
                Console.WriteLine("ERROR: --release_type option is required to be either (major | minor)");
                Console.WriteLine("Exiting...");
                System.Environment.Exit(0);
            }
        }
    }
}
