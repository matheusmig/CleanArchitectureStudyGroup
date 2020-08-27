using System;

namespace Domain
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage) 
            : base(businessMessage)
        {

        }
    }
}
