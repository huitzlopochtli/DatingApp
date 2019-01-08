using System;

namespace DatingApp.Api.DTOs
{
    public class UserForListDto : DtoAbstruct
    {
        public string Username { get; set; }
        public GenderDto Gender { get; set; }
        public string KnownAs { get; set; }
        public int Age { get; set; }
        public DateTime LastActivity { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interestes { get; set; }
        public CityDto City { get; set; }
        public string PhotoUrl { get; set; }

    }
}