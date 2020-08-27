using System;

namespace Domain.User.Exceptions
{
    public sealed class BirthdateImmortalException : DomainException
    {
        public BirthdateImmortalException(DateTime birthdate): base($"{birthdate} Immortals not allowed")
        {
        }
    }
}
