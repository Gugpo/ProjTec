using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.DataContext;
using ProjTec_XPInc.Services.ClientService;
using ProjTec_XPInc.Services.EmailSchedulerService;
using ProjTec_XPInc.Services.InvestmentManagementService;
using ProjTec_XPInc.Services.SendEmailService;
using System.Reflection;

internal class Program
{
	private static void Main(string[] args, EmailScheduler emailScheduler)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddScoped<IClientServiceInterface, ClientService>();
		builder.Services.AddScoped<IInvestmentManagementInterface, InvestmentManagement>();

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();
		app.Run();

		emailScheduler.Start();
		
	}
}