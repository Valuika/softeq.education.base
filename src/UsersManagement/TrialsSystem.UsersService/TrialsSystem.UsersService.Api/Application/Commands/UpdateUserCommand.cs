using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands
{
    public class UpdateUserCommand:IRequest<UpdateUserResponse>
    {
        public UpdateUserCommand(
           string id,
           string name,
           string surname,
           string cityId,
           DateTime birthDate,
           decimal? weight,
           decimal? height
           )
        {
            Id = id;
            Name = name;
            Surname = surname;
            CityId = cityId;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public string Id { get; set; }
       
        public string Name { get; }

        public string Surname { get; }

        public string CityId { get; }

        public DateTime BirthDate { get; }

        public decimal? Weight { get; }

        public decimal? Height { get; }

    }
}
