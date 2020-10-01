using System;
using System.Threading.Tasks;

namespace Application.UseCases.RegisterUser
{
    public interface IRegisterUserUseCase
    {
        Task Execute(string name, DateTime birthdate);
        void SetOutputPort(IOutputPort outputPort);
    }
}
