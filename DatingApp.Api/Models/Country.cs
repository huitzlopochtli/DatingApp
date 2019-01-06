using System.Collections.Generic;

namespace DatingApp.Api.Models
{
    public class Country : EntityAbstruct
    {
        public string CountryName { get; set; }
        public ICollection<User> Users  { get; set; }
    }
}