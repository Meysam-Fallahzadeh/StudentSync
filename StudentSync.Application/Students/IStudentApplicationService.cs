using StudentSync.Application.Model;
using StudentSync.Data.Ef.Students.Dto;

namespace StudentSync.Application.Students
{
    public interface IStudentApplicationService
    {
        Task<ApplicationServiceResponse<List<StudentDto>>> GetAllStudentsAsync();

        Task<ApplicationServiceResponse<StudentDto>> GetStudentByIdAsync(int id);

        Task<ApplicationServiceResponse<StudentDto>> GetStudentByNationalCodeAsync(string nationalCode);

        Task<ApplicationServiceResponse> AddStudentAsync(AddStudentDto addStudentDto);

        Task<ApplicationServiceResponse> DeleteStudentAsync(int studentId);

    }
}
