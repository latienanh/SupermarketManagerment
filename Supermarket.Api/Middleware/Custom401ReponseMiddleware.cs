﻿using System.Net;
using System.Text.Json;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Middleware;

public class Custom401ReponseMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            var response = new ResponseBase
            {
                Title = "Thất bại",
                Message = "Bạn chưa xác thực",
                Errors = new Dictionary<string, string[]>
                {
                    { "UnAuthorized", new[] { "Bạn chưa xác thực" } }
                },
                Status = HttpStatusCode.Unauthorized,
                Type = HttpResponseType.Unauthorized
            };

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            // Set response content type to application/json
            context.Response.ContentType = "application/json";

            // Serialize the response object to JSON and write it to the response body
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}