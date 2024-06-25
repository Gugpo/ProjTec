using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.DataContext;
using ProjTec_XPInc.Models;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjTec_XPInc.Services.EmailSchedulerService
{
	public class EmailScheduler
	{
		private readonly ApplicationDbContext _context;

		private EmailScheduler(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Start()
		{
			var investments = _context.Investment.ToList();

			foreach (var investment in investments)
			{
				DateTime currentDate = DateTime.Now;
				DateTime DateVencimentInvestment = investment.Venciment;
				TimeSpan VerifyDate = DateVencimentInvestment - currentDate;

				string subject = "Investment Expiration";
				string sender = "ProjTec-XPInc";
				string message = $"The investment {investment.Name} will expire in {VerifyDate.Days} days";
				string emailManager = "youremail@gmail.com";

				if (VerifyDate.Days < 7)
					SendEmailService.SendEmail.SendMensageEmail(subject, sender, message, emailManager);
			}
		}
	}
}
