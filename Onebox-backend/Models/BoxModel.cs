using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Onebox_backend.Models.Database;

namespace Onebox_backend.Models
{
    public class BoxModel
    {
        private readonly OneboxDBContext _context;

        public BoxModel(OneboxDBContext context)
        {
            _context = context;
        }

        public async Task<List<Box>> GetAllBoxesAsync()
        {
            var boxes = await _context.Boxes.ToListAsync();
            return boxes;
        }

        public async Task<string> GetStateAsync(int boxId)
        {
            var box = await _context.Boxes.FindAsync(boxId);
            if (box == null)
            {
                throw new Exception("Box not found.");
            }
            if (box.State == false)
            {
                return "locked";
            }
            else if(box.State == true)
            {
                return "unlocked";
            }

            return $"Box {boxId} has an unknown state"; // error handling
        }

        public async Task LockAsync(int boxId)
        {
            var box = await _context.Boxes.FindAsync(boxId);
            if (box == null)
            {
                throw new KeyNotFoundException("Box not found.");
            }

            box.State = false; // Close the box
            await _context.SaveChangesAsync();
        }

        public async Task UnlockAsync(int boxId)
        {
            var box = await _context.Boxes.FindAsync(boxId);
            if (box == null)
            {
                throw new KeyNotFoundException("Box not found.");
            }

            box.State = true; // Open the box
            await _context.SaveChangesAsync();
        }
    }
}