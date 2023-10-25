using CommandLine;

namespace VersionNumberIncrementer.Options
{
    internal interface IGeneralOptions
    {
        [Option("release_type", Required = true, HelpText = "Determines the release type to be incremented (Major | Minor)")]
        public string release_type { get; set; }

        [Option("version_number_file", Required = true, HelpText = "The file path for the Version Number file")]
        public string version_number_file { get; set; }

        [Option("major_release_position", Default = 3, Required = false, HelpText = "Determines where the major version number is positioned in the Version Number")]
        public int major_release_position { get; set; }

        [Option("minor_release_position", Default = 4, Required = false, HelpText = "Determines where the minor version number is positioned in the Version Number")]
        public int minor_release_position { get; set; }

        [Option("version_number_separator", Default = '.', Required = false, HelpText = "The character that separates the numbers in the Version Number")]
        public char version_number_separator { get; set; }
    }
}
