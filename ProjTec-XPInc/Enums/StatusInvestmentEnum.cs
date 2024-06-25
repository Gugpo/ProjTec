using System.Text.Json.Serialization;

namespace ProjTec_XPInc.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum StatusInvestmentEnum
	{
		Sell,
		Buy
	}
}
