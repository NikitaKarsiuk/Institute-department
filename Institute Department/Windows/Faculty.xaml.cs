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
    /// Interaction logic for Faculty.xaml
    /// </summary>
    public partial class Faculty : Window
    {
        private int Id { get; }
        public Faculty(int Id = -1)
        {
            InitializeComponent();

            this.Id = Id;

            if (Id != -1)
            {
                using (DataContext db = new DataContext())
                {
                    var facultyItem = db.Faculty.Find(Id);

                    FacultyTextBox.Text = facultyItem.Name.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (FacultyTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Факультет' пустое");
                    if (!Regex.IsMatch(FacultyTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Поле 'Факультет' должно содержать только символы");

                    if (Id == -1)
                    {
                        if (db.Faculty.Where(x => x.Name == FacultyTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Данный факультет уже существует в базе данных");
                        else
                        {
                            if (db.Faculty.Where(x => x.Name == FacultyTextBox.Text).Count() > 1)
                                throw new ArgumentException("Ошибка. Данный факультет уже существует в базе данных");
                        }
                    }

                    if (Id == -1)
                    {

                        db.Faculty.Add(new Model.Faculty()
                        {
                            Name = FacultyTextBox.Text
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var facultyItem = db.Faculty.Find(Id);
                        facultyItem.Name = FacultyTextBox.Text;
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
