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

        public class AllTrackingInfo
        {
            public List<Leveringen> Leveringen { get; set; }
            public List<Klant> Klanten {  get; set; }
        }
        public class TrackingDetails
        {
            public string TrackAndTraceCode { get; set; }
            public DateTime LeveringsDatum { get; set; }
            public TimeSpan SchattingLevertijd { get; set; }
            public string Naam { get; set; }
            public string Adres { get; set; }
            public string Woonplaats { get; set; }
            public string Postcode { get; set; }
        }

        public async Task<List<TrackingDetails>> GetAllTrackingsAsync(int limit)
        {
            var trackingDetails = await _context.Leveringen
                .Take(limit)
                .Join(
                    _context.Klanten,
                    levering => levering.KlantId,
                    klant => klant.KlantId,
                    (levering, klant) => new TrackingDetails
                    {
                        TrackAndTraceCode = levering.Track_and_trace_code,
                        LeveringsDatum = levering.Datum,
                        SchattingLevertijd = levering.Tijd,
                        Naam = klant.Naam,
                        Adres = klant.Adres,
                        Woonplaats = klant.Woonplaats,
                        Postcode = klant.Postcode
                    }
                )
                .ToListAsync();

            return trackingDetails;
        }



        public async Task<TrackingDetails> GetTrackingAsync(int klantId)
        {
            var trackingDetail = await _context.Leveringen
                .Where(l => l.KlantId == klantId)
                .Join(
                    _context.Klanten,
                    levering => levering.KlantId,
                    klant => klant.KlantId,
                    (levering, klant) => new TrackingDetails
                    {
                        TrackAndTraceCode = levering.Track_and_trace_code,
                        LeveringsDatum = levering.Datum,
                        SchattingLevertijd = levering.Tijd,
                        Naam = klant.Naam,
                        Adres = klant.Adres,
                        Woonplaats = klant.Woonplaats,
                        Postcode = klant.Postcode
                    }
                )
                .OrderBy(l => l.LeveringsDatum)
                .FirstOrDefaultAsync();

            return trackingDetail;
        }

    }
}
