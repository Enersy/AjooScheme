using AjooScheme.BusinessLogic;
using AjooScheme.Domain.Models;
using AjooScheme.Domain.utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.DataAccess.DataBase
{
    public class TransactionDbService
    {
        private readonly IDbConnection _connection;
        private readonly CustomerDbService _cus;

        public TransactionDbService(IDbConnection connection)
        {
            _connection = connection;
            _cus = new CustomerDbService(_connection);
          
        }

        public async Task<int> CreateTransaction(Transaction request)
        {
            try
            {
               var customer = await _cus.SingleCustomer(request.AccountNo);
                var cbalance = 0.0;
                if (request.Type.Equals("Withdrawal"))
                {
                    cbalance = RequestProcessor.WithdrawalRequest(customer.AccountBalance, request.Amount);

                }
                else if (request.Type.Equals("Deposit"))
                {
                    cbalance = RequestProcessor.DepositRequest(customer.AccountBalance, request.Amount);
                }

                var query = @"[InsertInto_Transaction]";
                var param = new
                { 
                    
                    AccountNo = request.AccountNo,
                    type = request.Type,
                    Amount = request.Amount,
                    Balance = cbalance,
                    CreatedBy = request.CreatedBy,
                    
                };

                var qeuryResponse = await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                if (qeuryResponse == 1)
                {
                    customer.AccountBalance = cbalance;
                    customer.ModifiedBy = request.CreatedBy;
                   await _cus.UpdateCustomer(customer);
                    
                }
                return qeuryResponse;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<Transaction> SingleTransaction(int Id)
        {
            Transaction account = new Transaction();
            try
            {
                var query = @"[GetTransaction]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Transaction>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return account;
            }
            return null;
        }


        public async Task<APIListResponse3<Transaction>> GetTransaction(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Transaction>();
            try
            {
                var query = @"[GetAllTransactions]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Transaction>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Transaction>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }



        public async Task<int> UpdateTransaction(Transaction request)
        {
            try
            {
                var query = @"[Update_Transaction]";
                var param = new
                {

                    Id = request.Id,
                    AccountNo = request.AccountNo,
                    type = request.Type,
                    Amount = request.Amount,
                    ModifiedBy = request.ModifiedBy,

                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}
