using Institute_Department.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Institute_Department.Windows
{
    /// <summary>
    /// Interaction logic for SubjectInformationTypeOfReport.xaml
    /// </summary>
    public partial class SubjectInformationTypeOfReport : Window
    {
        private int Id { get; }
        public SubjectInformationTypeOfReport(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            using (DataContext db = new DataContext())
            {
                var items = db.SubjectTypeOfReport.Where(x => x.SubjectInformationId == Id).ToList();
                subjectTypeOfReportDataGrid.ItemsSource = items;
            }
        }
    }
}
