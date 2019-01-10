using System;
using System.Collections.Generic;
using System.Text;

namespace MyDog
{
    class Exhibitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }

        public List<Dog> Dogs { get; set; }
    }
}
