﻿using Application.Headers.Commands.Create;
using Application.Headers.Commands.Delete;
using Application.Headers.Commands.Update;
using Application.Headers.Queries.GetOnly;
using Application.Headers.Queries.Gets;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]    
    public class HeaderController : ApiControllerBase
    {
        [HttpGet]              
        public async Task<ActionResult<HeaderVm>> Get()
        {
            return await Mediator.Send(new GetHeaderQuery());
        }

        [HttpGet("GetHeaderOnly")]
        public async Task<ActionResult<List<HeaderOnlyDto>>> GetHeaderOnly()
        {
            return await Mediator.Send(new GetOnlyHeaderQuery());
        }

        [HttpPost]
        //[Authorize("AdminAccess")]
        public async Task<ActionResult<int>> Create(CreateHeaderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, HeaderUpdateDto header)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            UpdateHeaderCommand command = new UpdateHeaderCommand()
            {
                Id = id,
                Description = header.Description,
            };

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteHeaderCommand(id));

            return NoContent();
        }
    }
}
