using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class SolutionTestRepository(AlgoCheckerContext context)
        : BaseRepository<SolutionTestEntity>(context)
    { }
}
