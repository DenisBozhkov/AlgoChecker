using Service.Model.Base;

namespace Service.Model
{
    public class TestCaseModel(Guid id)
        : BaseModel(id)
    {
        public int MaxScore { get; set; }
        public TaskModel? Task { get; set; }
        public bool HasAbsoluteScoring { get; set; }
        public List<CheckAttributeModel> Input { get; set; } = [];
        public List<CheckAttributeModel> Output { get; set; } = [];
    }
}