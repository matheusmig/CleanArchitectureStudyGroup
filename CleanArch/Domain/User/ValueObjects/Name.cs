using System;
using System.Linq;

namespace Domain.User.ValueObjects
{
    public readonly struct Name: IEquatable<Name>
    {
        public Name(string fullname)
        {
            var splittedName = fullname.Split(' ');
            Firstname = splittedName[0];
            Lastname = splittedName[^1];

            if (splittedName.Length > 2)
                Middlename = string.Join(' ', splittedName.Skip(1).SkipLast(1));
            else
                Middlename = string.Empty;
        }

        public Name(string firstname, string lastname, string middlename = null)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename ?? string.Empty;
        }

        public string Firstname { get; }
        public string Lastname { get; }
        public string Middlename { get; }

        public bool Equals(Name other) => 
            Firstname == other.Firstname 
            && Lastname == other.Lastname
            && Middlename == other.Middlename;
        public override bool Equals(object obj) => obj is Name other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Firstname, Lastname, Middlename);
        public static bool operator ==(Name left, Name right) => left.Equals(right);
        public static bool operator !=(Name left, Name right) => !(left == right);
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Middlename))
                return $"{Firstname} {Lastname}";
            return $"{Firstname} {Middlename} {Lastname}";
        }
    }
}
