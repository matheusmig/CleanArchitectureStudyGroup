using System;

namespace Domain.User.Exceptions
{
    public sealed class BirthdateMinorException : DomainException
    {
        public BirthdateMinorException(DateTime birthdate): base($"{birthdate} is not allowed")
        {
        }
    }
}
