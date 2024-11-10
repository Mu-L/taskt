namespace taskt.Core
{
    /// <summary>
    /// interface ClientSettings for frmScriptBuilder
    /// </summary>
    public interface IFrmScriptBuilderClientSettings : IClientSettings
    {
        /// <summary>
        /// enable r/w InsertCommandsInline
        /// </summary>
        new bool InsertCommandsInline
        {
            get;
            set;
        }

        /// <summary>
        /// enable r/w ShowCommandSearchBar
        /// </summary>
        new bool ShowCommandSearchBar
        {
            get;
            set;
        }
    }
}
