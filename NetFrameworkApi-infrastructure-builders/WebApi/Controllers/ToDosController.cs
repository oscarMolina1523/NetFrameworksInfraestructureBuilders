using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using Domain.Endpoint.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class ToDosController : ApiController
    {
        private readonly IToDosService _toDosService;

        public ToDosController(IToDosService toDosService)
        {
            _toDosService = toDosService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetToDos()
        {
            List<ToDo> toDos = await _toDosService.GetAll();
            return Ok(toDos);
        }

        //[HttpGet]
        ////[Route("{id}")]
        //public async Task<IHttpActionResult> GetById(Guid id)
        //{
        //    ToDo toDo = await toDosService.GetByIdAsync(id);
        //    return Ok(toDo);
        //}

        //[HttpPost]
        //[ResponseType(typeof(ToDo))]
        ////public async Task<IHttpActionResult> CreateAsync([FromBody] CreateToDoDto toDoDto)
        //public async Task<IHttpActionResult> CreateAsync(CreateToDoDto toDoDto)
        //{
        //    ToDo toDo = await toDosService.CreateAsync(toDoDto);
        //    var url = Url.Content("~/") + "/api/todos/" + toDo.Id;
        //    return Created(url, toDo);
        //}

        //[HttpPut]
        ////[Route("{id}")]
        //public async Task<IHttpActionResult> UpdateAsync(Guid id, UpdateToDoDto toDoDto)
        //{
        //    ToDo toDo = await toDosService.UpdateAsync(id, toDoDto);
        //    return Ok(toDo);
        //}
    }
}
