   M S B A M L   `   `   `  ����O  KInstitute Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Institute_Department.WindowsInstitute_Department.Windows  5   	   5    /Institute_Department.Windows.SubjectInformation   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Institute_Department.Windows     5   	     � Title$   ��5   	   $	��300��6   $	��375��6    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� .��6   Специальность6'   �� 5      -   5         ��Name$ SpecialityComboBox��5       �� DisplayMemberPath$
 Name��67   $	��200��6P   $��55,0,0,0q�6\   5      5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� .��6   Дисциплина6$   �� 5      -   5        $ SubjectComboBox��5      $
 Name��64   $	��200��6M   $��71,0,0,0q�6Y   5      5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5      �� .��6   Семестр6!   �� 5      -   5        $ TermComboBox��5      $
 Part��61   $	��200��6J   $��93,0,0,0q�6V   5      5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Часы на лекции6(   �� 5      -   5         ��Name$ LectureTextBox��5      $��52, 0, -252, 0q�62   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5       �� .��6   (&Часы на лабораторные6.   �� 5!      -   5        $ LaboratoryTextBox��5!      $��11, 0, -211, 0q�65   5"      �� 5#      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5$      �� .��6    Часы на практику6*   �� 5%      -   5        $ PracticalTextBox��5%      $��41, 0, -241, 0q�64   5&      �� 5'      -   5         ��Name$ 
SaveButton��5'       
  Button#��[  6)   $��0,10,0,0q�6I   $��Сохранить��6[   6o   5(      5)      5*      