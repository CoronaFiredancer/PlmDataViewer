using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aras.IOM;
using PlmConnector.Connectors;
using PlmConnector.Models;

namespace PlmConnector.Services
{
	public class PartsService : IPartsService
	{
		private readonly IConnector _plmConnector;
		private Innovator _inn;

		public PartsService(IConnector plmConnector)
		{
			if(_plmConnector == null)
			{
				_plmConnector = plmConnector;
			}

			_plmConnector.Connect();

			var kamInnovatorItem = new KamInnovatorItem(_plmConnector.ServerConnection);

			_inn = kamInnovatorItem.Inn;
		}

		public Part GetByItemNumber(string itemNumber)
		{

			var item = _inn.newItem("Part", "get");
			item.setProperty("item_number", itemNumber);
			item = item.apply();

			return new Part{ItemNumber = itemNumber, Name = "stub"};
		}

		public IEnumerable<Part> GetAll()
		{
			return new List<Part>();
		}
	}
}
