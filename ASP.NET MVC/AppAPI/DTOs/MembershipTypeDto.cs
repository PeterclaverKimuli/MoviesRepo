using AppAPI.Core.Models;

namespace AppAPI.DTOs
{
    public class MembershipTypeDto : Identity
    {
        public short SignupFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}
