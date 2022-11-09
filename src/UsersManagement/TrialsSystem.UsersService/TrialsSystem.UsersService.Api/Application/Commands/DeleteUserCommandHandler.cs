using MediatR;

namespace TrialsSystem.UsersService.Api.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
