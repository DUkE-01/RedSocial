using AutoMapper;
using IdentityServer3.Core.Services;
using RedSocial.Core.Application.Interfaces;
using RedSocial.Core.Application.ViewModels;
using RedSocial.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IMapper mapper, IEmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Password = HashPassword(model.Password);
            user.IsActive = false;

            await _userRepository.AddAsync(user);
            await _emailService.SendActivationEmailAsync(user.Email, user.ActivationCode);
        }

        // Otros métodos para Login, ResetPassword, etc.
    }
}
