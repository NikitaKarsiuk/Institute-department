using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{

    [Table("DepartmentPhone")]
    public partial class DepartmentPhone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
