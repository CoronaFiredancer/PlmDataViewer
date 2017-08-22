using Aras.IOM;

namespace PlmConnector.Connectors
{
	public class KamInnovatorItem : Item
	{
		public Innovator Inn;

		public KamInnovatorItem(IServerConnection serverConnection) : base(serverConnection)
		{
			Inn = getInnovator();
		}
	}
}
