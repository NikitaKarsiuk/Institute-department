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
    /// Interaction logic for DepartmentPhone.xaml
    /// </summary>
    public partial class DepartmentPhone : Window
    {
        private int Id { get; }
        private int DepartmentID { get; }
        public DepartmentPhone(int DepartmentID, int Id = -1)
        {
            InitializeComponent();

            this.Id = Id;
            this.DepartmentID = DepartmentID;
            if (Id != -1)
            {
                using (DataContext db = new DataContext())
                {
                    var phoneItem = db.DepartmentPhone.Find(Id);

                    PhoneTextBox.Text = phoneItem.Phone.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (PhoneTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Телефон' пустое");
                    if (!Regex.IsMatch(PhoneTextBox.Text, @"^[+]375[(]((29)|(44)|(33)|(25)|(17))[)]\d{3}[-]\d{2}[-]\d{2}$"))
                        throw new ArgumentException("Ошибка. Поле 'Телефон' должно иметь следующий вид +375(29)111-11-11");
                    foreach(var phone in db.DepartmentPhone.ToList())
                    {
                        if (phone.DepartmentId == Id && phone.Phone == PhoneTextBox.Text && Id == -1)
                            throw new ArgumentException("Ошибка. Данный телефон уже существует");
                        else
                        if(phone.DepartmentId != Id && phone.Phone == PhoneTextBox.Text)
                        {
                            throw new ArgumentException("Ошибка. Данный телефон уже существует");
                        }
                    }

                    if (Id == -1)
                    {
                        if(db.DepartmentPhone.Where(x => x.DepartmentId == Id && x.Phone == PhoneTextBox.Text).Count() > 0)
                        {
                            throw new ArgumentException("Ошибка. Такой номер телефона уже есть");
                        }
                        else
                        if (db.DepartmentPhone.Where(x => x.DepartmentId == Id && x.Phone == PhoneTextBox.Text).Count() > 1)
                        {
                            throw new ArgumentException("Ошибка. Такой номер телефона уже есть");
                        }
                    }

                    if (Id == -1)
                    {

                        db.DepartmentPhone.Add(new Model.DepartmentPhone()
                        {
                            Phone = PhoneTextBox.Text,
                            DepartmentId = DepartmentID
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var phoneItem = db.DepartmentPhone.Find(Id);
                        phoneItem.Phone = PhoneTextBox.Text;
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
