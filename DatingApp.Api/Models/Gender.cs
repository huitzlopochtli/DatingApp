using System.Collections.Generic;

namespace DatingApp.Api.Models
{
    public class Gender : EntityAbstruct
    {
        public string GenderName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}