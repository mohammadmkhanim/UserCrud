using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Application.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UsersController : BaseController<UsersController>
    {
        public UsersController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return HandleResult(await _mediator.Send(new List.Query()));
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return HandleResult(await _mediator.Send(new Get.Query { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Create.Command command)
        {
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync(Edit.Command command)
        {
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return HandleResult(await _mediator.Send(new Delete.Command { Id = id }));
        }
    }
}