   M S B A M L   `   `   `  ����O  KTimePickerControlApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:TimePickerControlApp.CustomControl"TimePickerControlApp.CustomControl  5      O,clr-namespace:TimePickerControlApp.ViewModelTimePickerControlApp.ViewModel  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      4    .TimePickerControlApp.CustomControl.TimeControl   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:TimePickerControlApp.CustomControl     5      ;vm,clr-namespace:TimePickerControlApp.ViewModel     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5
         MyClockImage  TimePickerImage  MyCrossImage  
CrossImage  MyCheckMarkImage  CheckMarkImage  RoundButton j� Stretch �� ImageSource  ListViewItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value��%X  &	        7  &	      7  &	 0     7  &	 H     7  &	 �     �� 5   
   8��  6%   �� 5   
   8��  6%   �� 5   
   8��  6)   �� 5   
   .R�5      A� $��25��6   $��25��6"   ��5      �� 5      $ UniformToFill=�6!   8   69   5      5      �� 5   
   " ��6*   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   $ 2q�5   !   $
 true��5   !   $��30��6<   ._�5      �� 5      	 5      P� 5      
 �@��
IsSelected$
 true��6<   . �5    "   �� $ _Border��6)    � ��
 ��ح�6T   �� 5!   "    � ��$ 20(�6=   �� 5"   "    � ��$ DemiBold"�6?   �� 5#   "    � ��
 ��  �6?   �� 5$   "    � ��$ 8q�6<   �� 5%   "    � ��$ Center=�6M   �� 5&   "    � ��$ Center=�6O   5'      P� 5(      
 �@��
IsSelected$ False��6<   . �5)   "   �� $ _Border��6)    � ��
 ���� 6T   �� 5*   "    � ��$ 18(�6=   �� 5+   "    � ��$ 8q�6<   �� 5,   "    � ��$ Center=�6M   �� 5-   "    � ��$ Center=�6O   5.      P� 5/      
 � {�$ False��6;   . �50   "   �� $ _Border��6)    � ��
 ���� 6T   �� 51   "    � ��$ 18(�6=   �� 52   "    � ��$ 8q�6<   �� 53   "    � ��$ Center=�6M   �� 54   "    � ��$ Center=�6O   �� 55   "    � ��
 �����6?   56      ]� 57       58   "   �� 59   &    � {�$ False��6E   6U   �� 5:   &    �@��
IsSelected$
 True��6F   6U   /�5<   "   �� 5=   &    � ��$ Normal"�6C   6T   5?      5A      5C      5D      5E      .��5F      � 
������  � DataContext 5G   
   9   3TimePickerControlApp.ViewModel.TimeControlViewModel  5H      .+�5J   
   �� $��0��6   $��0��6   $��2,2,2,2q�6.   
���   �$ 0q�6\   $��0q�6h   ._�5K      �  � ColumnDefinitions 5L      �� 5M      $	��90* �6'   �� 5N      $	��20* �6'   .+�5Q      :  4System.Windows.Controls.Primitives.DatePickerTextBox  -   5          Name$ txtDatePicker��5Q   $   $��16(�5R   $   $��Stretch=�62   $��Center=�5S   $   ��5Q   ;   �� *
TimeText+ �� Mode$ TwoWay=� �� StringFormat$   ��5S   F   �� 5T      $��1��6   $��0q�6)   
������ #��[  6W   #��[ 6   ��6�   �� *TimePickCommand+5U      5V      � 5W   
   $��Bottom=�6<   $��
10,10,0,13q�6O   $
��Left=�6c   $	��Top=�6~   $	��194��6�   $	��196��6�   ��6   �� *IsPopupOpen+$ TwoWay=�.��5X      �� $��0��6   $��0��6"   $��2,0,2,2q�62   
���   �$ 0q�6`   $��0q�6l   ._�5Y      � 
������� � RowDefinitions 5Z      �� 5[      $��* �6(   �� 5\      $��* �6(   �� 5]      $��* �6(   �� 5^      $��* �6(   �� 5_      $��* �6(   �� 5`      $��40 �6(    5b      �� 5c      $	��20* �6+   �� 5d      $	��20* �6+   �� 5e      $	��20* �6+   .+�5g      �� -   5        $��lstHour��5i   |   #���  5g   J   $��0��5h      $��5��6,   $��0��6=   $��Hidden=�6M   $��0,0,1,1q�6   ��5g      �� *Hours+$ TwoWay=� �� SelectedValue 5i      �� *SelectedHour+$ TwoWay=�6|   �� 5k      -   5        $��lstMin��5m   {   #���  5k   L   $��0��5l      $��5��6,   $��1��6=   $��Hidden=�6M   $��1,0,2,1q�6   ��5k      �� *	Minutes+$ TwoWay=� 5m      �� *SelectedMin+$ TwoWay=�6{   �� 5o      #���  6n   $��2��5p      $��3��6,   $��2��6=   $��Hidden=�6M   $��0,0,0,1q�6   $��0,-2,0,0q�6�   ��5o      �� *AMPM+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5q      �� *SelectedAMPM+$ TwoWay=� �� SelectedIndex 6S   �� *SelectedIndexAMPM+$ TwoWay=�{�6�   �� *Is12HourClock+$ TwoWay=�� 5s      $��5��6   $��0��6(   $��3��68    5t      �� 5u      $��* �6/   �� 5v      $��* �6/   .+�5x      �� #��[ 6!   $��0,1,1,0q�6M   $��0��6g   ��6w   �� *DoneCommand+�� 5y      #��[ 6!   $��1,1,0,0q�6J   $��1��6d   ��6u   �� *CloseCommand+5z      5{      5|      5}      5~      5      