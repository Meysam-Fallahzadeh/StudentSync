using Common.Utilities;
using StudentSync.Domain.Common;

namespace StudentSync.Domain.Students;

public class Student : BaseEntity<int>
{
    private string _nationalCode;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string NationalCode
    {
        get
        {
            return _nationalCode;
        }
        set
        {
            if (_nationalCode.IsInValidNationalCode())
                throw new Exception("National in Invalid");
            _nationalCode = value;
        }
    }
    public int Age { get; set; }

}
