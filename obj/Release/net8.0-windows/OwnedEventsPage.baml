   M S B A M L   `   `   `  ���� =  9ms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:msms      ms.OwnedEventsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     "localclr-namespace:ms       � 	Resources     DefaultTemplate �� CornerRadius �� Padding � ColumnDefinitions � RowDefinitions �� StringFormat �� RelativeSource �� AncestorType �� Mode  CustomTemplate��%�  &	        &	 >    �� .R��� $��1q����#6159d9$ 8��$ 4,0,4,0q�$��0,0,0,10q�._�� $	��150�� �� $	��300 ��� $	��270 ��� $	��130 � �� �� �� .+��� $��18(�$��0��$��0��$
��Left=�$��Center=����� *	EventName+�� $��/Icons/details-icon.png��$��25��$��25��$��0��$��1��$
��Left=��� $
��Auto=�$��0��$��1��$��50��.���� $��15(�$
��Left=�$��Center=�$��30,0,0,0q�$��WrapWithOverflow=����� *Detail+�� $��/Icons/location-icon.png��$��25��$��25��$��0��$��2��$
��Left=�$	��Top=��� $��18(�$��0��$��2��$
��Left=�$	��Top=�$��30,0,0,0q����� *
Location+�� $��18(�$��Open Till: ��$��0��$��2��$
��Left=�$��Bottom=��� $��18(�$��0��$��2��$��Center=�$��Bottom=����� *
TillDate+$ {0:yyyy-MM-dd}���� $��18(�$��Poll Options��$��1��$��0��$��Center=��� $
��Auto=�$	��260��$��1��$��1��$��2��.���� $
��auto������ *
eOptions+���� .R��� $��1q�
�������._��  ��  �� .+��� $��18(�$
��Left=����� *
DateSlot+�� $��18(�$��Right=����� *
TimeSlot+�� $��18(�$��Details��$��2��$��Center=�$��
10,0,-29,0q�$��0������ *DataContext.DetailsCommand+ ��  ItemsControl���� �� $��18(�$��Delete��$��2��$��Center=�$��
10,0,-29,0q�$��1������ *DataContext.DeleteCommand+ ��  ItemsControl���� �� $��18(�$��Close��$��2��$��Center=�$��
10,0,-29,0q�$��2��{��� *
IsOpened+$ OneWay=����� *DataContext.CloseCommand+ ��  ItemsControl���� �� .R��� $��1q����#6159d9$ 8��$ 4,0,4,0q�$��0,0,0,10q�._�� $	��150�� �� $	��300 ��� $	��270 ��� $	��130 � �� �� �� .+��� $��18(�$��0��$��0��$
��Left=�$��Center=����� *	EventName+�� $��/Icons/details-icon.png��$��25��$��25��$��0��$��1��$
��Left=��� $
��Auto=�$��0��$��1��$��50��.���� $��15(�$
��Left=�$��Center=�$��30,0,0,0q�$��WrapWithOverflow=����� *Detail+�� $��/Icons/location-icon.png��$��25��$��25��$��0��$��2��$
��Left=�$	��Top=��� $��18(�$��0��$��2��$
��Left=�$	��Top=�$��30,0,0,0q����� *
Location+�� $��18(�$��Open Till: ��$��0��$��2��$
��Left=�$��Bottom=��� $��18(�$��0��$��2��$��Center=�$��Bottom=����� *
TillDate+$ {0:yyyy-MM-dd}���� $��18(�$��Poll Options��$��1��$��0��$��Center=��� $
��Auto=�$	��260��$��1��$��1��$��2��.���� $
��auto������ *
eOptions+���� .R��� $��1q�
�������._��  ��  �� .+��� $��18(�$
��Left=����� *
DateSlot+�� $��18(�$��Right=����� *
TimeSlot+�� $��18(�$��Details��$��2��$��Center=�$��
10,0,-29,0q�$��0������ *DataContext.DetailsCommand+ ��  ItemsControl���� �� $��18(�$
��Vote��$��2��$��Center=�$��
10,0,-29,0q�$��1������ *DataContext.VoteCommand+ ��  ItemsControl���� �� $��18(�$��Leave��$��2��$��Center=�$��
10,0,-29,0q�$��2��{��� *
IsOpened+$ OneWay=����� *DataContext.LeaveCommand+ ��  ItemsControl���� .��]� .+�� $	��Top=� 
 Header#��[ .+��� 	 �� Orientation$	 
Horizontal=�$��1��.+��� $��50��$��0,0,0,0q�._��� -   
 ��Name$
 dropdownMenu��$
��auto��$��40��$��20(�$
��Left=�$��Center=�$��0q�$��Center=�$��0,0,0,0q����#6159d9 �� 
IsEditable$
 True��$��5,0,5,0q�.@��� $��Owned Events��$��20(��� $��Guest Events��$��20(��� $��	New event��$��20(��� $��
My profile��$��20(��� $��Logout��$��20(��� -   $
 
sortingBox��$
��auto��$��40��$��20(�$
��Left=�$��Center=�$��0q�$��Center=�$��10,0,0,0q����#6159d9$
 True��$��5,0,5,0q�.@��� $	��All��$��20(��� $
��Open��$��20(��� $��Closed��$��20(��� ���#6159d9$��1q�$��Stretch=��� $
��Auto=�.���� $	 
Horizontal=�$��1��.+��� -    ��Name$ eList��$��Stretch=�$	��750��$��	10,10,0,0q����� *
EventsList+����  �� ResourceKey$ DefaultTemplate��