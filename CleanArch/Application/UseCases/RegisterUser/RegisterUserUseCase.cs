using System;
using System.Threading.Tasks;
using Application.Services;
using Domain.User;
using Domain.User.ValueObjects;

namespace Application.UseCases.RegisterUser
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private IOutputPort? _outputPort;

        public RegisterUserUseCase(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository, 
            IUserFactory userFactory)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public Task Execute(string name, DateTime birthdate) 
            => CreateNewUser(new Name(name), new Birthdate(birthdate));

        public async Task CreateNewUser(Name name, Birthdate birthdate)
        {
            var user = _userFactory.NewUser(name, birthdate);
            await _userRepository.AddAsync(user);

            await _unitOfWork.Save();

            _outputPort?.Ok(user);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}
