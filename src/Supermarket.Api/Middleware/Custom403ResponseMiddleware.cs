﻿using System.Net;
using System.Text.Json;
using Supermarket.Application.ModelResponses;
using Serilog;

namespace Supermarket.Api.Middleware
{
    public class Custom403ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";

                const string message = "Bạn không có quyền truy cập chức năng này";
                var response = new ResponseBase
                {
                    Status = HttpStatusCode.Forbidden,
                    Message = message,
                    Errors = new Dictionary<string, string[]>
                    {
                        { "UnAuthorize", new []{message} }
                    },
                    Type = HttpResponseType.Forbidden
                };
                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
                Log.Error("Lỗi từ custom 403 middleware");

            }
        }
    }
}

