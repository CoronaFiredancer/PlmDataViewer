using System.Collections.Generic;
using Aras.IOM;
using PlmConnector.Connectors;
using PlmConnector.Models;

namespace PlmConnector.Services
{
	public class PartsService : IPartsService
	{
		private readonly IConnector _plmConnector;
		private readonly Innovator _inn;

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
			var bomRel = item.createRelationship("Part BOM", "get");
			var bompart = bomRel.createRelatedItem("Part", "get");
			var amlRel = bompart.createRelationship("Part AML", "get");
			amlRel.createRelatedItem("Manufacturer Part", "get");



			item = item.apply();

			if (!item.isError() && !item.isEmpty())
			{
				item.fetchRelationships("Part BOM");
				var bomRelationships = item.getRelationships();
				var relCount = bomRelationships.getItemCount();

				var bomParts = new List<BomPart>();

				for (var i = 0; i < relCount; i++)
				{
					var rel = bomRelationships.getItemByIndex(i);

					var relatedItem = rel.getPropertyItem("related_id");
					
					var bomPart = new BomPart
					{
						ItemNumber = relatedItem.getProperty("item_number"),
						Quantity = rel.getProperty("quantity"),
						RefDes = rel.getProperty("reference_designator"),
					};

					relatedItem.fetchRelationships("Part AML");
					var amlRelationships = relatedItem.getRelationships();
					var amlCount = amlRelationships.getItemCount();

					var amlParts = new List<ManufacturerPart>();

					for (var j = 0; j < amlCount; j++)
					{
						var amlRelItem = amlRelationships.getItemByIndex(j);
						var amlRelatedItem = amlRelItem.getPropertyItem("related_id");

						var manuf = amlRelatedItem.getPropertyAttribute("manufacturer", "keyed_name");

						var mfgPart = new ManufacturerPart
						{
							ItemNumber = amlRelatedItem.getProperty("item_number"),
							Manufacturer = manuf
						};

						amlParts.Add(mfgPart);
					}

					bomPart.ManufacturerParts = amlParts;

					bomParts.Add(bomPart);
				}


				var part = new Part
				{
					Id = item.getProperty("id"),

					ItemNumber = item.getProperty("item_number"),
					Classification = item.getProperty("classification"),
					EhtSubclass = item.getProperty("eht_subclass"),
					KamThirdLevelClass = item.getProperty("kam_3rd_level_class"),
					Name = item.getProperty("name"),
					KamDescription2 = item.getProperty("kam_description_2"),
					MajorRev = item.getProperty("major_rev"),
					MinorRev = item.getProperty("minor_rev"),
					ReleaseDate = item.getProperty("release_date"),
					EhtProduction = item.getProperty("eht_production_lc_state"),
					KamItemType = item.getProperty("kam_item_type"),
					KamKsup = item.getProperty("kam_ksup"),
					KamLotSerialControl = item.getProperty("kam_lot_serial_ctrl"),
					KamPm = item.getProperty("kam_purchased_or_manufactured"),
					KamProdLine = item.getProperty("kam_prodline"),
					KamUom = item.getProperty("kam_uom"),
					BomParts = bomParts
				};

				return part;
			}

			return null;
		}

		public IEnumerable<Part> GetAll()
		{
			return new List<Part>();
		}
	}
}
