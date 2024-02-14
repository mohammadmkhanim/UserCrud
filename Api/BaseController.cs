using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api;
using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController<ControllerType> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IConfiguration _configuration;
        protected readonly ILogger<ControllerType> _logger;

        protected BaseController(
            IMediator mediator = null,
            ILogger<ControllerType> logger = null,
            IConfiguration configuration = null)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }


        protected ActionResult HandleResult<T>(Result<T> result)
        {
            return new ResponseModel(result.StatusCode, result.Value, result.Errors);
        }

    }
}