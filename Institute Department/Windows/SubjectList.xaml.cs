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
    /// Interaction logic for SubjectList.xaml
    /// </summary>
    public partial class SubjectList : Window
    {
        private int Id { get; }
        private int Check { get; }
        public SubjectList(int Id = -1, int Check = -1)
        {
            InitializeComponent();
            this.Id = Id;
            this.Check = Check;
            if (Check == 0)
            {
                using (DataContext db = new DataContext())
                {
                    var items = db.SubjectInformation.Where(x => x.SpecialityId == Id).ToList();
                    subjectListDataGrid.ItemsSource = items;
                }
            }
            else
            if(Check == 1)
            {
                using (DataContext db = new DataContext())
                {
                    var specialityList = db.Speciality.Where(x => x.DepartmentId == Id).ToList();
                    List<Model.SubjectInformation> subjectList = new List<Model.SubjectInformation>();
                    foreach(var speciality in specialityList)
                    {
                        foreach(var item in db.SubjectInformation.Where(x => x.SpecialityId == speciality.Id).ToList())
                        {
                            subjectList.Add(item);
                        }
                    }

                    subjectListDataGrid.ItemsSource = subjectList;
                }
            }
        }
    }
}
