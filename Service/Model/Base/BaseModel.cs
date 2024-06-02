namespace Service.Model.Base
{
    public abstract class BaseModel(Guid id)
    {
        public Guid Id { get; private set; } = id;
    }
}
