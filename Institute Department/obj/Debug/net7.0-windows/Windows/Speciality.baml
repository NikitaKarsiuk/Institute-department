   M S B A M L   `   `   `  ����O  KInstitute Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Institute_Department.WindowsInstitute_Department.Windows  5   	   -    'Institute_Department.Windows.Speciality   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Institute_Department.Windows     5   	     � Title$   ��5   	   $	��265��6   $	��340��6    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Код6   �� 5      -   5         ��Name$ CodeTextBox��5      $��82, 0, -282, 0q�6/   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Навазние6"   �� 5      -   5        $ NameTextBox��5      $��50, 0, -250, 0q�6/   5      �� 5   
   $ 
Horizontal=�6   $��0, 10, 0, 0q�6.   .+�5      �� .��6   Квалификация6"   �� 5      -   5        $ QualificationeTextBox��5      $��23, 0, -223, 0q�65   5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� .��6   Кафедра6!   �� 5      -   5         ��Name$ DepartmentComboBox��5       �� DisplayMemberPath$
 Name��67   $	��200��6P   $��56,0,0,0q�6\   5      5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� .��6   Форма обучения6(   �� 5      -   5        $ FormOfStudyComboBox��5      $
 Name��68   $	��200��6Q   $��10,0,0,0q�6]   5       5!      �� 5"      -   5         ��Name$ 
SaveButton��5"       
  Button#��[  6)   $��Сохранить��6I   $��0,10,0,0q�6^   6p   5#      5$      5%      