using System;

namespace DatingApp.Api.DTOs
{
    public abstract class DtoAbstruct
    {
        public int Id { get; set; }
        public DateTime DateCreated {get; set;}
    }
}