using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.V1.Users.RegisterUser
{
    public sealed class RegisterUserRequest
    {
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }
    }
}
