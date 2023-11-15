using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{

    [Table("TypeOfReport")]
    public partial class TypeOfReport
    {
        public TypeOfReport() 
        {
            SubjectTypeOfReport = new HashSet<SubjectTypeOfReport>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<SubjectTypeOfReport> SubjectTypeOfReport { get; set; }
    }
}
