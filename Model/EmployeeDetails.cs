using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_EntityFrameworkCore_CodeFirstApproach.Context
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; } // Added new field

        public string Office_Address { get; set; } // Added new field
    }
}
