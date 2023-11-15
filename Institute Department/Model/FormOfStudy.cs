using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("FormOfStudy")]
    public partial class FormOfStudy
    {
        public FormOfStudy() 
        {
            Speciality = new HashSet<Speciality>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Speciality>  Speciality { get; set; }
    }
}
