# Sample_EntityFrameworkCore_CodeFirstApproach


First, we will install the package like Microsoft.EntityFrameworkCore.SqlServer which will provide classes to connect with SQL Server for CRUD Operation to Entity Framework Core.

The second required NuGet package is Microsoft.EntityFrameworkCore.Tools, which will help us to work with database related activity like add migration, script migration, get dbcontext, update database etc.

let’s move and create a folder name as ‘Model’ and create a Model class as ‘EmployeeDetails’ in this with the following properties as follows.

 public class EmployeeDetails  
    {  
        public int EmployeeId { get; set; }  
        public string Name { get; set; }  
        public string Address { get; set; }  
        public string CompanyName { get; set; }  
        public string Designation { get; set; }  
    }  


We will create another class inside the Context folder as ‘EmployeeDbContext’ that will inherit to DbContext class. This class will contain all the model's information which are responsible for creating the tables in the databae. Here we will define our EmployeeDetail class as DbSet.

 public class EmployeeDbContext : DbContext  
    {  
        public EmployeeDbContext(DbContextOptions options) : base(options)  
        {  
        }  
  
        DbSet<EmployeeDetail> Employees { get; set; }  
    }  

Add connection details in appsettings.Development.json

"ConnectionStrings": {
    "ProjectDbConnection": "Data Source=SAYANTANGHOSH;Initial Catalog=Sample_WebAPI;Integrated Security=True"
  }

To use this connection string, first, we will change the ConfigureServices method in Startup.cs class as follows. 

services.AddDbContext<EmployeeDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("ProjectDbConnection")));

For creating the migration code, we use ‘add-migration MigrationName’ command. So, let’s perform this operation and see what happens. Therefore, in the Package Manager Console, just type ‘add-migration initialmigration’ command and press Enter.

add-migration initialmigration

We have only created the migration script which is responsible for creating the database and its table. But we've not created the actual database and tables. So, let's execute the migration script and generate the database and tables. 

So, let's execute the migration script and generate the database and tables. Therefore, executing the migration scripts we have to execute ‘update-database’ command. So, let's perform it as follows. 

For now, we have only one migration script available that is why we are not providing the name of the migration. If we have multiple migration scripts, then we have to provide the name along with command as follows.

update-database

Update database table

Now, let's modify the Employee model and add a new property as Salary with float type as follows

 public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; } // Added new field
    }

Move to package manager console and run the following command to add migration, this time we have given the name of migration as
'addedsalary'.

add-migration addedsalary

Once the above command execution will be completed, it will create a new class for migration name as follows. Here we can see, migration builder has the configuration for adding a new column as salary.

 public partial class addedsalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "EmployeeDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "EmployeeDetails");
        }
    }

For updating the table in the database with the new column as salary, we have to run following command for updating the database.

update-database addedsalary

