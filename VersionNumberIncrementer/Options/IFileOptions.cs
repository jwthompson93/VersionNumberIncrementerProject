using CommandLine;

namespace VersionNumberIncrementer.Options
{
    internal interface IFileOptions
    {
        [Option("version_number_file", SetName = "file", HelpText = "The file path for the Version Number file")]
        public string version_number_file { get; set; }
    }
}
