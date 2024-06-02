using Service.Model.Base;

namespace Service.Model
{
    public class TaskModel(Guid id)
        : BaseModel(id)
    {
        public string Name { get; set; } = string.Empty;
        public int MaxScore { get; set; }
        public List<TemplateAttributeModel> Input { get; private set; } = [];
        public List<TemplateAttributeModel> Output { get; private set; } = [];
        public List<TestCaseModel> TestCases { get; private set; } = [];
        public List<SolutionTestModel> SolutionTests { get; private set; } = [];
    }
}