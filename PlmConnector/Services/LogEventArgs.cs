using System;
using System.Diagnostics;

namespace PlmConnector.Services
{
	public delegate void LoggedEventHandler(object sender, LogEventArgs eventArgs);

	public class LogEventArgs : EventArgs
	{
		public string Message { get; set; }
		public EventLogEntryType LogEntryType { get; set; }
	}
}
