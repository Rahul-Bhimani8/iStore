using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;
using static System.Net.Mime.MediaTypeNames;

namespace ProfilePage
{
    public class Employee
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string User { get; set; } 
        public string DateOfBirth { get; set; } 
        public string Password { get; set; } 
    }
}

