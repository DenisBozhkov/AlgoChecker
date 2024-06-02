using Business.Entity;
using Business.Enums;
using Service.Model.Mapper.Base;

namespace Service.Model.Mapper
{
    public class UserMapper<TModel>(IMapper<SolutionTestModel, SolutionTestEntity> solutionTestMapper)
        : IMapper<TModel, UserEntity> 
        where TModel : UserModel
    {
        private readonly IMapper<SolutionTestModel, SolutionTestEntity> _solutionTestMapper = solutionTestMapper;
        public virtual UserEntity MapToEntity(TModel model)
        {
            return new()
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                PassWord = model.PassWord,
                Role = Role.Normal,
                Solutions = model.Solutions.Select(_solutionTestMapper.MapToEntity).ToList()
            };
        }

        public virtual TModel MapToModel(UserEntity entity)
        {
            if (entity.Role == Role.Normal)
            {
                return (TModel)new UserModel(entity.Id)
                {
                    UserName = entity.UserName,
                    Email = entity.Email,
                    PassWord = entity.PassWord,
                    Solutions = entity.Solutions.Select(_solutionTestMapper.MapToModel).ToList()
                };
            }
            if (entity.Role == Role.Admin && typeof(AdminModel).IsAssignableTo(typeof(TModel)))
            {
                return (TModel)(UserModel)new AdminModel(entity.Id)
                {
                    UserName = entity.UserName,
                    Email = entity.Email,
                    PassWord = entity.PassWord,
                    Solutions = entity.Solutions.Select(_solutionTestMapper.MapToModel).ToList()
                };
            }
            throw new ArgumentException();
        }
    }
}
