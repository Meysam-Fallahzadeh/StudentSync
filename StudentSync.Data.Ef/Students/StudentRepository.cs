using Microsoft.EntityFrameworkCore;
using StudentSync.Domain.Students;
using StudentSync.Contracts.Students;
using StudentSync.Data.Ef.Common;

namespace StudentSync.Data.Ef.Students;

internal class StudentRepository : BaseRepository<Student, int>, IStudentRepository
{
    public StudentRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
    {
    }

    public async Task<Student?> GetByNationalCode(string nationalCode)
    {
        return await EntitySet.FirstOrDefaultAsync(e => e.NationalCode == nationalCode);
    }

    public async Task<Student?> GetByNationalCodeAsNoTracking(string nationalCode)
    {
        return await EntitySet.AsNoTracking().FirstOrDefaultAsync(e=>e.NationalCode == nationalCode);
    }
}
