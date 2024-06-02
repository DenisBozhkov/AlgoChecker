using Business.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        TEntity Read(Guid id);
        ICollection<TEntity> ReadAll();
        void Update(Guid id, TEntity entity);
        void Delete(Guid id);
    }
}
