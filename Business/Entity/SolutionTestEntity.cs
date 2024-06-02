using Business.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class SolutionTestEntity : BaseEntity
    {
        [Required]
        public virtual UserEntity User { get; set; }
        [Required]
        public virtual TaskEntity Task { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        public DateTime CheckTime { get; set; }
    }
}
