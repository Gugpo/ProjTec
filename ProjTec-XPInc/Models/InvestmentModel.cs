using System.ComponentModel.DataAnnotations;

namespace ProjTec_XPInc.Models
{
	public class InvestmentModel
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public DateTime Venciment { get; set; }

	}
}
