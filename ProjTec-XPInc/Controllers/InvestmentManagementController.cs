using Microsoft.AspNetCore.Mvc;
using ProjTec_XPInc.Models;
using ProjTec_XPInc.Services.ClientService;
using ProjTec_XPInc.Services.InvestmentManagementService;

namespace ProjTec_XPInc.Controllers
{
	public class InvestmentModelManagementController : ControllerBase
	{
		private readonly IInvestmentManagementInterface _InvestmentManagementInterface;
		public InvestmentModelManagementController(IInvestmentManagementInterface InvestmentModelManagementInterface)
		{
			_InvestmentManagementInterface = InvestmentModelManagementInterface;
		}

		[HttpGet]
		[Route("GetInvestment")]
		public async Task<ActionResult<ServiceResponseModel<List<InvestmentModel>>>> GetInvestment(OperatorModel manager)
		{
			return Ok(await _InvestmentManagementInterface.GetInvestment(manager));
		}

		[HttpGet]
		[Route("GetInvestmentById")]
		public async Task<ActionResult<ServiceResponseModel<InvestmentModel>>> GetInvestmentById(int id, OperatorModel manager)
		{
			return Ok(await _InvestmentManagementInterface.GetInvestmentById(id, manager));
		}

		[HttpPost]
		[Route("CreateInvestment")]
		public async Task<ActionResult<ServiceResponseModel<InvestmentModel>>> CreateInvestment(List<InvestmentModel> newInvestment, OperatorModel manager)
		{
			return Ok(await _InvestmentManagementInterface.CreateInvestment(newInvestment, manager));
		}

		[HttpPut]
		[Route("UpdateInvestment")]
		public async Task<ActionResult<ServiceResponseModel<InvestmentModel>>> UpdateInvestment(InvestmentModel updateInvestment, OperatorModel manager)
		{
			return Ok(await _InvestmentManagementInterface.UpdateInvestment(updateInvestment, manager));
		}

		[HttpDelete]
		[Route("DeleteInvestment")]
		public async Task<ActionResult<ServiceResponseModel<InvestmentModel>>> DeleteInvestment(int id, OperatorModel manager)
		{
			return Ok(await _InvestmentManagementInterface.DeleteInvestment(id, manager));
		}
	}
}
