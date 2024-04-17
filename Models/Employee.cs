namespace ControlLaboral.Models
{
    public class Employee {
        public int Id {get; set; }
        public string Names {get; set; }
        public string LastNames {get; set; }
        public string Email {get; set; }
        public string Password {get; set; }
        public int DocumentNumber {get; set; }
        public string Gender {get; set; }
        public System.DateTime BirthDate {get; set; }
        public string Job {get; set; }
    }
}