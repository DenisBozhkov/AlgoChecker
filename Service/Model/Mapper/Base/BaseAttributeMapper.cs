using Business.Entity.Base;
using Business.Enums;
using Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Mapper.Base
{
    public abstract class BaseAttributeMapper<TModel, TEntity>
        : IMapper<TModel, TEntity>
        where TModel : BaseAttributeModel
        where TEntity : BaseAttributeEntity
    {
        public abstract TModel MapToModel(TEntity entity);
        public abstract TEntity MapToEntity(TModel model);

        protected Type? GetType(AttributeType type) => type switch
        {
            AttributeType.String => typeof(string),
            AttributeType.Int => typeof(int),
            AttributeType.Double => typeof(double),
            AttributeType.Bool => typeof(bool),
            AttributeType.Char => typeof(char),
            AttributeType.Array => typeof(object[]),
            _ => null,
        };
        protected AttributeType GetType(Type type)
        {
            if (type == typeof(string))
                return AttributeType.String;
            if (type == typeof(int))
                return AttributeType.Int;
            if (type == typeof(double))
                return AttributeType.Double;
            if (type == typeof(bool))
                return AttributeType.Bool;
            if (type == typeof(char))
                return AttributeType.Char;
            if (type == typeof(object[]))
                return AttributeType.Array;
            return AttributeType.String;
        }
    }
}
