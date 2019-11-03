using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace MonkeyFinder.Model
{
	public partial class Monkey
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Location")]
		public string Location { get; set; }

		[JsonProperty("Details")]
		public string Details { get; set; }

		[JsonProperty("Image")]
		public string Image { get; set; }

		[JsonProperty("Population")]
		public long Population { get; set; }

		[JsonProperty("Latitude")]
		public double Latitude { get; set; }

		[JsonProperty("Longitude")]
		public double Longitude { get; set; }
	}

	public partial class Monkey
	{
		public static Monkey[] FromJson(string json) 
			=> JsonConvert.DeserializeObject<Monkey[]>(json, Converter.Settings);

		public static Monkey GenerateGoofyMonkey()
			=> new Monkey()
			{
				Name = "Kaylee Jensen",
				Details = "Kaylee Jensen is an energetic lovable monkey that loves other animals and snuggles!",
				Image = "",
				Population = 1,
				Location = "Moose Jaw",
				Latitude = 50.3916,
				Longitude = -105.5349
			};
	}

	public static class Serialize
	{
		public static string ToJson(this Monkey[] self) 
			=> JsonConvert.SerializeObject(self, Converter.Settings);
	}

	internal static class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}
