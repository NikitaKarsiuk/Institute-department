using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            SubjectInformation = new HashSet<SubjectInformation>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<SubjectInformation> SubjectInformation { get; set; }
    }
}
