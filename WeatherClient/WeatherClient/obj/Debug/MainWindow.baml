   M S B A M L   `   `   `  ����H  DWeatherClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WeatherClientWeatherClient  5   	       WeatherClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WeatherClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   ��5	      �� 5
   
   CustomWindowStyle�� �� 
TargetType" �6+   .�5      ��  �� Property � �� �� Value$ 20(�6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��70��6   $��5 0 0 0 q�6#   Город:5      �� 5      $	��200��6   $��20(�6o    �� SelectedItem 6&   �� *SelectedCity+��6L   �� *
CitiesList+6   (  "System.Windows.Controls.DatePicker  5       $��12(�6    J� RenderTransformOrigin$	 0,0&�6'      SelectedDate 6C   �� *SelectedDate+	 �� Mode$	 TwoWay=�
 � LayoutTransform
 5!      �� 5"       �� ScaleX$	 1.5Q�6%    �� ScaleY$	 1.5Q�62   5$      �� 5%      ��6   �� *LoadCommand+.��66   Загрузить6A   5&      �� 5'   
   $��1��6    � 	Resources 5(      ��%S   '��       �� 5)      " ��6   .�5*      ��  � ��$	 300��61   5+      5,      .+�5-      �� $ 
Horizontal=�6   .+�5.      �� Погода:6%   �� 5/      ��6   �� *Info.ConditionComment+6E   50      �� 51      $ 
Horizontal=�6   .+�52      �� 20Максимальная температура:67   �� 53      ��6   �� *Info.TemperatureMax+6C   54      �� 55      $ 
Horizontal=�6   .+�56      �� 0.Минимальная температура:66   �� 57      ��6   �� *Info.TemperatureMin+6C   58      �� 59      $ 
Horizontal=�6   .+�5:      �� &$Скорость ветра (м/с):63   �� 5;      ��6   �� *	Info.Wind+69   5<      �� 5=      $ 
Horizontal=�6   .+�5>      �� $"Уровень влажности:60   �� 5?      ��6   �� *Info.Rainfall+6=   5@      5B      5C      5D      