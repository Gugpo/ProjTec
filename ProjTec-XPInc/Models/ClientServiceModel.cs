using ProjTec_XPInc.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjTec_XPInc.Models
{
	public class ClientServiceModel
	{
		[Key]
		public int Id { get; set; }
		public string? User { get; set; }
		public virtual List<InvestmentModel> Investment { get; set; }
	}
}
