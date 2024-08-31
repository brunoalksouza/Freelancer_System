using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Application.Exceptions;
using Application.InfraPorts;
using Application.Requests.Auth;
using Application.Requests.User;
using Application.Responses.User;
using Application.ServicesPorts;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthUserAdapter _authUserService;
    public UserService(IUserRepository userRepository, IAuthUserAdapter authUserService)
    {
        _userRepository = userRepository;
        _authUserService = authUserService;
    }

    public async Task<CreatedUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var response = new CreatedUserResponse();

        var context = new ValidationContext(request, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(request, context, results, true);

        if (!isValid)
        {
            foreach (var error in results)
                response.AddError(error.ErrorMessage);
            return response;
        }

        User user;
        if (request.Roles.Equals(UserRole.CLIENT))
            user = new Client { };
        else
            user = new Professional { };

        user.Name = request.Name;
        user.Email = request.Email;
        user.BirthDate = request.BirthDate;

        if(!user.IsEighteenYearsOld())
            throw new InvalidUserParamsException("User need to be eighteen's old");

        var auth = new RegisterUserRequest
        {
            Email = request.Email,
            Password = request.Password,
            Role = request.Roles
        };
        await _authUserService.RegisterAsync(auth);

        await _userRepository.CreateAsync(user);
        response.Success = new Dtos.UserDto(user);
        return response;
    }
}
