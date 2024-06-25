using ProjTec_XPInc.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjTec_XPInc.Models
{
	public class FinancialStatementModel
	{
		[Key]
		public int Id { get; set; }
		public string? User { get; set; }
		public List<InvestmentModel>? Investment { get; set; }
		public StatusInvestmentEnum StatusInvestment { get; set; }
	}
}
