using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("Department")]
    public partial class Department
    {
        public Department() 
        { 
            Speciality = new HashSet<Speciality>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }        
        public int FacultyId { get; set; }
        
        public virtual Faculty  Faculty { get; set; }
        public virtual ICollection<Speciality> Speciality { get; set; }
    }
}
