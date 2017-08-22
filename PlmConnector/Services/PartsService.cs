using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlmConnector.Models;

namespace PlmConnector.Services
{
	public class PartsService : IPartsService
	{
		public Part GetByItemNumber(string itemNumber)
		{
			return new Part{ItemNumber = itemNumber, Name = "stub"};
		}

		public IEnumerable<Part> GetAll()
		{
			return new List<Part>();
		}
	}
}
