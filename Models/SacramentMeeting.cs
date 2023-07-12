using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public int sacramentMeetingId { get; set; }

        [Required]
        [Display(Name = "Ward Name")]
        public string wardName { get; set; }

        [Required]
        [Display(Name = "Conductor")]
        public string conductor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Opening Prayer")]
        public string openingPrayer { get; set; }

        [Required]
        public int openingHymnId { get; set; }
        [Display(Name = "Opening Hymn")]
        public Hymn? openingHymn { get; set; }
        

        [Required]
        public int sacramentHymnId { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public Hymn? sacramentHymn { get; set; }

        public int restHymnId { get; set; }
        [Display(Name = "Rest Hymn")]
        public Hymn? restHymn { get; set; }

        [Display(Name = "Special Musical Number")]
        public string? specialMusicalNumber { get; set; }

        [Required]
        public int closingHymnId { get; set; }
        [Display(Name = "Closing Hymn")]
        public Hymn? closingHymn { get; set; }

        [Required]
        [Display(Name = "Closing Prayer")]
        public string closingPrayer { get; set; }

        public ICollection<Speaker>? speakers { get; set; }

        [Display(Name = "Speaker")]
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
