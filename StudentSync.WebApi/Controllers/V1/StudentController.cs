using Microsoft.AspNetCore.Mvc;
using StudentSync.Application.Students;
using StudentSync.Data.Ef.Students.Dto;
using StudentSync.WebApi.Controllers.Common;
using StudentSync.WebApi.Extentions;

namespace StudentSync.WebApi.Controllers.V1;

public class StudentController : BaseController
{
    private IStudentApplicationService _studentApplicationService;

    public StudentController(IStudentApplicationService studentApplicationService)
    {
        _studentApplicationService = studentApplicationService;
    }

    [HttpGet("students")]
    public async Task<IActionResult> Students()
    {

        var students = await _studentApplicationService.GetAllStudentsAsync();

        return Ok(students.ToApiResponse());
    }

    [HttpGet("student/{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentApplicationService.GetStudentByIdAsync(id);

        return Ok(student.ToApiResponse());
    }

    [HttpGet("GetStudentByNationalCode/nationalCode")]
    public async Task<IActionResult> GetStudentByNationalCode(string nationalCode)
    {
        var student = await _studentApplicationService.GetStudentByNationalCodeAsync(nationalCode);

        return Ok(student.ToApiResponse());
    }

    [HttpPost("Student")]
    public async Task<IActionResult> Student(AddStudentDto addStudentDto)
    {
        var serviceResponse = await _studentApplicationService.AddStudentAsync(addStudentDto);

        return Ok(serviceResponse.ToApiResponse());
    }

    [HttpDelete("Student/{id}")]
    public async Task<IActionResult> Student(int id)
    {
        var serviceResponse = await _studentApplicationService.DeleteStudentAsync(id);

        return Ok(serviceResponse.ToApiResponse());
    }
}
