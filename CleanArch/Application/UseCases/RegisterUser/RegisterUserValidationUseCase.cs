using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

namespace Application.UseCases.RegisterUser
{
    class RegisterUserValidationUseCase : IRegisterUserUseCase
    {
        private readonly IRegisterUserUseCase _useCase;
        private IOutputPort? _outputPort;

        public RegisterUserValidationUseCase(IRegisterUserUseCase useCase)
        {
            _useCase = useCase;
        }

        public Task Execute(string name, DateTime birthdate)
        {
            var modelState = new Notification();

            if (!(name?.Length > 0))
                modelState.Add(nameof(name), "Name has length smaller than 0");
            else if (!name.Contains(' '))
                modelState.Add(nameof(name), "Name has a bad format");
     
            var now = DateTime.UtcNow;
            if (birthdate < now.AddYears(18))
                modelState.Add(nameof(birthdate), "Minor is not allowed");
            if (birthdate > now.AddYears(150))
               modelState.Add(nameof(birthdate), "Immortals not allowed");

            if (modelState.IsValid)
                return _useCase.Execute(name, birthdate);
            
            _outputPort?.Invalid(modelState);

            return Task.CompletedTask;
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(outputPort);
        }
    }
}
