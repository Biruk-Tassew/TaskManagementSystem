using userDomain = TM.Domain;
using AutoMapper;
using TM.Application.Contracts.Persistence;
using TM.Application.Features.User.CQRS.Commands;
using TM.Application.Features.User.DTOs.Validators;
using TM.Application.Responses;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TM.Application.Features.User.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<string>();
            var validator = new RegistrationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RegistrationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var user = _mapper.Map<IdentityUser>(request.RegistrationDto);

                user = await _unitOfWork.UserRepository.Add(user);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = user.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }
            }

            return response;
        }
    }
}