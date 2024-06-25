using Microsoft.EntityFrameworkCore;
using ProjTec_XPInc.DataContext;
using ProjTec_XPInc.Models;
using ProjTec_XPInc.Services.ClientService;
using System.Collections.Generic;

namespace ProjTec_XPInc.Services.InvestmentManagementService
{
	public class InvestmentManagement : IInvestmentManagementInterface
	{
		private readonly ApplicationDbContext _context;

		public InvestmentManagement(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponseModel<List<InvestmentModel>>> GetInvestment(OperatorModel manager)
		{
			try
			{
				ServiceResponseModel<List<InvestmentModel>> serviceResponse = new ServiceResponseModel<List<InvestmentModel>>();

				if (manager == null)
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "Inform Manager data" };
				if (!(manager.Manager && manager.Active))
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "Manager not authorized" };

				serviceResponse.Data = await _context.Investment.ToListAsync();

				if (serviceResponse.Data.Count == 0)
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "No Investment found" };

				return serviceResponse;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponseModel<InvestmentModel>> GetInvestmentById(int? id, OperatorModel manager)
		{
			try
			{
				ServiceResponseModel<InvestmentModel> serviceResponse = new ServiceResponseModel<InvestmentModel>();

				if (manager == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Inform Manager data" };
				if (!(manager.Manager && manager.Active))
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Manager not authorized" };

				InvestmentModel? investment = await _context.Investment.FindAsync(id);

				serviceResponse.Data = investment;

				if (serviceResponse.Data == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "No Investments found" };

				return serviceResponse;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<InvestmentModel> { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponseModel<List<InvestmentModel>>> CreateInvestment(List<InvestmentModel> newInvestments, OperatorModel manager)
		{
			try
			{
				ServiceResponseModel<List<InvestmentModel>> serviceResponse = new ServiceResponseModel<List<InvestmentModel>>();

				if (manager == null)
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "Inform Manager data" };
				if (!(manager.Manager && manager.Active))
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "Manager not authorized" };

				if (newInvestments == null)
					return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = "Inform Investments data" };

				newInvestments.ForEach(async Investment =>
				{
					await _context.Investment.AddAsync(Investment);
				});

				
				await _context.SaveChangesAsync();

				serviceResponse.Data = newInvestments;

				return serviceResponse;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<List<InvestmentModel>> { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponseModel<InvestmentModel>> UpdateInvestment(InvestmentModel updatedInvestment, OperatorModel manager)
		{
			try
			{
				ServiceResponseModel<InvestmentModel> serviceResponse = new ServiceResponseModel<InvestmentModel>();

				if (manager == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Inform Manager data" };
				if (!(manager.Manager && manager.Active))
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Manager not authorized" };

				InvestmentModel? investment = await _context.Investment.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updatedInvestment.Id);

				if (investment == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Investment not found" };

				serviceResponse.Data = updatedInvestment;

				_context.Investment.Update(updatedInvestment);
				await _context.SaveChangesAsync();

				return serviceResponse;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<InvestmentModel> { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponseModel<InvestmentModel>> DeleteInvestment(int? id, OperatorModel manager)
		{
			try
			{
				ServiceResponseModel<InvestmentModel> serviceResponse = new ServiceResponseModel<InvestmentModel>();

				if (manager == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Inform Manager data" };
				if (!(manager.Manager && manager.Active))
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Manager not authorized" };


				InvestmentModel? investment = await _context.Investment.FindAsync(id);

				if (investment == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Investment not found" };

				serviceResponse.Data = investment;

				if (serviceResponse.Data == null)
					return new ServiceResponseModel<InvestmentModel> { Success = false, Message = "Investment not found" };

				_context.Investment.Remove(investment);
				await _context.SaveChangesAsync();

				return serviceResponse;
			}
			catch (Exception ex)
			{
				return new ServiceResponseModel<InvestmentModel> { Success = false, Message = ex.Message };
			}
		}
	}
}
