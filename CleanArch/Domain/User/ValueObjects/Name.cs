using Domain.User.Exceptions;
using System.Linq;

namespace Domain.User.ValueObjects
{
    public readonly struct Name
    {
        public Name(string fullname)
        {
            if (!(fullname?.Length > 0))
                throw new NameLengthException(fullname ?? "null");

            if (!fullname.Contains(' '))
                throw new NameBadFormatException(fullname);
            
            var splittedName = fullname.Split(' ');
            Filename = splittedName[0];
            Lastname = splittedName[^1];

            if (splittedName.Length > 2)
                Middlename = string.Join(' ', splittedName.Skip(1).SkipLast(1));
            else
                Middlename = string.Empty;
        }

        public Name(string firstname, string lastname, string middlename = null)
        {
            if (firstname?.Length < 0)
                throw new NameLengthException(firstname ?? "null");

            if (lastname?.Length < 0)
                throw new NameLengthException(lastname ?? "null");

            Filename = firstname;
            Lastname = lastname;

            if (middlename == null)
                Middlename = string.Empty;
            else
                Middlename = middlename;
        }

        public string Filename { get; }
        public string Lastname { get; }
        public string Middlename { get; }
    }
}
