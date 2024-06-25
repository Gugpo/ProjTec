using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.Models;

namespace ProjTec_XPInc.DataContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<ClientServiceModel> ClientServices { get; set; }
		public DbSet<InvestmentModel> Investment { get; set; }
		public DbSet<FinancialStatementModel> FinancialStatements { get; set; }



	}
}
