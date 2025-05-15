namespace Assembly.RealStateManagement.Security.Interfaces;

public interface IUserResolverService
{
    int GetUserId();
    string GetUserRole();
    string GetUserEmail();
}
