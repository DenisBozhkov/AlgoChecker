using Business.Entity;
using Business.Repository.Base;

namespace Business.Repository
{
    public class TemplateAttributeRepository(AlgoCheckerContext context)
        : BaseRepository<TemplateAttributeEntity>(context)
    { }
}
