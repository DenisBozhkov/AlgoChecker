using System.ComponentModel.DataAnnotations;

namespace Business.Entity.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
