   M S B A M L   `   `   `  ���� =  9ms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:msms      ms.EventDetailPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     "localclr-namespace:ms     ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��]� .+�� $	��Top=� 
  Header#��[  .+���   �� Orientation$  
Horizontal=�.+�� $	��780��.+��� $��50��$	��Top=�$��Stretch=��� $��Event Settings��$��30(�$��Center=�  
HeaderText#��[ �� $
��Save��$
��Left=�$��40��$��Center=�$��	600,0,0,0q�  HeaderButtons#��[ ���� *SaveCommand+�� $��Cancel��$
��Left=�$��40��$��Center=�$��	680,0,0,0q�#��[ ���� *CancelCommand+�� ���#6159d9$��1q�$��Stretch=��� $
��Auto=�.���� $  
Horizontal=�$��1��.+�� $	��780�� � ColumnDefinitions �� $	��30* ��� $	��29* ���  � RowDefinitions �� $	��130 ��� �� �� $��75 �.+��� $��0,0,5,0q�$��20(�$��0��$��0��$	��Top=����� *SelectedDetail.EventName+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0,36,5,0q�$��20(�$��0��$��0��$	��Top=����� *SelectedDetail.Location+$ PropertyChanged=��� $��5,0,0,65q� �� TextWrapping$ WrapWithOverflow=�$��17(�$��0��$��1��$��2������ *SelectedDetail.Detail+$ PropertyChanged=�� $��0��$	��Top=�$��0,65,0,0q� �� �� �� .+��� $��Open Till: ��$��20(�$��0��$��Bottom=�$��0,0,26,0q�(  "System.Windows.Controls.DatePicker  $��	109,0,5,0q�$��20(�$��Center=�$��2��   SelectedDate �� *SelectedDetail.TillDate+$ PropertyChanged=�� $��0��$��1��$	��Top=�$��5,65,0,0q�.+��� $��Final Date: ��$��20(�$��0��$��Bottom=�$��	0,0,26,-5q��� $��5,0,5,0q�$��20(�$��Bottom=�$��Center=�$��1������ *FinalOption.DateSlot+�� $��5,0,5,0q�$��20(�$��Bottom=�$��Right=�$��1������ *FinalOption.TimeSlot+�� $��Poll Options��$��20(�$��Center=�$��0��$	��Top=�$��	0,103,0,0q��� $
��Auto=�$��1��$��2��$��Center=�.���� $
��auto������ *SelectedDetail.eOptions+ �� SelectedItem �� *SelectedOption+���� .R��� $��1q�
�������._�� $��Center=�.+��� $��18(�$
��Left=����� *
DateSlot+�� $��18(�$��Right=�$��	200,0,0,0q����� *
TimeSlot+�� $��16(�$��Delete Option��$��0��$��3��$	��Top=�$
��Left=�$��5,5,0,0q����� *DeleteOptionCommand+�� $��16(�$��Set Option Final��$��0��$��3��$	��Top=�$��Right=�$��0,5,5,5q����� *SetFinalOptionCommand+&   Xceed.Wpf.Toolkit.DateTimePicker  $��5,5,5,5q�$��18(�$��0��$��3��$��Bottom=�$
��Left=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value �� *NewPollOption+$ PropertyChanged=��� $��16(�$��
Add Option��$��0��$��3��$��Bottom=�$��Right=�$��0,0,5,2q����� *AddOptionCommand+�� $��Guests��$��20(�$
��Left=�$��1��$��0��$��Bottom=�$��	165,0,0,0q��� $	��286��$
��Auto=�$��1��$��1��$��2��$��Center=�$��0,5,0,5q�.���� $
��auto��$��Center=����� *SelectedDetail.Guests+ �� *SelectedGuest+���� .R��� $��1q�
�������._�� $��Center=�.+��� $��18(�$
��Left=����� *
Username+�� $��5,5,0,0q�$��18(�$��1��$��3��$	��Top=�$
��Left=�$	��105������ *NewUsername+$ PropertyChanged=��� $��16(�$��Add By Username��$��1��$��3��$	��Top=�$
��Left=�$��	122,5,0,0q����� *AddUsernameCommand+�� $��16(�$��Delete Guest��$��1��$��3��$	��Top=�$��Right=�$��0,5,5,0q�$��2������ *DeleteGuestCommand+�� -    ��Name$ 
errorGuest��$��5,28,0,0q�$��1��$��3��$	��Top=�$
��Left=�$	��372���� $��5,0,0,5q�$��18(�$��1��$��3��$��Bottom=�$
��Left=�$	��250������ *
NewEmail+$ PropertyChanged=��� $��16(�$��Add By Email��$��1��$��3��$��Bottom=�$��Right=�$��0,5,5,2q�$��2������ *AddEmailCommand+