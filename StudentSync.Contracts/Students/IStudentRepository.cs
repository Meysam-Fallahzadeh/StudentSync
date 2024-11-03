using StudentSync.Domain.Students;
using StudentSync.Contracts.Common;

namespace StudentSync.Contracts.Students;

public interface IStudentRepository : IBaseRepository<Student,int>
{
    Task<Student?> GetByNationalCode(string nationalCode);
    Task<Student?> GetByNationalCodeAsNoTracking(string nationalCode);
}
