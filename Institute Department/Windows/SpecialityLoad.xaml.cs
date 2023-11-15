using Institute_Department.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for SpecialityLoad.xaml
    /// </summary>
    public partial class SpecialityLoad : Window
    {
        private int Id { get; }
        public SpecialityLoad(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;
            using (DataContext db = new DataContext())
            {
                TermComboBox.ItemsSource = db.Term.ToList();

                var items = db.SubjectInformation.Where(x => x.SpecialityId == Id).ToList();
                specialityDataGrid.ItemsSource = items.Where( x => x.TermId == db.Term.First().Id).ToList();
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int termId = (TermComboBox.SelectedItem as Model.Term).Id;
            using (DataContext db = new DataContext()) 
            {
                var items = db.SubjectInformation.Where(x => x.SpecialityId == Id).ToList();
                specialityDataGrid.ItemsSource = items.Where(x => x.TermId == termId).ToList();
                specialityDataGrid.Items.Refresh();
            }

        }
    }
}
