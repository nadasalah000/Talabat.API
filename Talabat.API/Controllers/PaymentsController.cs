using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.Core.Services;

namespace Talabat.API.Controllers
{
    public class PaymentsController : APIBaseController
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentsController(IPaymentServices paymentServices)
        {
            this._paymentServices = paymentServices;
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(string baskrtId)
        {
            var Basket = await _paymentServices.CreateOrUpdatePaymentIntent(baskrtId);
            if (Basket is null) return BadRequest(new ApiResponse(400, "This is A Problem With Your Basket"));

            return Ok(Basket);
        }
    }
}
