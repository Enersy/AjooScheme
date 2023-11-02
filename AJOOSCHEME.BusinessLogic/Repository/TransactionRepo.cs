using AjooScheme.BusinessLogic.Interface;
using AjooScheme.DataAccess.DataBase;
using AjooScheme.Domain.Dtos.Customer;
using AjooScheme.Domain.Dtos.TransactionDto;
using AjooScheme.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.BusinessLogic.Repository
{
    public class TransactionRepo : ITransaction
    {
        private readonly IDbConnection _connection;
        private readonly TransactionDbService service;
        private readonly CustomerDbService Cusservice;
        private readonly IMapper _mapper;
        public TransactionRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            
            service = new TransactionDbService(connection);
        }
        public async Task<APIResponse<CreateTransactionDto>> CreateTransaction(CreateTransactionDto request)
        {
            var response = new APIResponse<CreateTransactionDto>();
            var model = _mapper.Map<Transaction>(request);
            var result = await service.CreateTransaction(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }

        public async Task<APIListResponse3<Transaction>> GetTransaction(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Transaction>();
            var result = await service.GetTransaction(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious,
                    };

                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<Transaction>> GetSingleTransaction(int Id)
        {
            var response = new APIResponse<Transaction>();
            var result = await service.SingleTransaction(Id);
            if (true)
            {
                if (result.Id == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record Found";
            }
            return response;
        }

        public async Task<APIResponse<UpdateTransactionDto>> UpdateTransaction(UpdateTransactionDto request)
        {
            var response = new APIResponse<UpdateTransactionDto>();
            var model = _mapper.Map<Transaction>(request);
            var result = await service.UpdateTransaction(model);
            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
                response.Data = request;
            }

            return response;
        }

      
    }
}
