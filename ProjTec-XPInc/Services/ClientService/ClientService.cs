using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.DataContext;
using ProjTec_XPInc.Enums;
using ProjTec_XPInc.Models;

namespace ProjTec_XPInc.Services.ClientService
{
	public class ClientService : IClientServiceInterface
	{
		private readonly ApplicationDbContext _context;

		public ClientService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponseModel<ClientServiceModel>> BuyInvestmentClient(ClientServiceModel clientService, List<InvestmentModel> investmentClient)
		{
			try
			{
				ServiceResponseModel<ClientServiceModel> response = new ServiceResponseModel<ClientServiceModel>();

				var client = _context.ClientServices.FirstOrDefault(x => x.Id == clientService.Id);

				if (client == null)
					return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = "ClientService not found." };
				if (investmentClient == null)
					return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = "Investment not found." };

				investmentClient.ForEach(investment =>
				{
					client.Investment.Add(investment);
				});

				_context.ClientServices.Update(client);

				FinancialStatementModel financialStatement = new FinancialStatementModel
				{
					User = client.User,
					Investment = client.Investment,
					StatusInvestment = StatusInvestmentEnum.Buy
				};

				await _context.FinancialStatements.AddAsync(financialStatement);

				await _context.SaveChangesAsync();

				response.Data = clientService;

				return response;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponseModel<ClientServiceModel>> SellInvestmentClient(ClientServiceModel clientService, List<InvestmentModel> investmentClient)
		{
			try
			{
				ServiceResponseModel<ClientServiceModel> response = new ServiceResponseModel<ClientServiceModel>();

				var client = await _context.ClientServices.FirstOrDefaultAsync(x => x.Id == clientService.Id);

				if (client == null)
					return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = "ClientService not found." };
				if (investmentClient == null)
					return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = "Investment not found." };

				investmentClient.ForEach(investment =>
				{
					client.Investment.Remove(investment);
				});

				_context.ClientServices.Update(client);

				FinancialStatementModel financialStatement = new FinancialStatementModel
				{
					User = client.User,
					Investment = client.Investment,
					StatusInvestment = StatusInvestmentEnum.Sell
				};

				await _context.FinancialStatements.AddAsync(financialStatement);

				await _context.SaveChangesAsync();

				response.Data = clientService;

				return response;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<ClientServiceModel> { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponseModel<FinancialStatementModel>> GetFinancialStatement(string user)
		{
			try
			{
				ServiceResponseModel<FinancialStatementModel> response = new ServiceResponseModel<FinancialStatementModel>();

				var financialStatement = await _context.FinancialStatements.FirstOrDefaultAsync(x => x.User == user);

				response.Data = financialStatement;

				return response;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<FinancialStatementModel> { Success = false, Message = ex.Message };
			}
		}
	}
}
