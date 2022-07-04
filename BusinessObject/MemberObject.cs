using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class MemberObject
    {
        [Required, Range(1, int.MaxValue)]
        public int MemberID { get; set; }
        [Required, StringLength(50)]
        public string MemberName { get; set; } = null!;
        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; } = null!;
        [Required, Range(6, 20), DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required, StringLength(30)]
        public string City { get; set; } = null!;
        [Required, StringLength(30)]
        public string Country { get; set; } = null!;
    }
}