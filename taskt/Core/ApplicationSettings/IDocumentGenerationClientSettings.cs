namespace taskt.Core
{
    /// <summary>
    /// Interface for ClientSettings for Document Generation
    /// </summary>
    public interface IDocumentGenerationClientSettings : IClientSettings
    {
        /// <summary>
        /// enable r/w ShowSampleUsegeInDescription
        /// </summary>
        new bool ShowSampleUsageInDescription
        {
            get;
            set;
        }

        /// <summary>
        /// enable r/w ShowDefaultValueInDescription
        /// </summary>
        new bool ShowDefaultValueInDescription
        {
            get;
            set;
        }
    }
}
