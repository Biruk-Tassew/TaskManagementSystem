using MediatR;
using TM.Application.Features.User.DTOs;
using TM.Application.Responses;

namespace TM.Application.Features.User.CQRS.Commands
{
    public class CreateUserCommand : IRequest<Result<string>>
    {
        public RegistrationDto RegistrationDto { get; set; }
        
    }
}