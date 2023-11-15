using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("Term")]
    public partial class Term
    {
        public Term() 
        {
            SubjectInformation = new HashSet<SubjectInformation>();
        }

        public int Id { get; set; }
        public int Part { get; set; }

        public virtual ICollection<SubjectInformation> SubjectInformation { get; set; }
    }
}
