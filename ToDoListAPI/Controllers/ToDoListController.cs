using Microsoft.AspNetCore.Mvc;
using ToDoListModel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        // GET: api/<ToDoListController>
        [HttpGet]
        public IEnumerable<ToDoTask> Get()
        {
            return ToDoTask.ReadAll();
        }

        // GET api/<ToDoListController>/5
        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            return ToDoTask.Read(id);
        }

        // POST api/<ToDoListController>
        [HttpPost]
        public void Post([FromBody] string description)
        {
            ToDoTask newTask = new ToDoTask(description);
            newTask.Create();
        }

        // PUT api/<ToDoListController>/{id}/assign
        [HttpPut("{id}/assign")]
        public void PutAssign(int id, [FromBody] string assignedName)
        {
            ToDoTask assignTask = ToDoTask.Read(id);
            assignTask.AssignPerson(assignedName);
        }

        // PUT api/<ToDoListController>/{id}/finish
        [HttpPut("{id}/finish")]
        public void PutFinish(int id)
        {
            ToDoTask finishTask = ToDoTask.Read(id);
            finishTask.FinishTask();
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ToDoTask deleteTask = ToDoTask.Read(id);
            deleteTask.Delete();
        }
    }
}
