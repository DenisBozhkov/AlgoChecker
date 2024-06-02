using Business.Entity.Base;

namespace Business.Repository.Base
{
    public abstract class BaseRepository<TEntity>(AlgoCheckerContext context)
        : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AlgoCheckerContext _context = context;
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        public TEntity Read(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public ICollection<TEntity> ReadAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public void Update(Guid id, TEntity entity)
        {
            _context.Entry(Read(id)).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            _context.Set<TEntity>().Remove(Read(id));
            _context.SaveChanges();
        }
    }
}
