using System;
using System.Collections.Generic;

namespace CoreWebApplicationDBFirst.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
}
