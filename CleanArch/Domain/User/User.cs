using Domain.User.ValueObjects;

namespace Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Birthdate Birthdate { get; set; }
    }
}
