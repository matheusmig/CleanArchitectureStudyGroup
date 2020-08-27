using Domain.User.Exceptions;
using System;

namespace Domain.User.ValueObjects
{
    public readonly struct Birthdate
    {
        public Birthdate(DateTime datetime)
        {
            var now = DateTime.UtcNow;
            if (datetime < now.AddYears(18))
                throw new BirthdateMinorException(datetime);

            if (datetime < now.AddYears(150))
                throw new BirthdateImmortalException(datetime);

            DateTime = datetime;
        }

        public DateTime DateTime { get; }
    }
}
