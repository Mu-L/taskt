using System;

namespace taskt.Core
{
    /// <summary>
    /// interface for HttpServerClient
    /// </summary>
    public interface IHttpServerClientServerSettings : IServerSettings
    {
        /// <summary>
        /// enable r/w HTTPGuid
        /// </summary>
        new Guid HTTPGuid
        {
            get;
            set;
        }

        /// <summary>
        /// enable r/w HTTPServerURL
        /// </summary>
        new string HTTPServerURL
        {
            get;
            set;
        }
    }
}
