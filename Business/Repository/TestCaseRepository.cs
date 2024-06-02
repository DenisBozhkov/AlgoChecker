using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class TestCaseRepository(AlgoCheckerContext context)
        : BaseRepository<TestCaseEntity>(context)
    { }
}
