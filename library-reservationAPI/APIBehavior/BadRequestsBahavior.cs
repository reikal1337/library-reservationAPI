﻿using Microsoft.AspNetCore.Mvc;

namespace NET_core_api_tut.APIBehavior
{
    public class BadRequestsBahavior
    {

        public static void Parse(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new List<string>();

                foreach (var key in context.ModelState.Keys)
                {
                    foreach (var error in context.ModelState[key].Errors)
                    {
                        response.Add($"{key}: {error.ErrorMessage}");
                    }
                }
                return new BadRequestObjectResult(response);
            };
        }
    }
}
