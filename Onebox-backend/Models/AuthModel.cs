using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onebox_backend.Models.Database;

namespace Onebox_backend.Models
{
    public class AuthModel
    {
        private readonly OneboxDBContext _context;

        public AuthModel(OneboxDBContext context)
        {
            _context = context;
        }

        public async Task<(bool isValid, int customerId)> ValidateUserAsync(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                return (true, user.KlantID);
            }

            return (false, 0);
        }
    }
}
