using MediatR;

namespace TrialsSystem.UsersService.Api.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserCommand:IRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public DeleteUserCommand(string id)
        {
            Id = id.Trim();
        }
    }
}
