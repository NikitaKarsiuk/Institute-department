using Institute_Department.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SubjectTypeOfReport.xaml
    /// </summary>
    public partial class SubjectTypeOfReport : Window
    {
        private int SubjectInformationId { get; }
        private int Id { get; }
        public SubjectTypeOfReport(int SubjectInformationId, int Id = -1 )
        {
            InitializeComponent();

            this.Id = Id;
            this.SubjectInformationId = SubjectInformationId;

            using (DataContext db = new DataContext())
            {
                TypeOfReportComboBox.ItemsSource = db.TypeOfReport.ToList();

                if(Id != -1)
                {
                    var typeOfReportSelected = db.SubjectTypeOfReport.Find(Id);
                    TypeOfReportComboBox.SelectedItem = typeOfReportSelected.TypeOfReport;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (TypeOfReportComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Вид зачета' не выбрано");

                    var subjectTypeOfReportList = db.SubjectTypeOfReport.Where(x => x.SubjectInformationId == SubjectInformationId).ToList();

                    if (Id == -1)
                    {
                        foreach (var subjectTypeOfReport in subjectTypeOfReportList)
                        {
                            if (subjectTypeOfReport.TypeOfReportId == (TypeOfReportComboBox.SelectedItem as Model.TypeOfReport).Id)
                            {
                                throw new ArgumentException("Ошибка. Данный вид зачета уже существует");
                            }
                        }
                    }
                    else
                    {
                        foreach (var subjectTypeOfReport in subjectTypeOfReportList)
                        {
                            if (subjectTypeOfReport.TypeOfReportId == (TypeOfReportComboBox.SelectedItem as Model.TypeOfReport).Id && Id != subjectTypeOfReport.Id)
                            {
                                throw new ArgumentException("Ошибка. Данный вид зачета уже существует");
                            }
                        }
                    }

                    if (Id == -1)
                    {
                        db.SubjectTypeOfReport.Add(new Model.SubjectTypeOfReport()
                        {
                            SubjectInformationId = SubjectInformationId,
                            TypeOfReportId = (TypeOfReportComboBox.SelectedItem as Model.TypeOfReport).Id
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var subjectTypeOfReportItem = db.SubjectTypeOfReport.Find(Id);
                        subjectTypeOfReportItem.TypeOfReportId = (TypeOfReportComboBox.SelectedItem as Model.TypeOfReport).Id;
                        db.SaveChanges();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
