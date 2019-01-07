using System.Collections.Generic;

namespace DatingApp.Api.Models
{
    public class City : EntityAbstruct
    {
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<User> Users  { get; set; }
    }
}