using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }

        bool IsDeleted { get; set; }
    }

    public abstract class EntityAbstruct : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        public bool IsDeleted { get; set; }

        [NotMapped]
        protected DateTime? dateCreated = null;
    }
}