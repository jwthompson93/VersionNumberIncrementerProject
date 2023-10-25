
/*
 * These Handler classes are used to read and/or write the version number from/to a location.
 * This interface can be reused so that several different inputs and outputs can be implemented
 * and used by this or other application.
 */

namespace VersionNumberIncrementer.Handler
{
    public interface IVersionNumberHandler
    {
        public string ReadVersionNumber();
        public bool WriteVersionNumber(string versionNumber);
    }
}
