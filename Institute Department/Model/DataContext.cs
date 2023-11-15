using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public virtual DbSet<Department> Department { get; set;}
        public virtual DbSet<DepartmentPhone> DepartmentPhone{ get; set;}
        public virtual DbSet<FormOfStudy> FormOfStudy { get; set;}
        public virtual DbSet<Speciality> Speciality { get; set;}
        public virtual DbSet<Subject> Subject { get; set;}
        public virtual DbSet<SubjectInformation> SubjectInformation { get; set;}
        public virtual DbSet<SubjectTypeOfReport> SubjectTypeOfReport { get; set;}
        public virtual DbSet<Term> Term { get; set;}
        public virtual DbSet<TypeOfReport> TypeOfReport { get; set;}
        public virtual DbSet<Faculty> Faculty { get; set;}
    }
}
