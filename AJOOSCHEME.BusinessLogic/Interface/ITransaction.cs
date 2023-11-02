
using AjooScheme.Domain.Dtos.Customer;
using AjooScheme.Domain.Dtos.TransactionDto;
using AjooScheme.Domain.Models;
using System;


namespace AjooScheme.BusinessLogic.Interface
{
    public interface ITransaction
    {
        Task<APIListResponse3<Transaction>> GetTransaction(int pageNumber, int pageSize);
        Task<APIResponse<Transaction>> GetSingleTransaction(int Id);
        Task<APIResponse<CreateTransactionDto>> CreateTransaction(CreateTransactionDto request);
        Task<APIResponse<UpdateTransactionDto>> UpdateTransaction(UpdateTransactionDto request);
    }
}
