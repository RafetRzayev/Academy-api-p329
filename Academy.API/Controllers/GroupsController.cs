using Academy.BLL.Dtos.Group;
using Academy.BLL.Dtos.Student;
using Academy.BLL.Services.Contracts;
using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories;
using Academy.DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        //private readonly IRepositoryAsync<Student> _studentRepository;

        //public StudentsController(IRepositoryAsync<Student> studentRepository)
        //{
        //    _studentRepository = studentRepository;
        //}

        private IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _groupService.GetGroups();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(GroupCreateDto dto)
        {
            await _groupService.CreateGroup(dto);

            return Ok();
        }
       
    }
}
