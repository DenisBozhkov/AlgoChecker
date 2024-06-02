using Business.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class TaskEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public virtual List<TemplateAttributeEntity> Input { get; set; }
        public virtual List<TemplateAttributeEntity> Output { get; set; }
        public virtual List<TestCaseEntity> TestCases { get; set; }
        public virtual List<SolutionTestEntity> SolutionTests { get; set; }
    }
}
