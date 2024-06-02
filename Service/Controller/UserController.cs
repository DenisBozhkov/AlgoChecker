using Business.Entity;
using Business.Repository;
using Business.Repository.Base;
using Service.Controller.Base;
using Service.Model;
using Service.Model.Mapper;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controller
{
    public class UserController(IRepository<UserEntity> repository, IMapper<UserModel, UserEntity> mapper)
        : BaseController<UserModel, UserEntity>(repository, mapper)
    {

    }
}
