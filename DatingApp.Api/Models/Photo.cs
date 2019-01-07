using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfilePhoto { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}