   M S B A M L   `   `   `  ����  PersonnelManagementSystem6    0PersonnelManagementSystem.Views.Pages.AssessPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5        N� Title$  
AssessPage��5	       N� 
Background �#EEE N� FontSize$ 20(�6,    � 	Resources 5
       �� 
TargetType   ScrollViewerStyle �� BasedOn  ScrollBarStyle  TextBoxStyle��%�   '��       7   '�� "     7  '�� D     7  �� 5   
   " ��6   8   6*   �� 5   
   " ��6   8   6'   �� 5   
   " ��6   8   6%   5      .��5      �� -   5         ��Name$ 	DataPanel��5      $��	10 10 0 0q�6$   .+�5   
   �� $	��900��6   $	��550��6$   
�������.��5      &   System.Windows.Controls.DataGrid  -   5          Name$
 Grid��5         GridLinesVisibility$
 None=�6%   	   AutoGenerateColumns	 .  ��5      �� *Table+
 �� Mode$
 TwoWay=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ CellEditEnding��6%   /  )Microsoft.Xaml.Behaviors.EventTriggerBase   
SourceName$
 Grid��6@   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction     
MethodName$ OnEditEnding��6-      TargetObject 6G   �� 5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 删除��6-      SortMemberPath$ toDelete��69      CellTemplate 5      �� 5      .R�5   "   �� $��Center=�5   /   $��Center=�6J    d� 	IsChecked 5   +   ��  �� Path$ ToDelete� �� UpdateSourceTrigger$ PropertyChanged=�5   J   5      5       0	  *System.Windows.Controls.DataGridTextColumn	  5!      $ 员工编号��6)   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 67   �� $ StaffNo�	  5"      $ 姓名��6)      
IsReadOnly .  65   �� $ 	StaffName�6X   	  5#      $ 日期��6)    65   �� $
 Date�	  5$      $ 评分��6)    65   �� $ Score�5&      5'      �� 5(   
   $��
100 10 0 0q�6    �� Orientation$ 
Horizontal=�6)   $��30��6B   .+�5)      �� $��提交��6   $��50��6D   ��6"   �� *SubmitCommand+6D   �� 5*      -   5        $ QueryButtonArea��5*      $ 
Horizontal=�62   $��	500 0 0 0q�6K   $��Center=�5+      $��Center=�66   .+�5,      �� $	��200��6   ��6&   �� *SearchField+�� 5-      $��搜索��6   ��6&   �� *SelectCommand+5.      5/      50      51      