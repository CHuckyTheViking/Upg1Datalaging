using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SharedClassLibary.Models
{
    
    public class Person
    {
        public Person()
        {
        }
        
        public Person(string firstName, string lastName, string address, string email, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            JobTitle = jobTitle;
        }

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Details => $"{FirstName} {LastName} {Address} {Email} {JobTitle}";


    }
}
