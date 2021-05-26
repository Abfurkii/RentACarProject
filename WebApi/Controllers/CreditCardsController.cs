using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private ICreditCardService _creditCardService;
        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbymemberid")]
        public IActionResult GetAllByMemberId(int memberId)
        {
            var result = _creditCardService.GetAllByMemberId(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbymemberid")]
        public IActionResult GetByMemberId(int memberId)
        {
            var result = _creditCardService.GetByMemberId(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("membercardexist")]
        public IActionResult MemberCardExist(int cardId)
        {
            var result = _creditCardService.MemberCardExist(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
