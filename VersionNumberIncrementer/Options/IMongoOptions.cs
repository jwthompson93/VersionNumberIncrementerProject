using CommandLine;

namespace VersionNumberIncrementer.Options
{
    internal class IMongoOptions
    {
        [Option("host", Default = "localhost", SetName = "mongo", HelpText = "The host of the MongoDB database")]
        public string host { get; set; }

        [Option("port", Default = "27017", SetName = "mongo", HelpText = "The port of the MongoDB database")]
        public string port { get; set; }

        [Option("database", Required = true, SetName = "mongo", HelpText = "The database which contains the Version Number")]
        public string database { get; set; }

        [Option("collection", Required = true, SetName = "mongo", HelpText = "The collection which contains the Version Number")]
        public string collection { get; set; }

        [Option("field_name", Required = true, SetName = "mongo", HelpText = "The field name for the Version Number contained in the collection")]
        public string field_name { get; set; }
    }
}
