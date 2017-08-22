using System.Diagnostics;

namespace PlmConnector.Services
{
	public class LoggerService : ILoggerService
	{
		public string EventSource { get; set; }
		public string EventLogName { get; set; }

		public void OnMessageLogged(object source, LogEventArgs args)
		{
			var eventLog = new EventLog
			{
				Source = EventSource,
				Log = EventLogName
			};
			eventLog.WriteEntry(args.Message, args.LogEntryType);
		}

		public void Setup()
		{
			if (!EventLog.SourceExists(EventSource))
			{
				EventLog.CreateEventSource(EventSource, EventLogName);
			}
		}
	}
}
