namespace PlmConnector.Services
{
	public interface ILoggerService
	{
		string EventSource { get; set; }
		string EventLogName { get; set; }
		void Setup();
		void OnMessageLogged(object source, LogEventArgs args);
	}
}
