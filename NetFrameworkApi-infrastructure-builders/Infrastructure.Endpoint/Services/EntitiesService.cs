using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Endpoint.Services
{
    public class EntitiesService : IEntitiesService
    {
        private Dictionary<Type, SqlEntitySettings> entities = new Dictionary<Type, SqlEntitySettings>();
        //[llave, datos]-->[entidad, datosEntidad]

        public EntitiesService()
        {
            BuildEntities();
        }

        public SqlEntitySettings GetSettings<TEntity>() where TEntity : BaseEntity
        {
            if (!entities.ContainsKey(typeof(TEntity))) throw new ArgumentOutOfRangeException(nameof(TEntity), "Entidad no encontrada");

            return entities[typeof(TEntity)];
        }

        private void BuildEntities()
        {
            SqlEntitySettings toDoSettings = GetToDoSettings();
        
            entities.Add(typeof(ToDo), toDoSettings);
            
        }

        private SqlEntitySettings GetToDoSettings()
        {
            var columns = new List<SqlColumnSettings>()
            {
                new SqlColumnSettings() { Name = "Id", DomainName = "Id", IsPrimaryKey = true, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlColumnSettings() { Name = "Title", DomainName = "Title", SqlDbType = SqlDbType.NVarChar },
                new SqlColumnSettings() { Name = "Description", DomainName = "Description", SqlDbType = SqlDbType.NVarChar }
            };

            return new SqlEntitySettings()
            {
                TableName = "ToDos", //como se llama en la base de datos la tabla
                Columns = columns
            };
        }

       
    }
}
