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
    public class TemplateAttributeController(IRepository<TemplateAttributeEntity> repository, IMapper<TemplateAttributeModel, TemplateAttributeEntity> mapper)
        : BaseController<TemplateAttributeModel, TemplateAttributeEntity>(repository, mapper)
    {
    }
}
