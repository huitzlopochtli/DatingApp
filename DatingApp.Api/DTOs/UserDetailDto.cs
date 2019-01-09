using System;
using System.Collections.Generic;
using DatingApp.Api.Models;

namespace DatingApp.Api.DTOs
{
    public class UserDetailDto : DtoAbstruct
    {
        public string Username { get; set; }
        public GenderDto Gender { get; set; }
        public int GenderId { get; set; }
        public string KnownAs { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActivity { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interestes { get; set; }
        public CityDto City { get; set; }
        public int CityId { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoForDetailDto> Photos { get; set; }
    }
}