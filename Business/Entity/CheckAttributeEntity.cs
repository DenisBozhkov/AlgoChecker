using Business.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class CheckAttributeEntity : BaseAttributeEntity
    {
        [Required]
        public string Value { get; set; }
        public virtual TestCaseEntity InputTestCase { get; set; }
        public virtual TestCaseEntity OutputTestCase { get; set; }
    }
}