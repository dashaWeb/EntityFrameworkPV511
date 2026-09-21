using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Loading_types
{
    public class CompanyDb : DbContext
    {
        public CompanyDb()
        {
            /*this.Database.EnsureDeleted();
            this.Database.EnsureCreated();*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@" 
                            Data Source = (localdb)\MSSQLLocalDB;
                            Initial Catalog = Company_PV_511;
                            Integrated Security = True;
                            Connect Timeout = 2;
                            ")
                /*.UseLazyLoadingProxies()*/;
        }

        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }

    [Table("Employees")]
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        [Required] // not null
        [MaxLength(50)] // nvarchar(50)
        [Column("FirstName")]
        public string Name { get; set; } // null [Required] -->  not null
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        public double Salary { get; set; }
        [NotMapped]
        public string FullName => Name + " " + Surname;
        public DateTime? Birthdate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } = null;

        // foteign key one to many
        public int DepartmentId { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        // property navigation
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }

        // many to many
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }
        // Primary key naming --> ID, Id, id / EntityName + ID =  CountryId
        [Key] // primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
    public class Project
    {
        public Project()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
