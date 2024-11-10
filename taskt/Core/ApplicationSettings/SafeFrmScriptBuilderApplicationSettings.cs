namespace taskt.Core
{
    /// <summary>
    /// ApplicatioSettings for frmScriptBuilder
    /// </summary>
    public class SafeFrmScriptBuilderApplicationSettings : SafeApplicationSettings
    {
        /// <summary>
        /// taskt client settings
        /// </summary>
        public new IFrmScriptBuilderClientSettings ClientSettings { get; private set; }

        public SafeFrmScriptBuilderApplicationSettings(ApplicationSettings appSettings) : base(appSettings)
        {
            ClientSettings = new SafeFrmScriptBuilderClientSettings(appSettings.GetClientSettings());
        }
    }
}
