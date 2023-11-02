
using Microsoft.AspNetCore.Mvc;
using AjooScheme.BusinessLogic.Interface;
using AjooScheme.Domain.Models;
using AjooScheme.Domain.Response;
using AjooScheme.Domain.Dtos.Customer;

namespace AJOO_SCHEME.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _repo;

        public CustomerController(ICustomer repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<object> GetCustomer(int pageNumber, int pageeSize)
        {
            var res = await _repo.GetCustomer(pageNumber, pageeSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<object> GetSingleCustomer(int Id)
        {
            var res = await _repo.GetSingleCustomer(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }
        [HttpPost]
        public async Task<object> CreateCustomer([FromBody] CreateCustomerDto request)
        {
            var res = await _repo.CreateCustomer(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }
        [HttpPut]
        public async Task<object> UpdateCustomer([FromBody] UpdateCustomerDto request)
        {
            var res = await _repo.UpdateCustomer(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }
    }
}
