namespace Domain.User.Exceptions
{
    public sealed class NameBadFormatException : DomainException
    {
        public NameBadFormatException(string name): base($"{name} has a bad format")
        {
        }
    }
}
