using Common.Utilities;
using StudentSync.Domain.Students;
using StudentSync.Application.Model;
using StudentSync.Contracts.Students;
using StudentSync.Data.Ef.Students.Dto;

namespace StudentSync.Application.Students
{
    internal class StudentApplicatonService : IStudentApplicationService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentApplicatonService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ApplicationServiceResponse<List<StudentDto>>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsNoTrackingAsync();

            return ApplicationServiceResponse.CreateSuccessResponse(
                students.Select(
                    s => ToStudentDto(s))
                .ToList());
        }

        public async Task<ApplicationServiceResponse<StudentDto>> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsNoTrackingAsync(id);

            return ApplicationServiceResponse.CreateSuccessResponse(ToStudentDto(student));
        }

        public async Task<ApplicationServiceResponse<StudentDto>> GetStudentByNationalCodeAsync(string nationalCode)
        {
            if (nationalCode.IsInValidNationalCode())
                return ApplicationServiceResponse.CreateFaileResponse<StudentDto>(0, "کد ملی اشتباه می باشد");

            var student = await _studentRepository.GetByNationalCodeAsNoTracking(nationalCode);

            return ApplicationServiceResponse.CreateSuccessResponse(ToStudentDto(student));
        }

        public async Task<ApplicationServiceResponse> AddStudentAsync(AddStudentDto addStudentDto)
        {
            await _studentRepository.AddAsync(addStudentDto.ToStudent());

            return ApplicationServiceResponse.CreateSuccessResponse();
        }

        public async Task<ApplicationServiceResponse> DeleteStudentAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);

            if (student is null)
                return ApplicationServiceResponse.CreateFaileResponse();

            await _studentRepository.DeleteAsync(student);

            return ApplicationServiceResponse.CreateSuccessResponse();
        }

        private StudentDto ToStudentDto(Student student)
        {
            return new StudentDto
            {
                Age = student.Age,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FullName = student.FullName,
                NationalCode = student.NationalCode,
            };
        }

    }
}
