using AjooScheme.Domain.Dtos.Customer;
using AjooScheme.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.BusinessLogic.Interface
{
    public interface ICustomer
    {
        Task<APIListResponse3<Customer>> GetCustomer(int pageNumber, int pageSize);
        Task<APIResponse<Customer>> GetSingleCustomer(int Id);
        Task<APIResponse<CreateCustomerDto>> CreateCustomer(CreateCustomerDto request);
        Task<APIResponse<UpdateCustomerDto>> UpdateCustomer(UpdateCustomerDto request);
    }
}
