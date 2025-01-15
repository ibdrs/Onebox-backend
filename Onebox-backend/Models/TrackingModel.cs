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

        public class TrackingInfo
        {
            public List<Leveringen> Leveringen { get; set; }
            public List<Klant> Klanten {  get; set; }
        }
        public async Task<TrackingInfo> GetAllTrackingsAsync(int limit)
        {
            var deliveries = await _context.Leveringen
                .Take(limit)
                .ToListAsync();

            var customers = await _context.Klanten
                .Take(limit)
                .ToListAsync();

            return new TrackingInfo
            {
                Leveringen = deliveries,
                Klanten = customers
            };
        }


        public async Task<TrackingInfo> GetTrackingAsync(int klantId)
        {
            var deliveries = await _context.Leveringen
                .Where(l => l.KlantId == klantId)
                .ToListAsync();

            var customers = await _context.Klanten
                .Where(k => k.KlantId == klantId)
                .ToListAsync();

            return new TrackingInfo
            {
                Leveringen = deliveries,
                Klanten = customers
            };
        }
    }
}
