using Academy.BLL.Dtos.Teacher;
using Academy.BLL.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ITeacherGroupService _teacherGroupService;
   
        public TeachersController(ITeacherService teacherService, ITeacherGroupService teacherGroupService)
        {
            _teacherService = teacherService;
            _teacherGroupService = teacherGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teacherService.GetTeachersAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task Post(TeacherCreateDto dto)
        {
            await _teacherService.CreateTeacher(dto);
        }

        [HttpPost]
        [Route("Create relation")]
        public async Task<IActionResult> CreateTeacherGroupRelation(int teacherId, int groupId)
        {
            await _teacherGroupService.CreateRelationAsync(teacherId, groupId);

            return Ok();
        }
    }
}
