using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries
{
    public class UserQuery : IRequest<GetUserResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public UserQuery(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
