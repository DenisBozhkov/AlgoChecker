using Business.Entity.Base;
using Business.Repository.Base;
using Service.Model.Base;
using Service.Model.Mapper.Base;

namespace Service.Controller.Base
{
    public interface IController<TModel>
        where TModel : BaseModel
    {
        void Create(TModel model);
        TModel Read(Guid id);
        ICollection<TModel> ReadAll();
        void Update(TModel model);
        void Delete(Guid id);
    }
}
