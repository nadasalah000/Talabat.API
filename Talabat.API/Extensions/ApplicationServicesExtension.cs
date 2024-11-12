using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.Core;
using Talabat.Core.Repositories;
using Talabat.Core.Services;
using Talabat.Repositoey;
using Talabat.Service;

namespace Talabat.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicatopnSErvices(this IServiceCollection Services)
        {
            Services.AddSingleton<IResponseCachService, ResponseCachService>();
            Services.AddScoped(typeof(IBasketRepository),typeof(BasketRepository));
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Services.AddAutoMapper(M=>M.AddProfile(new MappingProfile()));
            Services.AddAutoMapper(typeof(MappingProfile));
            Services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                      .SelectMany(P => P.Value.Errors)
                      .Select(E => E.ErrorMessage)
                      .ToArray();
                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddScoped<IUnitOfWork,UnitOfWork>();
            Services.AddScoped<IOrderService, OrderService>();
            Services.AddScoped<IPaymentServices, PaymentService>();
            return Services;
        }
    }
}
