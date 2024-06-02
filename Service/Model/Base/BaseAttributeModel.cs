namespace Service.Model.Base
{
    public abstract class BaseAttributeModel(Guid id) : BaseModel(id)
    {
        public string Name { get; set; } = string.Empty;
        public Type? AttributeType { get; set; }
        public int Position { get; set; }
        public bool OneLine { get; set; }
        public bool IsInput { get; set; }
    }
}
