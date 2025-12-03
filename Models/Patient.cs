namespace patientAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   // prevents null issues. .NET encourges non-nullable defaults
        public int Age { get; set;}
        public string Gender { get; set;} = string.Empty;  

    }
}