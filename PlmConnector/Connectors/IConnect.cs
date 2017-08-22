using System.Collections.Generic;
using Aras.IOM;
using PlmConnector.Services;

namespace PlmConnector.Connectors
{
	public interface IConnector
	{
		HttpServerConnection ServerConnection { get; set; }
		List<KeyValuePair<string, string>> Config { get; set; }
		HttpServerConnection Connect();

		event LoggedEventHandler Logged;

	}
}
