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
    /// Interaction logic for SubjectInformation.xaml
    /// </summary>
    public partial class SubjectInformation : Window
    {
        private int Id { get; set; }
        public SubjectInformation(int Id = -1)
        {

            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                SpecialityComboBox.ItemsSource = db.Speciality.ToList();
                SubjectComboBox.ItemsSource = db.Subject.ToList();
                TermComboBox.ItemsSource = db.Term.ToList();

                if (Id != -1)
                {
                    var subjectItem = db.SubjectInformation.Find(Id);

                    SpecialityComboBox.SelectedItem = subjectItem.Speciality;
                    SubjectComboBox.SelectedItem = subjectItem.Subject;
                    TermComboBox.SelectedItem = subjectItem.Term;
                    LectureTextBox.Text = subjectItem.LectureHours.ToString();
                    LaboratoryTextBox.Text = subjectItem.LaboratoryHours.ToString();
                    PracticalTextBox.Text = subjectItem.PracticalHours.ToString();
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new Model.DataContext())
                {
                    var subjectInformationlist = db.SubjectInformation.ToList();
                    foreach(var subject in subjectInformationlist)
                    {
                        if(subject.SpecialityId == (SpecialityComboBox.SelectedItem as Model.Speciality).Id && subject.SubjectId == (SubjectComboBox.SelectedItem as Model.Subject).Id && subject.TermId == (TermComboBox.SelectedItem as Model.Term).Id)
                        {
                            throw new ArgumentException("Ошибка, данный семестр уже существует для дисциплины");
                        }
                    }
                    if (LectureTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Часы на лекции' должно содержать часы");
                    if (int.Parse(LectureTextBox.Text) > 0 && 200 < int.Parse(LectureTextBox.Text))
                        throw new ArgumentException("Ошибка. Поле 'Часы на лекции' не должно быть меньше 0 и больше 200");
                    if (LaboratoryTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Часы на лабораторные' должно содержать часы");
                    if (int.Parse(LaboratoryTextBox.Text) > 0 && 200 < int.Parse(LaboratoryTextBox.Text))
                        throw new ArgumentException("Ошибка. Поле 'Часы на лабораторные' не должно быть меньше 0 и больше 200");
                    if (PracticalTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Часы на практику' должно содержать часы");
                    if (int.Parse(PracticalTextBox.Text) > 0 && 200 < int.Parse(PracticalTextBox.Text))
                        throw new ArgumentException("Ошибка. Поле 'Часы на практику' не должно быть меньше 0 и больше 200");



                    if (Id == -1)
                    {
                        db.SubjectInformation.Add(new Model.SubjectInformation()
                        {
                            
                            SpecialityId = (SpecialityComboBox.SelectedItem as Model.Speciality).Id,
                            SubjectId = (SubjectComboBox.SelectedItem as Model.Subject).Id,
                            TermId = (TermComboBox.SelectedItem as Model.Term).Id,
                            LectureHours = int.Parse(LectureTextBox.Text),
                            LaboratoryHours =  int.Parse(LaboratoryTextBox.Text),
                            PracticalHours = int.Parse(PracticalTextBox.Text)
                        }); 
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var subjectInformationItem = db.SubjectInformation.Find(Id);
                        subjectInformationItem.SpecialityId = (SpecialityComboBox.SelectedItem as Model.Speciality).Id;
                        subjectInformationItem.SubjectId = (SubjectComboBox.SelectedItem as Model.Subject).Id;
                        subjectInformationItem.TermId = (TermComboBox.SelectedItem as Model.Term).Id;
                        subjectInformationItem.LectureHours = int.Parse(LectureTextBox.Text);
                        subjectInformationItem.LaboratoryHours = int.Parse(LaboratoryTextBox.Text);
                        subjectInformationItem.PracticalHours = int.Parse(PracticalTextBox.Text);
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
