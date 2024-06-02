using System.ComponentModel.DataAnnotations;
using Business.Enums;

namespace Business.Entity.Base
{
    public class BaseAttributeEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public AttributeType Type { get; set; }
        [Required]
        public int Position { get; set; }
        public bool OneLine { get; set; } = false;
    }
}
