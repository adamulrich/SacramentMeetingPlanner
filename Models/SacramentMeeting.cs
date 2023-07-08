using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public int sacramentMeetingId { get; set; }

        [Required]
        public string wardName { get; set; }

        [Required]
        public string conductor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        public string openingPrayer { get; set; }

        [Required]
        public int openingHymnId { get; set; }
        public Hymn? openingHymn { get; set; }

        [Required]
        public int sacramentHymnId { get; set; }
        public Hymn? sacramentHymn { get; set; }

        public int restHymnId { get; set; }
        public Hymn? restHymn { get; set; }

        public string? specialMusicalNumber { get; set; }

        [Required]
        public int closingHymnId { get; set; }
        public Hymn? closingHymn { get; set; }

        [Required]
        public string closingPrayer { get; set; }

        public ICollection<Speaker>? speakers { get; set; }

        public string speakerNames
        {
            get
            {
                string returnValue = "";
                if (speakers != null) {
                    foreach (Speaker s in speakers)
                    {
                        returnValue += s.name + "\n";
                    }
                    
                }
                return returnValue;
            }
        }

    }
}
