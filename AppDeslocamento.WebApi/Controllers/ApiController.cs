﻿using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AppDeslocamento.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

    }
}