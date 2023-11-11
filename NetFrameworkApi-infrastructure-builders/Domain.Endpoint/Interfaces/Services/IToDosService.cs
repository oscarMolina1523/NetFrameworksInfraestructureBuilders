using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IToDosService
    {
        Task<List<ToDo>> GetAll();
    }
}
