using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_Department.Model
{
    [Table("SubjectTypeOfReport")]
    public partial class SubjectTypeOfReport
    {
        public int Id { get; set; }
        public int SubjectInformationId { get; set; }
        public int TypeOfReportId { get; set; }
        public virtual SubjectInformation SubjectInformation { get; set; }
        public virtual TypeOfReport TypeOfReport { get; set; }
    }
}
