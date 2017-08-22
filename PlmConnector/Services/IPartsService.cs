using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlmConnector.Models;

namespace PlmConnector.Services
{
	public interface IPartsService
	{
		Part GetByItemNumber(string itemNumber);
		IEnumerable<Part> GetAll();
	}
}
