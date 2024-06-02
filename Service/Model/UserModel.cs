using Service.Model.Base;

namespace Service.Model
{
    public class UserModel(Guid id)
        : BaseModel(id)
    {
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<SolutionTestModel> Solutions { get; set; } = [];
    }
}