using System;
using System.Collections.Generic;

namespace CoreWebApplicationDBFirst.Models.DB
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Gender { get; set; }

        public Address Address { get; set; }
    }
}
