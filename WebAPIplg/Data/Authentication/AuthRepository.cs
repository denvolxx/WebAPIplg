using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using WebAPIplg.Models;

namespace WebAPIplg.Data.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponce<string>> Login(string username, string password)
        {
            var response = new ServiceResponce<string>();

            try
            {
                var moderator = await _context.Moderator.FirstOrDefaultAsync(m => m.UserName.ToLower() == username.ToLower());
                if (moderator == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                }
                else if (!VerifyPasswordHash(password, moderator.PasswordHash, moderator.PasswordSalt))
                {
                    response.Success = false;
                    response.Message = "Incorrect password";
                }
                else
                {
                    response.Success = true;
                    response.Value = moderator.UserName;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<bool> ModeratorExists(string username)
        {
            if (await _context.Moderator.AnyAsync(m => m.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }

            return false;
        }

        public async Task<ServiceResponce<string>> Register(Moderator moderator, string password)
        {
            var response = new ServiceResponce<string>();

            try
            {

                if (await ModeratorExists(moderator.UserName))
                {
                    response.Success = false;
                    response.Message = "User already exists";

                    return response;
                }

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                moderator.PasswordHash = passwordHash;
                moderator.PasswordSalt = passwordSalt;

                _context.Moderator.Add(moderator);
                await _context.SaveChangesAsync();

                response.Value = moderator.UserName;
                response.Success = true;
                response.Message = "Moderator registered";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
