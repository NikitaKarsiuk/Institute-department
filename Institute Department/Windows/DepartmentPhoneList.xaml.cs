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
    /// Interaction logic for DepartmentPhoneList.xaml
    /// </summary>
    public partial class DepartmentPhoneList : Window
    {
        private int Id {    get ; set; }
        public DepartmentPhoneList(int Id = -1)
        {
            InitializeComponent();

            this.Id = Id;
            using (DataContext db = new DataContext())
            {
                var items = db.DepartmentPhone.Where(x => x.DepartmentId == Id).ToList();
                phoneDataGrid.ItemsSource = items;
            }
        }

        private void LessonAddButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPhone window = new DepartmentPhone(Id);
            window.Closed += new EventHandler((_s, _e) =>
            {
                using (DataContext db = new DataContext())
                {
                    var items = db.DepartmentPhone.Where(x => x.DepartmentId == Id).ToList();
                    phoneDataGrid.ItemsSource = items;
                }
            });
            window.Show();
        }

        private void LessonDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (phoneDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = phoneDataGrid.ItemsSource as List<Model.DepartmentPhone>;
                var item = phoneDataGrid.SelectedItem as Model.DepartmentPhone;

                using (DataContext db = new DataContext())
                {
                    var phone = db.DepartmentPhone.Find(item.Id);
               
                    db.DepartmentPhone.Remove(phone);
                    db.SaveChanges();
                }

                items.Remove(item);

                phoneDataGrid.ItemsSource = items;
                phoneDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LessonChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (phoneDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = phoneDataGrid.ItemsSource as List<Model.DepartmentPhone>;
                var item = phoneDataGrid.SelectedItem as Model.DepartmentPhone;

                DepartmentPhone window = new DepartmentPhone(Id, item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    using (DataContext db = new DataContext())
                    {
                        var phone = db.DepartmentPhone.Where(x => x.DepartmentId == Id).ToList();
                        phoneDataGrid.ItemsSource = phone;
                    }
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
