using WebAPIplg.Models;

namespace WebAPIplg.Data.Authentication
{
    public interface IAuthRepository
    {
        Task<ServiceResponce<string>> Register(Moderator moderator, string password);
        Task<ServiceResponce<string>> Login(string username, string password);
        Task<bool> ModeratorExists(string username);
    }
}
