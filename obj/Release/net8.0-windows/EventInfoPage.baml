   M S B A M L   `   `   `  ���� =  9ms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:msms      ms.EventInfoPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     "localclr-namespace:ms       � 	Resources   �� Orientation   
OwnerPanel  
HeaderText �� UpdateSourceTrigger  HeaderButtons �� Mode  
GuestPanel��%�  &	        7  7  7  7  7  &	 a    7  7  �� $ 
Horizontal=�.+�� $	��780��.+��� $��50��$	��Top=�$��Stretch=��� $��30(�$��Center=�8��  ���� *SelectedDetail.EventName+$ PropertyChanged=��� $
��Back��$
��Left=�$��40��$��Center=�$��	700,0,0,0q�8�� ���� *BackCommand+�� $��Close��$
��Left=�$��40��$��Center=�$��	540,0,0,0q�8�� {��� *SelectedDetail.IsOpened+$ OneWay=����� *CloseCommand+�� $
��Edit��$
��Left=�$��40��$��Center=�$��	630,0,0,0q�8�� ���� *EditCommand+�� $��Delete��$
��Left=�$��40��$��Center=�$��	440,0,0,0q�8�� ���� *DeleteCommand+�� $ 
Horizontal=�.+�� $	��780��.+��� $��50��$	��Top=�$��Stretch=��� $��30(�$��Center=�8��  ���� *SelectedDetail.EventName+$ PropertyChanged=��� $
��Back��$��25(�$
��Left=�$��40��$��Center=�$��	700,0,0,0q�8�� ���� *BackCommand+.��]� .+�� $	��Top=� 
 Header#��[ .+��� -    ��Name$ Panel���� ���#6159d9$��1q�$��Stretch=��� $
��Auto=�.���� $ 
Horizontal=�$��1��.+�� $	��780�� � ColumnDefinitions �� $	��30* ��� $	��29* ���  � RowDefinitions �� $	��130 ��� �� �� $��40 �.+��� $��/Icons/location-icon.png��$��25��$��25��$��0��$��0��$
��Left=�$	��Top=��� $��30,0,5,0q�$��20(�$��0��$��0��$	��Top=����� *SelectedDetail.Location+$ PropertyChanged=��� $��5,0,0,30q�$��/Icons/details-icon.png��$��25��$��25��$��1��$��0��$
��Left=�$	��Top=��� $
��Auto=�$��0��$��1��$��2��$��	35,0,0,30q�.���� $��WrapWithOverflow=�$��17(����� *SelectedDetail.Detail+� $��0��$	��Top=�$��0,32,0,0q� �� �� .+��� $��Open Till: ��$��20(�$��0��$��Bottom=�$��0,0,26,0q��� $��5,0,5,0q�$��20(�$��Bottom=�$
��Left=�$��1������ *SelectedDetail.TillDate+ �� StringFormat$ {0:yyyy-MM-dd}��� $��0��$��0��$	��Top=�$��0,65,0,0q�.+��� $��Final Date: ��$��20(�$��0��$��Bottom=�$��0,0,26,0q��� $��5,0,5,0q�$��20(�$��Bottom=�$��Center=�$��1������ *FinalOption.DateSlot+�� $��5,0,5,0q�$��20(�$��Bottom=�$��Right=�$��1������ *FinalOption.TimeSlot+�� $��Poll Options��$��20(�$��Center=�$��0��$	��Top=�$��	0,103,0,0q��� $
��Auto=�$��1��$��2��$��Center=�.���� $
��auto������ *SelectedDetail.eOptions+���� .R��� $��1q�
�������._�� $��Center=�.+��� $��18(�$
��Left=����� *
DateSlot+�� $��18(�$��Right=�$��	200,0,0,0q����� *
TimeSlot+�� $��18(�$��Check votes��$��0��$��3��$��Bottom=�$��Center=�$��0,0,5,5q����� *CheckVotesCommand+�� $��Guests��$��20(�$
��Left=�$��1��$��0��$��Bottom=�$��	165,0,0,0q��� $	��286��$
��Auto=�$��1��$��1��$��2��$��Center=�$��0,5,0,5q�.���� -   $��Details��$
��auto��$��Center=����� *guestsDetails+���� .R��� $��1q�
�������._�� $��Center=� �� �� �� .+��� $��18(�$��Center=�$��0����`� $ {0} {1}��.1���  �� Path$ 	firstName��� $ lastName��� $��13(�$��1��$��Center=����� *
username+�� $��13(�$��2��$��Center=����� *email+