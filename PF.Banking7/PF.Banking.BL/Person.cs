using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 a.	SSN (string)
 b.	FirstName (string)
 c.	LastName (string)
 d.	BirthDate (DateTime)
 e.	Age (int) (read-only calculated)

     */
namespace PF.Banking.BL
{
    public class Person
    {
        private string ssn;

        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime birthdate;

        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }




    }
}
