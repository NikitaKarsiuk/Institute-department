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
    /// Interaction logic for Speciality.xaml
    /// </summary>
    public partial class Speciality : Window
    {
        private int Id { get; set; }
        public Speciality(int Id = -1)
        {

            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                DepartmentComboBox.ItemsSource = db.Department.ToList();
                FormOfStudyComboBox.ItemsSource = db.FormOfStudy.ToList();
                    
                if (Id != -1)
                {
                    var specialityItem = db.Speciality.Find(Id);

                    CodeTextBox.Text = specialityItem.Code.ToString();
                    NameTextBox.Text = specialityItem.Name.ToString();
                    QualificationeTextBox.Text = specialityItem.Qualification.ToString();
                    DepartmentComboBox.SelectedItem = specialityItem.Department;
                    FormOfStudyComboBox.SelectedItem = specialityItem.FormOfStudy;
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (DataContext db = new Model.DataContext())
                {
                    //Code Name Qualification Department FormOfStudy
                    if (CodeTextBox.Text == "")

                        throw new ArgumentException("Ошибка. Поле 'Код' должен содержать код специальности");
                    if (Id == -1)
                    {
                        if (db.Speciality.Where(x => x.Code.ToString() == CodeTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Поле 'Код' уже сущесвует");
                    }
                    else
                    {
                        if (db.Speciality.Where(x => x.Code.ToString() == CodeTextBox.Text).Count() > 1)
                            throw new ArgumentException("Ошибка. Поле 'Код' уже сущесвует");
                    }
                    if (NameTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Навазние' должно содержать информацию");
                    if (Id == -1)
                    {
                        if (db.Speciality.Where(x => x.Name == NameTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Поле 'Навазние' уже сущесвует");
                    }
                    else
                    {
                        if (db.Speciality.Where(x => x.Name == NameTextBox.Text).Count() > 1)
                            throw new ArgumentException("Ошибка. Поле 'Навазние' уже сущесвует");
                    }
                    if (!Regex.IsMatch(NameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Поле 'Навазние' должно содержать кириллицу");
                    if (QualificationeTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Квалификация' должно содержать информацию");
                    if (Id == -1)
                    {
                        if (db.Speciality.Where(x => x.Name == QualificationeTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Поле 'Квалификация' уже сущесвует");
                    }
                    else
                    {
                        if (db.Speciality.Where(x => x.Name == QualificationeTextBox.Text).Count() > 1)
                            throw new ArgumentException("Ошибка. Поле 'Квалификация' уже сущесвует");
                    }
                    if (!Regex.IsMatch(QualificationeTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Поле 'Квалификация' должно содержать кириллицу");
                    if(DepartmentComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Выберите кафедру");
                    if (FormOfStudyComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Выберите форму обучения");

                    if (Id == -1)
                    {
                        db.Speciality.Add(new Model.Speciality()
                        {
                            Code = int.Parse(CodeTextBox.Text),
                            Name = NameTextBox.Text,
                            Qualification = QualificationeTextBox.Text,
                            DepartmentId = (DepartmentComboBox.SelectedItem as Model.Department).Id,
                            FormOfStudyId = (FormOfStudyComboBox.SelectedItem as Model.FormOfStudy).Id
                        });;
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var specialityItem = db.Speciality.Find(Id);
                        specialityItem.Code = int.Parse(CodeTextBox.Text);
                        specialityItem.Name = NameTextBox.Text;
                        specialityItem.Qualification = QualificationeTextBox.Text;
                        specialityItem.DepartmentId = (DepartmentComboBox.SelectedItem as Model.Department).Id;
                        specialityItem.FormOfStudyId = (FormOfStudyComboBox.SelectedItem as Model.FormOfStudy).Id;
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
