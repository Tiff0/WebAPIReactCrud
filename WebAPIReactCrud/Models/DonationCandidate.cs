using System.ComponentModel.DataAnnotations;

namespace WebAPIReactCrud.Models
{
    public class DonationCandidate
    {
        [Key]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string MobileTelephoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int BloodGroupId { get; set; }
        public string Address { get; set; }
    }
}