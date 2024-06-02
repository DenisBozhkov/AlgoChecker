using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class CheckAttributeRepository(AlgoCheckerContext context)
        : BaseRepository<CheckAttributeEntity>(context)
    { }
}
