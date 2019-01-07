using System;
using System.Collections.Generic;
using DatingApp.Api.Models;

namespace DatingApp.Api.DTOs
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfBirt { get; set; }
        public DateTime LastActivity { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interestes { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}