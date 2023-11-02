using AjooScheme.BusinessLogic.Interface;
using AjooScheme.Domain.Dtos.TransactionDto;
using AjooScheme.Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJOO_SCHEME.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _repo;

        public TransactionController(ITransaction repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<object> GetTransactions(int pageNumber, int pageeSize)
        {
            var res = await _repo.GetTransaction(pageNumber, pageeSize);
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
        public async Task<object> GetSingleTransaction(int Id)
        {
            var res = await _repo.GetSingleTransaction(Id);
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
        public async Task<object> CreateTransaction([FromBody] CreateTransactionDto request)
        {
            var res = await _repo.CreateTransaction(request);
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
        public async Task<object> UpdateTransaction([FromBody] UpdateTransactionDto request)
        {
            var res = await _repo.UpdateTransaction(request);
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
