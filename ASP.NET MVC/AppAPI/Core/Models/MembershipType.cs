using System.ComponentModel.DataAnnotations.Schema;

namespace AppAPI.Core.Models
{
    [Table("MembershipTypes")]
    public class MembershipType : Identity
    {
        public short SignupFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}
