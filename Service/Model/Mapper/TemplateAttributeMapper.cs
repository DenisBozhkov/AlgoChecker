using Business.Entity;
using Service.Model.Mapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper
{
    public class TemplateAttributeMapper(IMapper<TaskModel, TaskEntity> taskMapper)
        : BaseAttributeMapper<TemplateAttributeModel, TemplateAttributeEntity>
    {
        private readonly IMapper<TaskModel, TaskEntity> _taskMapper = taskMapper;
        public override TemplateAttributeEntity MapToEntity(TemplateAttributeModel model)
        {
            if (model.Task == null || model.AttributeType == null)
                throw new ArgumentException();
            TemplateAttributeEntity entity = new()
            {
                Id = model.Id,
                Position = model.Position,
                OneLine = model.OneLine,
                Type = GetType(model.AttributeType),
                OutputTask = null,
                InputTask = null
            };
            if (model.IsInput)
                entity.InputTask = _taskMapper.MapToEntity(model.Task);
            else entity.OutputTask = _taskMapper.MapToEntity(model.Task);
            return entity;
        }

        public override TemplateAttributeModel MapToModel(TemplateAttributeEntity entity)
        {
            TemplateAttributeModel model = new(entity.Id)
            {
                AttributeType = GetType(entity.Type),
                Position = entity.Position,
                OneLine = entity.OneLine,
                Name = entity.Name
            };
            if (entity.InputTask != null)
            {
                model.IsInput = true;
                model.Task = _taskMapper.MapToModel(entity.InputTask);
            }
            else
            {
                model.IsInput = false;
                model.Task = _taskMapper.MapToModel(entity.OutputTask);
            }
            return model;
        }
    }
}