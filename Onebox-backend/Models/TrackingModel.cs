using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Onebox_backend.Models.Database;

namespace Onebox_backend.Models
{
    public class TrackingModel
    {
        private readonly OneboxDBContext _context;

        public TrackingModel(OneboxDBContext context)
        {
            _context = context;
        }
    }
}
