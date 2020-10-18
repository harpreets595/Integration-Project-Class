using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departement { get; set; }
        public string Position { get; set; }
        public decimal YearlySalary { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string fName, string lName, string dept, string pos, decimal yearlySal)
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Departement = dept;
            this.Position = pos;
            this.YearlySalary = yearlySal;
        }

        


    }
}
