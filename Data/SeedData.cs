using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentMeetingPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentMeetingPlannerContext>>()))
            {

                // Look for any movies.
                if (context.Hymn.Any())
                {
                    return;   // DB has been seeded
                }

                var fileName = @"Data\hymns.json";
                var HymnData = File.ReadAllText(fileName);
                var data = JsonConvert.DeserializeObject<Hymn[]>(HymnData);
                foreach (var item in data)
                {
                    context.Hymn.AddRange(item);
                    context.SaveChanges();
                }

            }
        }
    }
}
