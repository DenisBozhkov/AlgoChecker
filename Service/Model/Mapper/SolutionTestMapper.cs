using Business.Entity;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper
{
    internal class SolutionTestMapper(IMapper<UserModel,UserEntity> userMapper,IMapper<TaskModel,TaskEntity> taskMapper)
        : IMapper<SolutionTestModel, SolutionTestEntity>
    {
        private readonly IMapper<UserModel, UserEntity> _userMapper=userMapper;
        private readonly IMapper<TaskModel, TaskEntity> _taskMapper=taskMapper;
        public SolutionTestEntity MapToEntity(SolutionTestModel model)
        {
            if (model.User == null || model.Task == null)
                throw new ArgumentException();
            return new()
            {
                Id = model.Id,
                CheckTime = model.CheckTime,
                Score = model.Score,
                User = _userMapper.MapToEntity(model.User),
                Task = _taskMapper.MapToEntity(model.Task)
            };
        }

        public SolutionTestModel MapToModel(SolutionTestEntity entity)
        {
            return new(entity.Id)
            {
                CheckTime = entity.CheckTime,
                Score = entity.Score,
                User = _userMapper.MapToModel(entity.User),
                Task = _taskMapper.MapToModel(entity.Task)
            };
        }
    }
}
