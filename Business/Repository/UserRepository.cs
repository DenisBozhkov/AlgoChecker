using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class UserRepository(AlgoCheckerContext context)
        : BaseRepository<UserEntity>(context)
    { }
}
