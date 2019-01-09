using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Models
{
    public class Photo : EntityAbstruct
    {
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

        [NotMapped]
        public DateTime DateCreated {get; set;}
        public bool IsProfilePhoto { get; set; }
        public string PublicId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}