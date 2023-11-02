using AjooScheme.BusinessLogic;
using AjooScheme.Domain.Models;
using AjooScheme.Domain.utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.DataAccess.DataBase
{
    public class CustomerDbService
    {
        private readonly IDbConnection _connection;

        public CustomerDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateCustomer(Customer request)
        {
            try
            {
                var query = @"[InsertInto_Customer1]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    AccountNo = RequestProcessor.GenerateAccountNumber(),
                    AccountBalance = request.AmountToContribute,
                    TypeOfContribution = request.TypeOfContribution,
                    AmountToContribute = request.AmountToContribute,
                    ReleaseContributionDate = RequestProcessor.GetPayDate(request.TypeOfContribution),
                    Address = request.Address,
                    Gender = request.Gender,
                    NextOfKin = request.NextOfKin,
                    CreatedBy = request.CreatedBy,
                    
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<Customer> SingleCustomer(int Id)
        {
            Customer customer = new Customer();
            try
            {
                var query = @"[GetCustomer]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return customer;
            }
            return null;
        }

        public async Task<Customer> SingleCustomer(string AccountNo)
        {
            Customer customer = new Customer();
            try
            {
                var query = @"[GetCustomerWithAccountNo]";
                var param = new { AccountNo = AccountNo };
                return await _connection.QueryFirstAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return customer;
            }
            return null;
        }


        public async Task<APIListResponse3<Customer>> GetCustomer(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Customer>();
            try
            {
                var query = @"[GetAllCustomers]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Customer>.ToPagedList(result, pageNumber, pageSize);
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



        public async Task<int> UpdateCustomer(Customer request)
        {
            try
            {
                var query = @"[Update_Customer]";
                var param = new
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    AccountNo = request.AccountNo,
                    AccountBalance = request.AccountBalance,
                    Address = request.Address,
                    Gender = request.Gender,
                    NextOfKin = request.NextOfKin,
                    ModifiedBy = request.ModifiedBy

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
