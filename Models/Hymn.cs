namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        public int id { get; set; }

        public string title { get; set; }

        public int number { get; set; }

        public string display
        {
            get
            {
                return number.ToString() + " " + title.ToString();
             }
        }


    }
   
}
