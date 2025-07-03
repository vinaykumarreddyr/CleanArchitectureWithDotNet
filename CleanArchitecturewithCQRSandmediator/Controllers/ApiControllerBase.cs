﻿using MediatR; // Correct namespace
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecturewithCQRSandmediator.API.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}