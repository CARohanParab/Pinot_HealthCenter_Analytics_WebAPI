using System.Collections.Generic;

namespace Pinot_HealthCenter_Analytics_WebAPI.Models
{
    public class Provider
    {
        public int ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
