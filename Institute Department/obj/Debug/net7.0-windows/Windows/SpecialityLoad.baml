   M S B A M L   `   `   `  ����O  KInstitute Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Institute_Department.WindowsInstitute_Department.Windows  5   	   Q-clr-namespace:Institute_Department.ConvertersInstitute_Department.Converters  5   	   1    +Institute_Department.Windows.SpecialityLoad   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Institute_Department.Windows     5   	   D
converters-clr-namespace:Institute_Department.Converters     5   	     � Title$  SpecialityLoad��5	   	   $	��220��6    $	��800��6-    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5      6  0Institute_Department.Converters.SubjectConverter   SubjectConverter3  -Institute_Department.Converters.TermConverter  TermConverter��%:   &	        &	        5   
   6&     5   
   6#   5      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�6.   .+�5      �� $��10,0,0,0q�6   .��6&   Семестр6/   �� 5      -   5         ��Name$ TermComboBox��5       �� DisplayMemberPath$
 Part��6Z   $	��100��6s   $��20��6   $��
10,0,0,145q�6�   5      5      � 5   
   $��0,30,0,0q�6   $	��150��6!   $	��Top=�6.   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��specialityDataGrid��5      $��10,10,20,20q�61      AutoGenerateColumns$ False��6F      CanUserAddRows$ False��6b      CanUserDeleteRows$ False��6y   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      
Visibility$ Hidden=�6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $
 Дисцплина��6)    6<   �� *	SubjectId+ �� 	Converter# [   �� Mode$ TwoWay=�  5      $
 Семестр��6)    6:   �� *TermId+# [ $ TwoWay=�  5      $(
 "Кол-во лек-ых часов��6)    6F   �� *LectureHours+  5      $(
 "Кол-во лаб-ых часов��6)    6F   �� *LaboratoryHours+  5      $*
 $Кол-во прак-их часов��6)    6G   �� *PracticalHours+5      5       5!      5"      