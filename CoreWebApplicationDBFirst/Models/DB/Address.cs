using System;
using System.Collections.Generic;

namespace CoreWebApplicationDBFirst.Models.DB
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int EmployeeId { get; set; }

        public Employee IdNavigation { get; set; }
    }
}
