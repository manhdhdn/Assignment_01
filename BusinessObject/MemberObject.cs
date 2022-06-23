using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class MemberObject
    {
        [Key]
        public int MemberID { get; set; }
        public string MemberName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;    
    }
}