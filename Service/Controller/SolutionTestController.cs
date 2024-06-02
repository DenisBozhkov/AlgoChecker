using Business.Entity;
using Business.Repository.Base;
using Service.Controller.Base;
using Service.Model;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controller
{
    public class SolutionTestController(IRepository<SolutionTestEntity> repository, IMapper<SolutionTestModel, SolutionTestEntity> mapper)
        : BaseController<SolutionTestModel, SolutionTestEntity>(repository, mapper)
    {
    }
}
