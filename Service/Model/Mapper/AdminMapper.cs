using Business.Entity;
using Business.Enums;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper
{
    internal class AdminMapper(IMapper<SolutionTestModel, SolutionTestEntity> solutionTestMapper)
        : UserMapper<AdminModel>(solutionTestMapper)
    {
        public override UserEntity MapToEntity(AdminModel model)
        {
            UserEntity entity = base.MapToEntity(model);
            entity.Role = Role.Admin;
            return entity;
        }
    }
}
