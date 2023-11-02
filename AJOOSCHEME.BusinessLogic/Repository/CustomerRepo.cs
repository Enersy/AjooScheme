using AjooScheme.BusinessLogic.Interface;
using AjooScheme.DataAccess.DataBase;
using AjooScheme.Domain.Dtos.Customer;
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
    public class CustomerRepo:ICustomer
    {
        private readonly IDbConnection _connection;
        private readonly CustomerDbService service;
        private readonly IMapper _mapper;
        public CustomerRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new CustomerDbService(connection);
        }
        public async Task<APIListResponse3<Customer>> GetCustomer(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Customer>();
            var result = await service.GetCustomer(pageNumber, pageSize);
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
        public async Task<APIResponse<CreateCustomerDto>> CreateCustomer(CreateCustomerDto request)
        {

            var response = new APIResponse<CreateCustomerDto>();
            var model = _mapper.Map<Customer>(request);
            var result = await service.CreateCustomer(model);

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


        public async Task<APIResponse<Customer>> GetSingleCustomer(int Id)
        {
            var response = new APIResponse<Customer>();
            var result = await service.SingleCustomer(Id);
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

        public async Task<APIResponse<UpdateCustomerDto>> UpdateCustomer(UpdateCustomerDto request)
        {
            var response = new APIResponse<UpdateCustomerDto>();
            var model = _mapper.Map<Customer>(request);
            var result = await service.UpdateCustomer(model);
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
