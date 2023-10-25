namespace VersionNumberIncrementer.Options
{
    public class IOptions : IGeneralOptions, IFileOptions
    {
        // IGeneralOptions variables
        public string release_type { get; set; }
        public int major_release_position { get; set; }
        public int minor_release_position { get; set; }
        public char version_number_separator { get; set; }

        // IFileOptions variables
        public string version_number_file { get; set; }
    }
}
