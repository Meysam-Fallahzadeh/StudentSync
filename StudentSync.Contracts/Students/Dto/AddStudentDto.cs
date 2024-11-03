using StudentSync.Domain.Students;

namespace StudentSync.Data.Ef.Students.Dto;
public class AddStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public int Age { get; set; }

    public Student ToStudent()
    {
        return new Student 
        { 
            FirstName = FirstName, 
            LastName = LastName, 
            NationalCode = NationalCode 
        };
    }
}
