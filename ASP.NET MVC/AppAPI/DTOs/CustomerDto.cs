using AppAPI.Core.Models;

namespace AppAPI.DTOs
{
    public class CustomerDto : Identity
    {
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
    }
}
