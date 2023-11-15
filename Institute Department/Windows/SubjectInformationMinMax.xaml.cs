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
    /// Interaction logic for SubjectInformationMinMax.xaml
    /// </summary>
    public partial class SubjectInformationMinMax : Window
    {
        public SubjectInformationMinMax()
        {
            InitializeComponent();

           

            Model.SubjectInformation subjectInformationMinHours = new Model.SubjectInformation();
            Model.SubjectInformation subjectInformationMaxHours = new Model.SubjectInformation();

            using (DataContext db = new DataContext())
            {
                int minHours = 601;
                int maxHours = 0;

                foreach (var subject in db.SubjectInformation.ToList())
                {
                    if (minHours > (subject.LectureHours + subject.LaboratoryHours + subject.PracticalHours))
                    {
                        minHours = subject.LectureHours + subject.LaboratoryHours + subject.PracticalHours;
                        subjectInformationMinHours = subject;
                    }
                    
                    if (maxHours < (subject.LectureHours + subject.LaboratoryHours + subject.PracticalHours))
                    {
                        maxHours = subject.LectureHours + subject.LaboratoryHours + subject.PracticalHours;
                        subjectInformationMaxHours = subject;
                    }
                }

                subjectInformationDataGrid.Items.Add(subjectInformationMinHours);
                subjectInformationDataGrid.Items.Add(subjectInformationMaxHours);
            }
        }

        private void OpenTypeOfReportListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectInformationDataGrid.ItemsSource as List<Model.SubjectInformation>;
                var item = subjectInformationDataGrid.SelectedItem as Model.SubjectInformation;

                SubjectInformationTypeOfReport window = new SubjectInformationTypeOfReport(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                  
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
