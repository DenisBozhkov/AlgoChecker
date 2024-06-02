using Service.Model.Base;

namespace Service.Model
{
    public class TemplateAttributeModel(Guid id)
        : BaseAttributeModel(id)
    {
        public TaskModel? Task { get; set; }
    }
}