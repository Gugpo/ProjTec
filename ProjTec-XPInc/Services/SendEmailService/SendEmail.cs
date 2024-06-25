using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ProjTec_XPInc.Services.SendEmailService
{
	public class SendEmail
	{
		public static string SendMensageEmail(string subject, string sender, string message, string emailManager)
		{
			try
			{
				bool validateEmail = ValidateEmailAddress(emailManager);

				if (!validateEmail)
					throw new System.Exception("Invalid email address");

				MailMessage mailMessage = new MailMessage(sender, "youremail@gmail.com", subject, message);

				SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
				smtpClient.EnableSsl = true;
				NetworkCredential cred = new NetworkCredential("youremail@gmail.com", "passoword");
				smtpClient.Credentials = cred;

				smtpClient.UseDefaultCredentials = true;

				smtpClient.Send(mailMessage);

				return "Email sent successfully";
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static bool ValidateEmailAddress(string emailAddress)
		{
			try
			{
				Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

				if (expressaoRegex.IsMatch(emailAddress))
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	
}
