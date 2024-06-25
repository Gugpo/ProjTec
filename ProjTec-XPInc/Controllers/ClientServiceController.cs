using Microsoft.AspNetCore.Mvc;
using ProjTec_XPInc.Models;
using ProjTec_XPInc.Services.ClientService;

namespace ProjTec_XPInc.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class ClientServiceController : ControllerBase
	{
		private readonly IClientServiceInterface _clientServiceInterface;
		public ClientServiceController(IClientServiceInterface clientServiceInterface)
		{
			_clientServiceInterface = clientServiceInterface;
		}

		[HttpGet]
		[Route("GetFinancialStatement")]
		public async Task<ActionResult<ServiceResponseModel<ClientServiceModel>>> GetFinancialStatement(string user)
		{
			return Ok(await _clientServiceInterface.GetFinancialStatement(user));
		}

		[HttpPost]
		[Route("BuyClientService")]
		public async Task<ActionResult<ServiceResponseModel<ClientServiceModel>>> BuyClientService(ClientServiceModel clientService, List<InvestmentModel> investment)
		{
			return Ok(await _clientServiceInterface.BuyInvestmentClient(clientService, investment));
		}

		[HttpPut]
		[Route("SellClientService")]
		public async Task<ActionResult<ServiceResponseModel<ClientServiceModel>>> SellClientService(ClientServiceModel clientService, List<InvestmentModel> investment)
		{
			return Ok(await _clientServiceInterface.SellInvestmentClient(clientService, investment));
		}

	}
}
