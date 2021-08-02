using BlueBadgeFinal.Data.Entities;
using BlueBadgeFinal.Models.TheatreModels;
using BlueBadgeFinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Service
{
    public class TheatreService
    {
        private readonly Guid _userId;
        public TheatreService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTheatre(TheatreCreate model)
        {
            var entity =
                new Theatre()
                {
                    Name = model.Name,
                    Address = model.Address,
                    CreatedUTC = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Theatres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TheatreListItem> GetTheatres(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Theatres
                        .Where(e => e.Name == name)
                        .Select(
                            e =>
                                new TheatreListItem
                                {
                                    TheatreID = e.TheatreID,
                                    Name = e.Name,
                                    CreatedUTC = e.CreatedUTC
                                }
                            );
                return query.ToArray();
            }
        }
    }
}
