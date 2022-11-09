using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands;
using TrialsSystem.UsersService.Api.Application.Queries;
using TrialsSystem.UsersService.Api.Filters;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    /// <summary>
    /// User management controller
    /// </summary>
    [Route("api/v1/{userId}/[controller]")]
    [ServiceFilter(typeof(UserExceptionFilter))]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all users by setting parameters and filters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <param name="email">part of email (filter)</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUsersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = null,
            [FromQuery] string? email = null)
        {
            var response = await _mediator.Send(new UsersQuery(take, skip, email));
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            var response = await _mediator.Send(new UserQuery(userId, id));
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(CreateUserRequest request)
        {
            var response = await _mediator.Send(new CreateUserCommand(request.Email,
                                                                             request.Name,
                                                                             request.Surname,
                                                                             request.CityId,
                                                                             request.BirthDate,
                                                                             request.Weight,
                                                                             request.Height,
                                                                             request.GenderId));
            return Ok(response);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(string id, UpdateUserRequest request)
        {
            var response = _mediator.Send(new UpdateUserCommand
                (
                id,
                request.Name,
                request.Surname,
                request.CityId,
                request.BirthDate,
                request.Weight,
                request.Height)
                );

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}
