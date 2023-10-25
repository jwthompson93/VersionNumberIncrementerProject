using VersionNumberIncrementer.Handler;
using VersionNumberIncrementer.Options;

namespace Version_Number_Incrementer
{
    public class VersionNumberHandlerFactory
    {
        public static IVersionNumberHandler GetVersionNumberHandler(IOptions opts)
        {
            switch(opts.release_type)
            {
                default:
                    return new FileVersionNumberHandler(opts.version_number_file);
            }
        }
    }
}
