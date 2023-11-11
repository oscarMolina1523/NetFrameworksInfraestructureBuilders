using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ToDosRepository : IToDosRepository
    {
        private readonly ISqlCommandOperationBuilder _operationBuilder;
        private readonly ISqlDbConnection _sqlDbConnection;

        public ToDosRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
        {
            _sqlDbConnection = sqlDbConnection;
            _operationBuilder = operationBuilder;   
        }

        public async Task<List<ToDo>> Get()
        {
            SqlCommand readCommand = _operationBuilder.Initialize<ToDo>()
                .WithOperation(SqlReadOperation.Select)
                .BuildReader();
            DataTable dt = await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);

            List<ToDo> categorias = dt.AsEnumerable().Select(row =>
            new ToDo
            {
                Id = row.Field<Guid>("ID"),
                Title= row.Field<string>("TITULO"),
                Description = row.Field<string>("DESCRIPCION"),
            }).ToList();

            return categorias;
        }

        public void Create(ToDo todo)
        {
            SqlCommand writeCommand = _operationBuilder.From(todo)
                .WithOperation(SqlWriteOperation.Create)
                .BuildWritter();
            _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);

        }

        public async Task Eliminar(ToDo todo)
        {
            SqlCommand writeCommand = _operationBuilder.From(todo)
                .WithOperation(SqlWriteOperation.Delete)
                .BuildWritter();
            await _sqlDbConnection.ExecuteNonQueryCommandAsync(writeCommand);
        }

        public async Task<ToDo> GetById(Guid Id)
        {

            SqlCommand readCommand = _operationBuilder.Initialize<ToDo>()
           .WithOperation(SqlReadOperation.SelectById)
           .WithId(Id)
           .BuildReader();
            ToDo todo = new ToDo();
            await _sqlDbConnection.ExecuteQueryCommandAsync(readCommand);
            SqlDataReader reader = readCommand.ExecuteReader();
            if (reader.Read())
            {
                todo = new ToDo
                {
                    Id = reader.GetGuid(reader.GetOrdinal("ID")),
                    Title = reader.GetString(reader.GetOrdinal("TITLE")),
                    Description = reader.GetString(reader.GetOrdinal("DESCRIPCION")),
                };
            }
            reader.Close();
            return todo;
        }

    }
}
