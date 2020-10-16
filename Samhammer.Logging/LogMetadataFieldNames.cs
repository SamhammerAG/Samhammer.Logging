namespace Samhammer.Logging
{
    /// <summary>
    /// these fields will be included in the details of all logs. If undesired, they can be removed from the details when implementing BaseLogger.Log()
    /// </summary>
    public class LogMetadataFieldNames
    {
        public const string MemberName = "MemberName";
        public const string SourceFilePath = "SourceFilePath";
        public const string SourceLineNumber = "SourceLineNumber";
        /// <summary>
        /// only used if an Exception is actually logged
        /// </summary>
        public const string Exception = "Exception";
    }
}
