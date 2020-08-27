using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Exceptions
{
    public sealed class NameLengthException : DomainException
    {
        public NameLengthException(string name): base($"{name} has length smaller than 0")
        {
        }
    }
}
