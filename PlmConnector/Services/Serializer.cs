using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace PlmConnector.Services
{
	public class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding => Encoding.UTF8;
	}
	public static class Serializer
	{
		public static string Serialize<T>(this T value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			var xmlserializer = new XmlSerializer(typeof(T));
			var stringWriter = new Utf8StringWriter();

			using (var writer = XmlWriter.Create(stringWriter))
			{
				xmlserializer.Serialize(writer, value);
				return stringWriter.ToString();
			}
		}

		public static string SerializeJson<T>(this T value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			settings.Converters.Add(new StringEnumConverter());


			var jsonSerialized = JsonConvert.SerializeObject(value, Formatting.Indented, settings);

			return jsonSerialized;

		}
	}
}
