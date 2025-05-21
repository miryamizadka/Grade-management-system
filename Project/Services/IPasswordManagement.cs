namespace Project.Services
{
    public interface IPasswordManagement
    {
        bool isValid(string name, int password);
    }
}