using AjooScheme.Domain.Dtos.Customer;
using AjooScheme.Domain.Dtos.TransactionDto;
using AjooScheme.Domain.Models;
using AutoMapper;


namespace AjooScheme.Extentions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // CreateMap<Customer, CreateCustomerDto>();
            CreateMap<Customer, CreateCustomerDto>(); 
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<Transaction, CreateTransactionDto>();
            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<Transaction, CreateTransactionDto>();
            CreateMap<CreateTransactionDto, Transaction>();


            
    //.ForMember(d => d.BookCategories, opt => opt.MapFrom(s => s.Categories
    //    .Select(c => new BookCategory { BookId = s.BookId, CategoryId = c.CategoryId })));

        }
    }
}
