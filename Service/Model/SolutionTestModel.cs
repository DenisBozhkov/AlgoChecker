using Service.Model.Base;

namespace Service.Model
{
    public class SolutionTestModel(Guid id)
        : BaseModel(id)
    {
        public UserModel? User { get; set; }
        public TaskModel? Task { get; set; }
        public double Score { get; set; }
        public DateTime CheckTime { get; set; }
    }
}