
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AppAPI.Middleware
{
    public class GlobalExceptionHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception)
			{

				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				ProblemDetails problem = new()
				{
					Status = context.Response.StatusCode,
					Type = "Internal Server Error",
					Title = "Internal Server Error",
					Detail = "An internal server error has occured."
				};

				string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
			}
        }
    }
}
