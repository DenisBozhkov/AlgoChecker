using Business.Entity.Base;
using Service.Model.Base;

namespace Service.Model.Mapper.Base
{
    public interface IMapper<TModel, TEntity>
        where TModel : BaseModel
        where TEntity : BaseEntity
    {
        TModel MapToModel(TEntity entity);
        TEntity MapToEntity(TModel model);
    }
}
