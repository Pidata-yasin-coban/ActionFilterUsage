using ActionFilterUsage.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionFilterUsage.ActionFilters
{
    public class MerchantCodeActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Dil Desteği için kullanılabilir /tr-TR ----- en-US
            //Paging İçin Kullanılabilir 




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
