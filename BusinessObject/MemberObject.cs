using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class MemberObject
    {
        [Key]
        [Range(1, int.MaxValue)]
        public int MemberID { get; set; }
        [Range(0, 50)]
        public string MemberName { get; set; } = null!;
        [EmailAddress]
        [Range(0, 50)]
        public string Email { get; set; } = null!;
        [Range(6, 20)]
        public string Password { get; set; } = null!;
        [Range(0, 30)]
        public string City { get; set; } = null!;
        [Range(0, 30)]
        public string Country { get; set; } = null!;    
    }
}