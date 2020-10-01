using System;

namespace Domain.User.ValueObjects
{
    public readonly struct Birthdate : IEquatable<Birthdate>
    {
        public Birthdate(DateTime datetime)
        {
            DateTime = datetime;
        }

        public DateTime DateTime { get; }

        public bool Equals(Birthdate other) => DateTime.Equals(other.DateTime);
        public override bool Equals(object obj) => obj is Birthdate other && Equals(other);
        public override int GetHashCode() => DateTime.GetHashCode();
        public static bool operator ==(Birthdate left, Birthdate right) => left.Equals(right);
        public static bool operator !=(Birthdate left, Birthdate right) => !(left == right);
        public static bool operator <(Birthdate t1, Birthdate t2) => t1.DateTime < t2.DateTime;
        public static bool operator <=(Birthdate t1, Birthdate t2) => t1.DateTime <= t2.DateTime;
        public static bool operator >(Birthdate t1, Birthdate t2) => t1.DateTime > t2.DateTime;
        public static bool operator >=(Birthdate t1, Birthdate t2) => t1.DateTime >= t2.DateTime;
        public override string ToString() => DateTime.ToString();
    }
}
