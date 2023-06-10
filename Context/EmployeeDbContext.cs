using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_EntityFrameworkCore_CodeFirstApproach.Context
{
    //This class will contain all the model's information which are responsible for creating the tables in the databae. 
    //Here we will define our Employee class as DbSet. 
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
