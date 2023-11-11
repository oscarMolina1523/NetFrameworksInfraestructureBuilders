using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Builders;
using System;
using System.Data.SqlClient;

namespace Infrastructure.Endpoint.Interfaces
{
    //normales 
    public interface ISqlCommandOperationBuilder
    {
        IHaveSqlWriteOperation From<TEntity>(TEntity entity) where TEntity : BaseEntity;

        IHaveSqlReadOperation Initialize<TEntity>() where TEntity : BaseEntity;
    }


    //hernecias del builder pero con la validacion de la entidad
    public interface IHaveSqlWriteOperation
    {
        IExecuteWriteBuilder WithOperation(SqlWriteOperation operation);
    }

    public interface IExecuteWriteBuilder
    {
        SqlCommand BuildWritter();
    }

    public interface IHaveSqlReadOperation
    {
        IHavePrimaryKeyValue WithOperation(SqlReadOperation operation);
    }

    public interface IHavePrimaryKeyValue : IExecuteReadBuilder
    {
        IExecuteReadBuilder WithId(Guid id);
    }

    public interface IExecuteReadBuilder
    {
        SqlCommand BuildReader();
    }
}
