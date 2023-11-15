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
    /// Interaction logic for SpecialityHoursList.xaml
    /// </summary>
    public partial class SpecialityHoursList : Window
    {
        private int Id { get; }
        public SpecialityHoursList(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();
            using (DataContext db = new DataContext())
            {
                var specialityList = db.SubjectInformation.Where(x => x.SpecialityId == Id).ToList();

                int summaryLecture = 0;
                int summaryLaboratory = 0;
                int summaryPractical = 0;

                foreach (var speciality in specialityList)
                {
                    summaryLecture += speciality.LectureHours;
                    summaryLaboratory += speciality.LaboratoryHours;
                    summaryPractical += speciality.PracticalHours;
                }

                LectureHoursTextBox.Text = summaryLecture.ToString();
                LaboratoryHoursTextBox.Text = summaryLaboratory.ToString();
                PracticalHoursTextBox.Text = summaryPractical.ToString();
            }
                
        }
    }
}
