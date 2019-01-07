using System;

namespace DatingApp.Api.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfilePhoto { get; set; }
    }
}