using ProjTec_XPInc.Models;
using ProjTec_XPInc.Services.ClientService;

namespace ProjTec_XPInc.Services.InvestmentManagementService
{
	public interface IInvestmentManagementInterface
	{
		Task<ServiceResponseModel<List<InvestmentModel>>> GetInvestment(OperatorModel manager);
		Task<ServiceResponseModel<InvestmentModel>> GetInvestmentById(int? id, OperatorModel manager);
		Task<ServiceResponseModel<List<InvestmentModel>>> CreateInvestment(List<InvestmentModel> newInvestment, OperatorModel manager);
		Task<ServiceResponseModel<InvestmentModel>> UpdateInvestment(InvestmentModel updatedInvestment, OperatorModel manager);
		Task<ServiceResponseModel<InvestmentModel>> DeleteInvestment(int? id, OperatorModel manager);
	}
}
