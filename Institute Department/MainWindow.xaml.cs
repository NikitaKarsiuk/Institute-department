using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Data;
using System.Windows.Media;
using System.Collections;
using System.Reflection;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Institute_Department.Model;
using Institute_Department.Windows;

namespace Institute_Department  
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DirectoryTabItemFill("SpecialityTabItem");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext())
            {
                if (db.TypeOfReport.Count() == 0)
                {
                    db.TypeOfReport.AddRange(new List<TypeOfReport>()
                    {
                        new TypeOfReport()
                        {
                            Name = "Зачет"
                        },
                        new TypeOfReport()
                        {
                            Name = "Экзамен"
                        },
                        new TypeOfReport()
                        {
                            Name = "Курсовая работа"
                        }
                    });
                }

                if (db.Term.Count() == 0)
                {
                    db.Term.AddRange(new List<Term>()
                    {
                        new Term()
                        {
                            Part = 1
                        },
                        new Term()
                        {
                            Part = 2
                        }
                    });
                }

                if (db.FormOfStudy.Count() == 0)
                {
                    db.FormOfStudy.AddRange(new List<FormOfStudy>()
                    {
                        new FormOfStudy()
                        {
                            Name = "Очное обучение"
                        },
                        new FormOfStudy()
                        {
                            Name = "Заочное обучение"
                        },
                        new FormOfStudy()
                        {
                            Name = "Очно-заочное обучение"
                        }
                    });
                }


                db.SaveChanges();
            }
        }

        /*Events for TabItems*/
        private void FillTabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var nameTabItem = (sender as TabItem).Name.ToString();;
                DirectoryTabItemFill(nameTabItem);
        }

        /*Fill dataGrid*/
        private void DirectoryTabItemFill(string tabItemName)
        {
            using (DataContext db = new DataContext())
            {
                if (tabItemName == "FacultyTabItem")
                {
                    var items = db.Faculty.ToList();
                    facultyDataGrid.ItemsSource = items;
                    facultyDataGrid.Items.Refresh();
                }
                if (tabItemName == "DepartmentInformationTabItem")
                {
                    var items = db.Department.ToList();
                    departmentInformationDataGrid.ItemsSource = items;
                    departmentInformationDataGrid.Items.Refresh();
                }
                if (tabItemName == "DepartmentTabItem")
                {
                    var items = db.Department.ToList();
                    departmentInformationDataGrid.ItemsSource = items;
                    departmentInformationDataGrid.Items.Refresh();
                }
                if (tabItemName == "SpecialityTabItem")
                {
                    var items = db.Speciality.ToList();
                    specialityDataGrid.ItemsSource = items;
                    specialityDataGrid.Items.Refresh();
                }
                if (tabItemName == "SpecialityInformationTabItem")
                {
                    var items = db.Speciality.ToList();
                    specialityDataGrid.ItemsSource = items;
                    specialityDataGrid.Items.Refresh();
                }
                if(tabItemName == "SubjectTabItem")
                {
                    var items = db.SubjectInformation.ToList();
                    subjectInformationDataGrid.ItemsSource = items;
                    subjectInformationDataGrid.Items.Refresh();
                }
                if (tabItemName == "SubjectInformationTabItem")
                {
                    var items = db.SubjectInformation.ToList();
                    subjectInformationDataGrid.ItemsSource = items;
                    subjectInformationDataGrid.Items.Refresh();
                }
                if (tabItemName == "SubjectListTabItem")
                {
                    var items = db.Subject.ToList();
                    subjectDataGrid.ItemsSource = items;
                    subjectDataGrid.Items.Refresh();
                }
             
            }
        }

        /*Add,Delete,Change buttons*/
        private void FacultyAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Faculty faculty = new Windows.Faculty();
            faculty.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("FacultyTabItem");
            });
            faculty.Show();
        }

        private void FacultyDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Model.Faculty>;
                var item = facultyDataGrid.SelectedItem as Model.Faculty;

                using (DataContext db = new DataContext())
                {
                    if (db.Department.Where(x => x.FacultyId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранный вами факультет, удалить нельзя");

                    var faculty = db.Faculty.Find(item.Id);

                    db.Faculty.Remove(faculty);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryTabItemFill("FacultyTabItem");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FacultyChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Model.Faculty>;
                var item = facultyDataGrid.SelectedItem as Model.Faculty;

                Windows.Faculty faculty = new Windows.Faculty(item.Id);
                faculty.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("FacultyTabItem");
                });
                faculty.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DepartmentAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Department department = new Windows.Department();
            department.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("DepartmentInformationTabItem");
            });
            department.Show();
        }

        private void DepartmentDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (departmentInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = departmentInformationDataGrid.ItemsSource as List<Model.Department>;
                var item = departmentInformationDataGrid.SelectedItem as Model.Department;

                using (DataContext db = new DataContext())
                {
                    if (db.Speciality.Where(x => x.DepartmentId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами кафедру, удалить нельзя");

                    var department = db.Department.Find(item.Id);

                    db.Department.Remove(department);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryTabItemFill("DepartmentInformationTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DepartmentChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (departmentInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = departmentInformationDataGrid.ItemsSource as List<Model.Department>;
                var item = departmentInformationDataGrid.SelectedItem as Model.Department;

                Windows.Department department = new Windows.Department(item.Id);
                department.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("DepartmentInformationTabItem");
                });
                department.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SpecialityAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Speciality department = new Windows.Speciality();
            department.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("SpecialityInformationTabItem");
            });
            department.Show();
        }

        private void SpecialityDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialityDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = specialityDataGrid.ItemsSource as List<Model.Speciality>;
                var item = specialityDataGrid.SelectedItem as Model.Speciality;

                using (DataContext db = new DataContext())
                {
                    if (db.SubjectInformation.Where(x => x.SpecialityId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами специальность, удалить нельзя");

                    var speciality = db.Speciality.Find(item.Id);

                    db.Speciality.Remove(speciality);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryTabItemFill("SpecialityInformationTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SpecialityChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialityDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = specialityDataGrid.ItemsSource as List<Model.Speciality>;
                var item = specialityDataGrid.SelectedItem as Model.Speciality;

                Windows.Speciality speciality = new Windows.Speciality(item.Id);
                speciality.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SpecialityInformationTabItem");
                });
                speciality.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Subject department = new Windows.Subject();
            department.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("SubjectListTabItem");
            });
            department.Show();
        }

        private void SubjectDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectDataGrid.ItemsSource as List<Model.Subject>;
                var item = subjectDataGrid.SelectedItem as Model.Subject;

                using (DataContext db = new DataContext())
                {
                    if (db.SubjectTypeOfReport.Where(x => x.Id == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вам дисциплину, удалить нельзя");
                    if (db.SubjectInformation.Where(x => x.SubjectId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вам дисциплину, удалить нельзя");

                    var subject = db.Subject.Find(item.Id);

                    db.Subject.Remove(subject);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryTabItemFill("SubjectList");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectDataGrid.ItemsSource as List<Model.Subject>;
                var item = subjectDataGrid.SelectedItem as Model.Subject;

                Windows.Subject subject = new Windows.Subject(item.Id);
                subject.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SubjectList");
                });
                subject.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SubjectInformationAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.SubjectInformation subject = new Windows.SubjectInformation();
            subject.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("SubjectInformationTabItem");
            });
            subject.Show();
        }

        private void SubjectInformationDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectInformationDataGrid.ItemsSource as List<Model.SubjectInformation>;
                var item = subjectInformationDataGrid.SelectedItem as Model.SubjectInformation;

                using (DataContext db = new DataContext())
                {
                    var subjectInformation = db.SubjectInformation.Find(item.Id);

                    db.SubjectInformation.Remove(subjectInformation);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryTabItemFill("SubjectInformationTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectInformationChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectInformationDataGrid.ItemsSource as List<Model.SubjectInformation>;
                var item = subjectInformationDataGrid.SelectedItem as Model.SubjectInformation;

                Windows.SubjectInformation subjectInformation = new Windows.SubjectInformation(item.Id);
                subjectInformation.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SubjectInformationTabItem");
                });
                subjectInformation.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*button windows*/

        private void OpenDepartmentPhoneListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (departmentInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = departmentInformationDataGrid.ItemsSource as List<Model.Department>;
                var item = departmentInformationDataGrid.SelectedItem as Model.Department;

                DepartmentPhoneList window = new DepartmentPhoneList(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("DepartmentInformationTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenTypeOfReportListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectInformationDataGrid.ItemsSource as List<Model.SubjectInformation>;
                var item = subjectInformationDataGrid.SelectedItem as Model.SubjectInformation;

                SubjectTypeOfReportList window = new SubjectTypeOfReportList(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SubjectInformationTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenSubjectListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialityDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = specialityDataGrid.ItemsSource as List<Model.Speciality>;
                var item = specialityDataGrid.SelectedItem as Model.Speciality;

                SubjectList window = new SubjectList(item.Id,0);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SpecialityInformationTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenFacultySubjectListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Model.Faculty>;
                var item = facultyDataGrid.SelectedItem as Model.Faculty;

                SubjectList window = new SubjectList(item.Id, 1);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("FacultyTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenFacultyExamsWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (departmentInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = departmentInformationDataGrid.ItemsSource as List<Model.Department>;
                var item = departmentInformationDataGrid.SelectedItem as Model.Department;

                DepartmentExams window = new DepartmentExams(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("DepartmentTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OpenSpecialityHoursListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialityDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = specialityDataGrid.ItemsSource as List<Model.Speciality>;
                var item = specialityDataGrid.SelectedItem as Model.Speciality;

                SpecialityHoursList window = new SpecialityHoursList(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SpecialityInformationTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenSpecialityLoadWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialityDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = specialityDataGrid.ItemsSource as List<Model.Speciality>;
                var item = specialityDataGrid.SelectedItem as Model.Speciality;

                SpecialityLoad window = new SpecialityLoad(item.Id);
                window.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryTabItemFill("SpecialityInformationTabItem");
                });
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectInformationMinMaxButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectInformationMinMax window = new SubjectInformationMinMax();
            window.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryTabItemFill("subjectInformationDataGrid");
            });
            window.Show();
        }
    }
}
