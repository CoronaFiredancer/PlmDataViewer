using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Aras.IOM;
using PlmConnector.Services;

namespace PlmConnector.Connectors
{
	public class ArasConnector : IConnector
	{
		public List<KeyValuePair<string, string>> Config { get; set; }
		public HttpServerConnection ServerConnection { get; set; }
		public event LoggedEventHandler Logged;

		public ArasConnector()
		{
			Config = new List<KeyValuePair<string, string>>();
			var appSettings = ConfigurationManager.AppSettings;

			if (appSettings.Count == 0)
			{

			}
			else
			{
				foreach (var key in appSettings.AllKeys)
				{

					if (key.StartsWith("innovator"))
					{
						Config.Add(new KeyValuePair<string, string>(key, appSettings[key]));
					}
				}
			}
		}

		public HttpServerConnection Connect()
		{
			ServerConnection = IomFactory.CreateHttpServerConnection(
				Config[0].Value, Config[1].Value, Config[2].Value, Config[3].Value
			);
			ServerConnection.Timeout = 100000;
			ServerConnection.ReadWriteTimeout = 100000;

			Logged?.Invoke(this, new LogEventArgs { Message = $"Connected to ARAS with following parameters\r\nServer: {Config[0].Value}\r\nDatabase: {Config[1].Value}\r\nUser: {Config[2].Value}\r\nPass: ", LogEntryType = EventLogEntryType.Information });

			return ServerConnection;
		}
	}
}
