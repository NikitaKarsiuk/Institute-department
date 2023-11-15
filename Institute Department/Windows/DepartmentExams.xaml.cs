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
    /// Interaction logic for DepartmentExams.xaml
    /// </summary>
    public partial class DepartmentExams : Window
    {
        private int Id { get; }
        public DepartmentExams(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                var specialityList = db.Speciality.Where(x => x.DepartmentId == Id).ToList();
                List<Model.SubjectInformation> subjectList = new List<Model.SubjectInformation>();
                foreach (var speciality in specialityList)
                {
                    foreach (var item in db.SubjectInformation.Where(x => x.SpecialityId == speciality.Id).ToList())
                    {
                        subjectList.Add(item);
                    }
                }
                var testTypeOfReport = db.TypeOfReport.Where(x => x.Name == "Зачет").First();
                var examTypeOfReport = db.TypeOfReport.Where(x => x.Name == "Экзамен").First();
                var courseworkTypeOfReport = db.TypeOfReport.Where(x => x.Name == "Курсовая работа").First();
                int testCount = 0;
                int examCount = 0;
                int courseworkCount = 0;
                foreach (var subjectTypeOfReport in db.SubjectTypeOfReport.ToList())
                    {
                        foreach(var subject in subjectList)
                        {
                            if(subjectTypeOfReport.SubjectInformationId == subject.Id && subjectTypeOfReport.TypeOfReportId == testTypeOfReport.Id)
                            {
                                testCount++;
                            }
                            else
                            if (subjectTypeOfReport.SubjectInformationId == subject.Id && subjectTypeOfReport.TypeOfReportId == examTypeOfReport.Id)
                            {
                                examCount++;
                            }
                            else
                            if (subjectTypeOfReport.SubjectInformationId == subject.Id && subjectTypeOfReport.TypeOfReportId == courseworkTypeOfReport.Id)
                            {
                                courseworkCount++;
                            }
                        }    
                    }

                TestTextBox.Text = testCount.ToString();
                ExamTextBox.Text = examCount.ToString();
                CourseworkTextBox.Text = courseworkCount.ToString();
                }
        }
    }
}
