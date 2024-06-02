using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class TaskRepository(AlgoCheckerContext context)
        : BaseRepository<TaskEntity>(context)
    { }
}
