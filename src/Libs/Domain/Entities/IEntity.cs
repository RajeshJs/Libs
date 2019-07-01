using System;

namespace Libs.Domain.Entities
{
    public interface IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        /// <summary>
        /// 实体主键
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 检查实体是否为瞬态，不会持久化到数据库中
        /// </summary>
        /// <returns>True 为瞬态</returns>
        bool IsTransient();
    }

    public interface IEntity : IEntity<int>
    {

    }
}
