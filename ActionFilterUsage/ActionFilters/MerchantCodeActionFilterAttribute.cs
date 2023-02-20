using ActionFilterUsage.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionFilterUsage.ActionFilters
{
    public class MerchantCodeActionFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            //Get Data

            var key = "merchantCode";

            var merchantCode = context.RouteData.Values[key] as string;

            merchantCode = merchantCode.PadLeft(4, '0');

            //Set Data

            var baseRequest = context.ActionArguments
                .FirstOrDefault(i => i.Value != null && typeof(MerchantBaseRequest)
                .IsAssignableFrom(i.Value.GetType()));

            if (baseRequest.Value is not null)
            {
                var req = baseRequest.Value as MerchantBaseRequest;

                req.MerchantCode = merchantCode.ToString();
            }
            else
            {
                if (!context.ActionArguments.ContainsKey(key))
                {
                    context.ActionArguments.Add(key, merchantCode);
                }
                else
                {
                    context.ActionArguments[key] = merchantCode;
                }
            }
            await next();

        }
    }
}
