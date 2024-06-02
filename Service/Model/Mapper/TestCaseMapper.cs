using Business.Entity;
using Microsoft.EntityFrameworkCore.Metadata;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper
{
    internal class TestCaseMapper(IMapper<TaskModel, TaskEntity> taskMapper, IMapper<CheckAttributeModel, CheckAttributeEntity> attributeMapper)
        : IMapper<TestCaseModel, TestCaseEntity>
    {
        private readonly IMapper<TaskModel, TaskEntity> _taskMapper = taskMapper;
        private readonly IMapper<CheckAttributeModel, CheckAttributeEntity> _attributeMapper = attributeMapper;
        public TestCaseEntity MapToEntity(TestCaseModel model)
        {
            if (model.Task == null)
                throw new ArgumentNullException();
            return new()
            {
                Id = model.Id,
                HasAbsoluteScoring = model.HasAbsoluteScoring,
                MaxScore = model.MaxScore,
                Task = _taskMapper.MapToEntity(model.Task),
                OutputAttributes = model.Output.Select(_attributeMapper.MapToEntity).ToList(),
                InputAttributes = model.Input.Select(_attributeMapper.MapToEntity).ToList()
            };
        }

        public TestCaseModel MapToModel(TestCaseEntity entity)
        {
            if (entity.Task == null)
                throw new ArgumentNullException();
            TestCaseModel model = new(entity.Id)
            {
                HasAbsoluteScoring = entity.HasAbsoluteScoring,
                MaxScore = entity.MaxScore,
                Task = _taskMapper.MapToModel(entity.Task)
            };
            model.Output.AddRange(entity.OutputAttributes.Select(_attributeMapper.MapToModel));
            model.Input.AddRange(entity.InputAttributes.Select(_attributeMapper.MapToModel));
            return model;
        }
    }
}
