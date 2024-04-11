using Models;
namespace Interfaces
{
    public interface IEmployeeUI
    {
        string ValidateEmployeeId();
        string ValidateText(string type);
        DateTime ValidateDate(string type);
        string ValidateEmail();
        string ValidatePhoneNumber();
    }
}
