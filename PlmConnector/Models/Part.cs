using System.Collections.Generic;

namespace PlmConnector.Models
{
	public class Part
	{
		public string ItemNumber { get; set; }
		public string User { get; set; }
		public string Revision { get; set; }
		public string Id { get; set; }

		public string Classification { get; set; }
		public string EhtProduction { get; set; }
		public string EhtSubclass { get; set; }
		public string Name { get; set; }

		public string KamDescription2 { get; set; }
		public string KamUom { get; set; }
		public string KamItemType { get; set; }
		public string KamLotSerialControl { get; set; }

		public string KamKsup { get; set; }
		public string KamPm { get; set; }
		public string KamProdLine { get; set; }
		public string KamThirdLevelClass { get; set; }

		public string ReleaseDate { get; set; }
		public string MajorRev { get; set; }
		public string MinorRev { get; set; }

		public List<BomPart> BomParts { get; set; }

	}

	public class BomPart
	{
		public string Parent { get; set; }
		public string KamBomRef { get; set; }
		public string ItemNumber { get; set; }

		public string Quantity { get; set; }
		public string KamStructureType { get; set; }

		public List<ManufacturerPart> ManufacturerParts { get; set; }
	}

	public class ManufacturerPart
	{
		public string ItemNumber { get; set; }
		public string Name { get; set; }
		public string Manufacturer { get; set; }
	}
}