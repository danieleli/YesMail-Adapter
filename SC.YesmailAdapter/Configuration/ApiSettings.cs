using System;
using System.Configuration;
using System.Collections.Specialized;
using log4net;
using System.Text;

namespace SC.YesMailAdapter.Configuration
{
    public class ApiSettings
    {
        public static ILog _logger = LogManager.GetLogger(typeof(ApiSettings));

        public enum ConfigurationKeys
        {
            YesMailDomain,
            YesMailUserName,
            YesMailPassword,
            YesMailUrl,
            YesMailUseProxy
        }

        #region -- Constructors --
       
        public ApiSettings()
            : this(ConfigurationManager.AppSettings)
        {
        }

        public ApiSettings(NameValueCollection appSettings)
        {
            this.Url = appSettings[ConfigurationKeys.YesMailUrl.ToString()];
            this.UserName = appSettings[ConfigurationKeys.YesMailUserName.ToString()];
            this.Password = appSettings[ConfigurationKeys.YesMailPassword.ToString()];
            this.Domain = appSettings[ConfigurationKeys.YesMailDomain.ToString()];

            this.UseProxy = bool.Parse(appSettings[ConfigurationKeys.YesMailUseProxy.ToString()]);
            
            if (this.UseProxy)
            {
                this.ProxySettings = new ProxySettings(appSettings);    
            }

            LogSettings(this);
        }

        private void LogSettings(ApiSettings apiSettings)
        {         
            var sb = new StringBuilder();

            sb.Append("\n\nApiSettings\n-----------\n")
                .Append("Url: ").Append(apiSettings.Url).Append("\n")
                .Append("Domain: ").Append(apiSettings.Domain).Append("\n")
                .Append("UserName: ").Append(apiSettings.UserName).Append("\n")
                .Append("Password: ").Append(apiSettings.Password).Append("\n")
                .Append("UseProxy: ").Append(apiSettings.UseProxy).Append("\n");
            
            _logger.Debug(sb.ToString());
        
        }

        public ApiSettings(String domain, String userName, String password, String url, bool useProxy)
        {
            this.Url = url;
            this.UserName = userName;
            this.Password = password;
            this.Domain = domain;
            this.UseProxy = useProxy;
            this.ProxySettings = new ProxySettings();
        }

        public ApiSettings(String domain, String userName, String password, String url, bool useProxy, 
            String proxyDomain, String proxyUserName, String proxyPassword, String proxyAddress, int proxyPort)
        {
            this.Url = url;
            this.UserName = userName;
            this.Password = password;
            this.Domain = domain;
            this.UseProxy = useProxy;
            this.ProxySettings = new ProxySettings(proxyDomain, proxyUserName, proxyPassword, proxyAddress, proxyPort);
        }

        #endregion -- Constructors --

        public string Url { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool UseProxy { get; set; }

        public ProxySettings ProxySettings { get; set; }

        public string Domain{ get; set; }

        
    }
}