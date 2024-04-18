namespace  ControlLaboral.Models
{
    public class TimeControl
    {
        public int Id { get; set; }
        public DateTime DateEntry { get; set;}
        public DateTime DateExit { get; set; }
        public int UserId { get; set; }
    }
}