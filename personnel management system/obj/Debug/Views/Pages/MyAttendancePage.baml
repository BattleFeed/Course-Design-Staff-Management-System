   M S B A M L   `   `   `  ����  PersonnelManagementSystem<    6PersonnelManagementSystem.Views.Pages.MyAttendancePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  MyAttendancePage��5       N� 
Background �#EEE N� FontSize$ 20(�62   .��5	      �� -   5         ��Name$ 	DataPanel��5	      $��	10 10 0 0q�6$   .+�5
   
   �� $	��900��6   $	��550��6$   
�������.��5      &   System.Windows.Controls.DataGrid  -   5          Name$
 Grid��5         GridLinesVisibility$
 None=�6%      AutoGenerateColumns .     
IsReadOnly . ��5      �� *Table+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 员工编号��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   ��  �� Path$ StaffNo�  5      $	 日期��6)   
 65   �� $
 Date�  5      $	 上班时间��6)   
 67   �� $ CheckInTime�  5      $	 下班时间��6)   
 67   �� $ 	LeaveTime�  5      $	 情况��6)   
 65   �� $ Status�5      5      5      5      