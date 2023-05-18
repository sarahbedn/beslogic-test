using System.ComponentModel.DataAnnotations;

namespace Beslogic.Pratice.API.Models
{
    public class Aircraft
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int SerialNumber { get; set; }
        public int RegistrationNumber { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
