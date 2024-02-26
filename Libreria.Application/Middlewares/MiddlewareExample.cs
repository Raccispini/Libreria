﻿using Libreria.Application.Abstractions.Services;
using Libreria.Application.Services;

namespace Libreria.Application.Middlewares
{
    public class MiddlewareExample
    {
        public RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(IBookService bookService,HttpContext context)
        {
            //Logica middleware
            Console.Write("Middleware");
            await _next.Invoke(context);
        }
    }
}
