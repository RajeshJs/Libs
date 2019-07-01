using System;

namespace Libs.Domain.Entities
{
    /// <summary>
    /// 聚合根
    /// 在仓储模式中，聚合根是唯一能直接从仓储中加载的对象
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {

    }

    public interface IAggregateRoot : IAggregateRoot<int>
    {

    }
}
