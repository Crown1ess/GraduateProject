   M S B A M L   `   `   `  ����D  @Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees  5   	       Employees.Main   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Employees     5   	     � Title$
  Main��5   	   $	��500��6   $	��440��6#    � WindowStartupLocation$ CenterScreen=�6/    � WindowStyle$
 None=�5	       � 
ResizeMode$ NoResize=�6     � DataContext 5      !   Employees.EmployeeViewModel  5   
   .��5      � .+�5   
   �� -   5        $
��exit��5   r   $��Bottom=�6      
ExitButton#��[  6,   $��403,0,7,466q�6]   .��5      ��   	ExitImage#��[ 6   5      �� 5   
   $��40��6   $��40��6   $	��Top=�6(   ��6@   ��  �� Source$ /images/user.jpg����6o   Z� 5      �� 5   
   -   5        $��lstEmployees��5      $��5q�6&   $��Center=�6S   $��Bottom=�5      $��0q�6-   ��5   1   �� *	Employees+��5      �� 5      .R�5      �� $��5q�6   $��1q�6(   
�����F� �� CornerRadius$ 4��6T   $	��400��6e   ._�5      � $��3q�6    � ColumnDefinitions 5      �� 5   "   $
��Auto �63   �� 5   "   .+�5!      ��  �� Orientation$ 
Horizontal=�6)   .+�5"   "   �� $��2��6(   $	��100��69   $��75��6E   $��6q�6Q   $/��)pack://application:,,,/images/Profile.png��5#   (   �� 5$   "   $ Vertical=�6-   .+�5%   &   �� $ 
Horizontal=�61   .+�5&   *   �� $��Medium"�60   ��6D   �� *
LastName+�� 5'   *   $
��Bold"�60   ��6B   �� *	FirstName+�� 5(   *   $��Medium"�60   ��6D   �� *
Patronymic+5)   '   �� 5*   &   $ 
Horizontal=�61   .+�5+   *   �� $��Phone Numer: (+7)��60   �� 5,   *   $��Center=�64   ��6O   �� *PhoneNumber+5-   '   �� 5.   &   $ 
Horizontal=�61   .+�5/   *   �� $��	Passport:��60   �� 50   *   $��Center=�64   ��6O   �� *PassportData+51   '   52   #   53      55      56      57      5:      5;      5=      