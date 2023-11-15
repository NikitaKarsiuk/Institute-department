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
    /// Interaction logic for SubjectTypeOfReportList.xaml
    /// </summary>
    public partial class SubjectTypeOfReportList : Window
    {
        private int Id { get; }
        public SubjectTypeOfReportList(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            using (DataContext db = new DataContext())
            {
                var items = db.SubjectTypeOfReport.Where(x => x.SubjectInformationId == Id).ToList();
                subjectTypeOfReportDataGrid.ItemsSource = items;
            }
        }

        private void SubjectTypeOfReportAddButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectTypeOfReport window = new SubjectTypeOfReport(Id);
            window.Closed += new EventHandler((_s, _e) =>
            {
                using (DataContext db = new DataContext())
                {
                    var items = db.SubjectTypeOfReport.Where(x => x.SubjectInformationId == Id).ToList();
                    subjectTypeOfReportDataGrid.ItemsSource = items;
                }
            });
            window.Show();
        }

        private void SubjectTypeOfReportDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectTypeOfReportDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectTypeOfReportDataGrid.ItemsSource as List<Model.SubjectTypeOfReport>;
                var item = subjectTypeOfReportDataGrid.SelectedItem as Model.SubjectTypeOfReport;

                using (DataContext db = new DataContext())
                {
                    var subject = db.SubjectTypeOfReport.Find(item.Id);

                    db.SubjectTypeOfReport.Remove(subject);
                    db.SaveChanges();
                }

                items.Remove(item);

                subjectTypeOfReportDataGrid.ItemsSource = items;
                subjectTypeOfReportDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectTypeOfReportChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectTypeOfReportDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectTypeOfReportDataGrid.ItemsSource as List<Model.SubjectTypeOfReport>;
                var item = subjectTypeOfReportDataGrid.SelectedItem as Model.SubjectTypeOfReport;

                SubjectTypeOfReport window = new SubjectTypeOfReport(Id, item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    using (DataContext db = new DataContext())
                    {
                        var subject = db.SubjectTypeOfReport.Where(x => x.SubjectInformationId == Id).ToList();
                        subjectTypeOfReportDataGrid.ItemsSource = subject;
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
