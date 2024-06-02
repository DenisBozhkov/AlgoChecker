using Business.Entity;
using Service.Model.Mapper.Base;

namespace Service.Model.Mapper
{
    public class TaskMapper(IMapper<TemplateAttributeModel, TemplateAttributeEntity> attributeMapper, IMapper<SolutionTestModel, SolutionTestEntity> solutionTestMapper, IMapper<TestCaseModel, TestCaseEntity> testCaseMapper)
        : IMapper<TaskModel, TaskEntity>
    {
        private readonly IMapper<TemplateAttributeModel, TemplateAttributeEntity> _attributeMapper = attributeMapper;
        private readonly IMapper<SolutionTestModel, SolutionTestEntity> _solutionTestMapper = solutionTestMapper;
        private readonly IMapper<TestCaseModel, TestCaseEntity> _testCaseMapper = testCaseMapper;

        public TaskEntity MapToEntity(TaskModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                MaxScore = model.MaxScore,
                Input = model.Input.Select(_attributeMapper.MapToEntity).ToList(),
                Output = model.Output.Select(_attributeMapper.MapToEntity).ToList(),
                SolutionTests = model.SolutionTests.Select(_solutionTestMapper.MapToEntity).ToList(),
                TestCases = model.TestCases.Select(_testCaseMapper.MapToEntity).ToList()
            };
        }

        public TaskModel MapToModel(TaskEntity entity)
        {
            TaskModel task = new(entity.Id)
            {
                Name = entity.Name,
                MaxScore = entity.MaxScore
            };
            task.Input.AddRange(entity.Input.Select(_attributeMapper.MapToModel));
            task.Output.AddRange(entity.Output.Select(_attributeMapper.MapToModel));
            task.SolutionTests.AddRange(entity.SolutionTests.Select(_solutionTestMapper.MapToModel));
            task.TestCases.AddRange(entity.TestCases.Select(_testCaseMapper.MapToModel));
            return task;
        }
    }
}
