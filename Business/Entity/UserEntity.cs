using Business.Entity.Base;
using Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Role Role { get; set; }
        public virtual List<SolutionTestEntity> Solutions { get; set; }
    }
}