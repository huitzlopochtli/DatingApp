using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 8 letters.")]
        public string Password { get; set; }

        public int GenderId { get; set; }
        public string KnownAs { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastActive { get; set; }
        public UserForRegisterDto()
        {
            DateCreated = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}