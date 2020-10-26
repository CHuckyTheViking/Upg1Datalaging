using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibary.Models
{
    public class PersonViewModel
    {

        public ObservableCollection<Person> People { get; set; }

        public PersonViewModel()
        {
            People = new ObservableCollection<Person>();
           // People.Add(new Person("Jesper", "Müllern", "FUruvägen 14", "asdas@msn.com", "student"));
            //People.Add(new Person("Pontus", "Müllern", "Norrgatan 23", "hehe@hotmail.se", "lager"));
        }
        //public PersonViewModel(Person person)
        //{
        //    People = new ObservableCollection<Person>();
        //    People.Add(new Person("Jesper", "Müllern", "FUruvägen 14", "asdas@msn.com", "student"));
        //    People.Add(new Person("Pontus", "Müllern", "Norrgatan 23", "hehe@hotmail.se", "lager"));
        //    People.Add(new Person(person.FirstName, person.LastName, person.Address, person.Email, person.JobTitle));
        //}

    }
}
