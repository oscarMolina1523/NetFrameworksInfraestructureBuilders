using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IToDosRepository
    {
        Task<List<ToDo>> Get();
    }
}
