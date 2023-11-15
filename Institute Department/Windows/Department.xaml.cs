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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window
    {
        private int Id { get; }
        public Department(int Id = -1)
        {
            InitializeComponent();

            this.Id = Id;


                using (DataContext db = new DataContext())
                {
                    FacultyComboBox.ItemsSource = db.Faculty.ToList();

                    if(Id != -1)
                    {
                        var departmentItem = db.Department.Find(Id);

                        NameTextBox.Text = departmentItem.Name;
                        FacultyComboBox.SelectedItem = departmentItem.Faculty;
                    }
                    
                }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new Model.DataContext())
                {
                    if (NameTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Кафедра' должно содержать информацию");
                    if(!Regex.IsMatch(NameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Поле 'Кафедра' должно содержать кириллицу");
                    if(FacultyComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Факультет' должно содержать информацию");

                    if(Id == -1)
                    {
                        db.Department.Add(new Model.Department() 
                        { 
                            Name = FacultyComboBox.Text,
                            FacultyId = (FacultyComboBox.SelectedItem as Model.Faculty).Id
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var departmentItem = db.Department.Find(Id);
                        departmentItem.Name = NameTextBox.Text;
                        departmentItem.FacultyId = (FacultyComboBox.SelectedItem as Model.Faculty).Id;
                        db.SaveChanges();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
