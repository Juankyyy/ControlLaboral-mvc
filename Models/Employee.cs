namespace ControlLaboral.Models
{
    public class Employee {
        public int Id {get; set; }
        public string Name {get; set; }
        public string LastName {get; set; }
        public Dateonly BirthDate {get; set; }
        public string Email {get; set; }
        public string Password {get; set; }
        public string Job {get; set; }
        public string Gender {get; set; }
    }
}