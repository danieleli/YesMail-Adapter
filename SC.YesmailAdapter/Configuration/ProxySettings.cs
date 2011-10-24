using System;
using System.Configuration;
using System.Collections.Specialized;
using log4net;
using System.Text;

namespace SC.YesMailAdapter.Configuration
{
    public class ProxySettings
    {
        public static ILog _logger = LogManager.GetLogger(typeof(ProxySettings));

        public enum ConfigurationKeys
        {
            YesMailProxyDomain,
            YesMailProxyUserName,
            YesMailProxyPassword,
            YesMailProxyUrl,
            YesMailProxyPort
        }

        public ProxySettings()
            : this(ConfigurationManager.AppSettings)
        {
        }

        public ProxySettings(NameValueCollection appSettings)
        {
            this.Url = appSettings[ConfigurationKeys.YesMailProxyUrl.ToString()];
            this.UserName = appSettings[ConfigurationKeys.YesMailProxyUserName.ToString()];
            this.Password = appSettings[ConfigurationKeys.YesMailProxyPassword.ToString()];
            this.Domain = appSettings[ConfigurationKeys.YesMailProxyDomain.ToString()];
            this.Port = int.Parse(Convert.ToString(appSettings[ConfigurationKeys.YesMailProxyPort.ToString()]));
        }

        public ProxySettings(String domain, String userName, String password, String url, int port)
        {
            this.Url = url;
            this.UserName = userName;
            this.Password = password;
            this.Domain = domain;
            this.Port = port;
        }

        private void LogSettings(ProxySettings proxySettings)
        {
            var sb = new StringBuilder();

            sb.Append("\n\nProxySettings\n-----------\n")
                .Append("Url: ").Append(proxySettings.Url).Append("\n")
                .Append("Domain: ").Append(proxySettings.Domain).Append("\n")
                .Append("UserName: ").Append(proxySettings.UserName).Append("\n")
                .Append("Password: ").Append(proxySettings.Password).Append("\n")
                .Append("Port: ").Append(proxySettings.Port).Append("\n");

            _logger.Debug(sb.ToString());

        }

        public string Url { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string Domain { get; set; }

    }
}