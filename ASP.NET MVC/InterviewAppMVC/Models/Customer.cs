using System.ComponentModel.DataAnnotations;
using InterviewAppMVC.ViewModels;

namespace InterviewAppMVC.Models
{
    public class Customer : Identity
    {
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
