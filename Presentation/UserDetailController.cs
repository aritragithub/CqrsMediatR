
using CqrsMediatr.CommandHandler;
using CqrsMediatr.QueryHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatr.Presentation
{
    [ApiController]
    
    public class UserDetailController : Controller
    {
        private readonly IMediator _mediator;
        public UserDetailController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        [Route("addDetail")]
        public async Task<IActionResult> AddUserDetail(UserDetailCommand userDetailCommand)
        {
            try
            {
                var result = await _mediator.Send(userDetailCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("getDetail/{id}")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            try
            {
                var query = new UserQueryCommand { Id = id };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
