using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
    
    
    namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>
    {
        private string allPhones;
        private string allEmail;

        public ContactData()
        {
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName && FirstName == other.FirstName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneWork { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhone
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHome) + CleanUp(PhoneMobile) + CleanUp(PhoneWork)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmail 
        {
            get 
                { 
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
                }
            set 
                {
                allEmail = value;
                } 
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email.Replace(" ", "") + "\r\n";
            }
        }

        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace (phone, "[ -()]", "") + "\r\n";
            }
        }
    }
}
