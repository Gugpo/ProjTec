using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.Enums;
using ProjTec_XPInc.Models;

namespace ProjTec_XPInc.Services.ClientService
{
	public interface IClientServiceInterface
	{
		Task<ServiceResponseModel<ClientServiceModel>> BuyInvestmentClient(ClientServiceModel clientService, List<InvestmentModel> investmentClient);
		Task<ServiceResponseModel<ClientServiceModel>> SellInvestmentClient(ClientServiceModel clientService, List<InvestmentModel> investmentClient);
		Task<ServiceResponseModel<FinancialStatementModel>> GetFinancialStatement(string user);
	}
}
