namespace taskt.Core
{
    /// <summary>
    /// SafeApplicationSettings for AutomationEngineInstance
    /// </summary>
    public class SafeAutomationEngineInstanceApplicationSettings : SafeApplicationSettings
    {
        public new SafeAutomationEngineInstanceEngineSettings EngineSettings { get; set; }

        public SafeAutomationEngineInstanceApplicationSettings(ApplicationSettings appSettings) : base(appSettings) 
        {
            EngineSettings = new SafeAutomationEngineInstanceEngineSettings(appSettings.GetEngineSettings());
        }
    }
}
