using Business.Entity;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper
{
    public class CheckAttributeMapper(IMapper<TestCaseModel, TestCaseEntity> testCaseMapper)
        : BaseAttributeMapper<CheckAttributeModel, CheckAttributeEntity>
    {
        private readonly IMapper<TestCaseModel, TestCaseEntity> _testCaseMapper = testCaseMapper;
        public override CheckAttributeEntity MapToEntity(CheckAttributeModel model)
        {
            if (model.TestCase == null || model.AttributeType == null)
                throw new ArgumentException();
            CheckAttributeEntity entity = new()
            {
                Id = model.Id,
                Value = model.Value,
                OutputTestCase = null,
                InputTestCase = null,
                Position = model.Position,
                OneLine = model.OneLine,
                Type = GetType(model.AttributeType)
            };
            if (model.IsInput)
                entity.InputTestCase = _testCaseMapper.MapToEntity(model.TestCase);
            else entity.OutputTestCase = _testCaseMapper.MapToEntity(model.TestCase);
            return entity;
        }

        public override CheckAttributeModel MapToModel(CheckAttributeEntity entity)
        {
            CheckAttributeModel model = new(entity.Id)
            {
                Value = entity.Value,
                OneLine = entity.OneLine,
                AttributeType = GetType(entity.Type),
                Position = entity.Position
            };
            if (entity.InputTestCase != null)
            {
                model.IsInput = true;
                model.TestCase = _testCaseMapper.MapToModel(entity.InputTestCase);
            }
            else
            {
                model.IsInput = false;
                model.TestCase = _testCaseMapper.MapToModel(entity.OutputTestCase);
            }
            return model;
        }
    }
}