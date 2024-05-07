using System.ComponentModel.DataAnnotations.Schema;
using InterviewAppMVC.ViewModels;

namespace InterviewAppMVC.Models
{
    [Table("MembershipTypes")]
    public class MembershipType : Identity
    {
        public short SignupFee { get; set; }
        public int  DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}
