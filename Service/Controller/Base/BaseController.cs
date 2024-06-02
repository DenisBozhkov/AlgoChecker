using Business.Entity.Base;
using Business.Repository.Base;
using Service.Model.Base;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controller.Base
{
    public class BaseController<TModel, TEntity>(IRepository<TEntity> repository, IMapper<TModel, TEntity> mapper)
        : IController<TModel>
        where TModel : BaseModel
        where TEntity : BaseEntity
    {
        public virtual void Create(TModel model)
        {
            repository.Create(mapper.MapToEntity(model));
        }
        public virtual TModel Read(Guid id)
        {
            return mapper.MapToModel(repository.Read(id));
        }
        public virtual ICollection<TModel> ReadAll()
        {
            return new BindingList<TModel>(repository.ReadAll().Select(mapper.MapToModel).ToList());
        }
        public virtual void Update(TModel model)
        {
            repository.Update(model.Id, mapper.MapToEntity(model));
        }
        public virtual void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
