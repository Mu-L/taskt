namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for to specifiy file path properties
    /// </summary>
    public interface IFilePathProperties : ILExpandableProperties
    {
        /// <summary>
        /// target file path
        /// </summary>
        string v_TargetFilePath { get; set; }
    }
}
