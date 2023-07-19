using Academy.BLL.Dtos.Student;
using Academy.BLL.Services.Contracts;
using Academy.BLL.Validators.StudentDtoValidators;
using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories;
using Academy.DAL.Repositories.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class StudentsController : ControllerBase
    {
        //private readonly IRepositoryAsync<Student> _studentRepository;

        //public StudentsController(IRepositoryAsync<Student> studentRepository)
        //{
        //    _studentRepository = studentRepository;
        //}

        private IStudentService _studentService;
        //private IValidator<StudentCreateDto> _validator;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetStudents();

            return Ok(result);
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<IActionResult> GetByCondition(string name)
        {
            var result = await _studentService.GetByCondition(x => x.Name.Contains(name));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null) return BadRequest();

            var result = await _studentService.GetStudent(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentCreateDto dto)
        {
            //var studentCreateDtoValidation = new StudentCreateDtoValidation();
            //var validationResult = studentCreateDtoValidation.Validate(dto);
            //var validationResult = _validator.Validate(dto);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult);
            //}

            await _studentService.CreateStudent(dto);

            return Ok();
        }

        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Test()
        {
            var result = await _studentService.Test();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteStudent(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(StudentUpdateDto dto)
        {
            await _studentService.UpdateStudent(dto);

            return Ok();
        }
    }
}
