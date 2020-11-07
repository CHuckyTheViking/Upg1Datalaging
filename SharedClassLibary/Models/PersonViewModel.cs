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
        }

    }
}
