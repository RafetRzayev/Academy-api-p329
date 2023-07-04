using Academy.BLL.Dtos;
using Academy.BLL.Dtos.Student;
using Academy.BLL.Services.Contracts;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Services
{
    public class StudentManager : IStudentService
    {
        private readonly IMapper _mapper;

        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task CreateStudent(StudentCreateDto dto)
        {
            //var student = new Student
            //{
            //    Name = dto.Name,
            //    Age = dto.Age,
            //    GroupId = dto.GroupId,
            //    CreatedAt = DateTime.Now
            //};

            var student = _mapper.Map<Student>(dto);


            await _studentRepository.AddAsync(student);
        }

        public async Task<ResponseModel> DeleteStudent(int id)
        {
            var result = await _studentRepository.DeleteAsync(id);

            if (result == -1)
                return new ResponseModel
                {
                    Result = Result.Error.ToString(),
                    Message = "Student not found"
                };

            return new ResponseModel
            {
                Result = Result.Success.ToString(),
                Message = $"{result} Student is deleted"
            };
                
        }

        public async Task<ICollection<StudentDto>> GetByCondition(Expression<Func<Student, bool>> predicate)
        {
            var students = await _studentRepository.GetByCondition(predicate);

            var studentDtos = new List<StudentDto>();

            foreach (var item in students)
            {
                studentDtos.Add(new StudentDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                });
            }

            return studentDtos;
        }

        public async Task<StudentDto> GetStudent(int? id)
        {
            var student = await _studentRepository.GetAsync(id);

            if (student == null) return new StudentDto();


            //var studentDto = new StudentDto
            //{
            //    Id = student.Id,
            //    Name = student.Name
            //};

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<ICollection<StudentDto>> GetStudents()
        {
            var students = await _studentRepository.GetAllAsync();

            var studentDtos = _mapper.Map<List<StudentDto>>(students);

            //foreach (var item in students)
            //{
            //    studentDtos.Add(new StudentDto
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Age = item.Age,
            //    });
            //}

            return studentDtos;
        }

        public async Task<ICollection<StudentDto>> Test()
        {
            var students = await _studentRepository.Test();

            var studentDtos = new List<StudentDto>();

            foreach (var item in students)
            {
                studentDtos.Add(new StudentDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age
                });
            }

            return studentDtos;
        }

        public async Task UpdateStudent(StudentUpdateDto dto)
        {
            var student = new Student()
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                GroupId = dto.GroupId
            };
                
            await _studentRepository.UpdateAsync(student);
        }
    }
}
