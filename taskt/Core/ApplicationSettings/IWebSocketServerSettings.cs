namespace taskt.Core
{
    /// <summary>
    /// interface ServerSettings for WebSocket
    /// </summary>
    public interface IWebSocketServerSettings : IServerSettings
    {
        /// <summary>
        /// enable r/w ConnectToServerOnStartup
        /// </summary>
        new bool ConnectToServerOnStartup
        {
            get;
            set;
        }

        /// <summary>
        /// enable r/w ServerConnectionEnabled
        /// </summary>
        new bool ServerConnectionEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// enable r/w  ServerPublicKey
        /// </summary>
        new string ServerPublicKey
        {
            get;
            set;
        }
    }
}
