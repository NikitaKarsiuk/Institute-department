using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("Speciality")]
    public partial class Speciality
    {
        public Speciality()
        {
            SubjectInformation = new HashSet<SubjectInformation>();
        }
        public int Id { get; set; }
        public int Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Qualification { get; set; }
        public int FormOfStudyId { get; set; }
        public int DepartmentId { get; set; }   
        public virtual FormOfStudy FormOfStudy { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<SubjectInformation> SubjectInformation { get; set; }

    }
}
