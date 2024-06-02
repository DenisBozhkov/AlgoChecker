using Business.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class TestCaseEntity : BaseEntity
    {
        [Required]
        public int MaxScore { get; set; }
        [Required]
        public virtual TaskEntity Task { get; set; }
        public bool HasAbsoluteScoring { get; set; } = false;
        public virtual List<CheckAttributeEntity> InputAttributes { get; set; }
        public virtual List<CheckAttributeEntity> OutputAttributes { get; set; }
    }
}