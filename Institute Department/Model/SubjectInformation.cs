using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("SubjectInformation")]
    public partial class SubjectInformation
    {
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public int SubjectId { get; set; }
        public int LectureHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int PracticalHours { get; set; }
        public int TermId { get; set; }
       
        public virtual Speciality Speciality { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Term Term { get; set; }
    }
}
