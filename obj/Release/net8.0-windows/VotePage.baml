   M S B A M L   `   `   `  ���� =  9ms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:msms  -clr-namespace:ms.Convertersms.Converters      ms.VotePage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     "localclr-namespace:ms     1	converterclr-namespace:ms.Converters       � 	Resources     
SearchHint j� TileMode j� Stretch j� 
AlignmentX �� 	Transform T� X T� Y !� Visual J� Opacity,   &ms.Converters.StringToBooleanConverter  StringToBooleanConverter)   #ms.Converters.VoteTypeNameConverter  VoteTypeNameConverter  
GuestPanel	 � ColumnDefinitions
 � RowDefinitions �� Orientation d� 	IsChecked �� 	Converter �� ConverterParameter �� TextWrapping �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�  &	        &	 �     &	 �     &	 �     7  7  7  7   !� $
 None=�$
 None=�$
 Left=� T� $ 5Q�$ 0Q� � .+��� $��18(�
���   �$	 0.3Q�$��Type your comment here...��    � $��Bottom=�$��4q�	 �� $��1* ��� $��2* ��� $��70 �
 �� �� �� .+��� $��Option: ��$��0��$��0��$��18(��� $��1��$��0��$��18(�$
��Left=����� *+)SelectedPollOptionWrapper.Option.DateSlot+�� $��1��$��0��$��18(�$��Right=����� *+)SelectedPollOptionWrapper.Option.TimeSlot+�� $ 
Horizontal=�$��2��$��0��.+�	� $��18(�$��Center=�$��10,0,0,0q� �� *DataContext.SelectedRadio+8   $	 yes��.��Yes	� $��18(�$��Center=�$��10,0,0,0q� �� *DataContext.SelectedRadio+8  $ maybe��.��Maybe	� $��18(�$��Center=�$��10,0,0,0q� �� *DataContext.SelectedRadio+8  $ no��.��No�� $��18(�$��1��$��3��$��7q�$ WrapWithOverflow=����� *	Comment+.������ " �� P�  � ��$  ��. ���  � ��8  .���� $��50��$��2��$��0��$��3��$��15(�$
��Left=�$��Center=����� *AddVoteCommand+.���� $
��Wrap=�
Add Vote.��]� .+�� $	��Top=� 
 Header#��[ .+��� $ 
Horizontal=�.+�� $	��780��.+��� $��50��$	��Top=�$��Stretch=��� $��30(�$��Center=�  
HeaderText#��[ ���� *SelectedDetail.EventName+ �� UpdateSourceTrigger$ PropertyChanged=��� $
��Back��$
��Left=�$��40��$��Center=�$��	700,0,0,0q�  HeaderButtons#��[ ���� *BackCommand+�� -   $��Leave��$��Leave��$
��Left=�$��40��$��Center=�$��	600,0,0,0q�#��[ ���� *LeaveCommand+�� ���#6159d9$��1q�$��Stretch=��� -   $��Scroll��$��Disabled=�$
��Auto=�$
��auto��$	��Top=�.���� $ 
Horizontal=�$��1��.+�� $	��780��	 �� $	��30* ��� $	��29* �
 �� $	��100 ��� .+��� $��/Icons/location-icon.png��$��25��$��25��$��0��$��0��$
��Left=�$	��Top=��� $��30,0,5,0q�$��20(�$��0��$��0��$	��Top=����� *SelectedDetail.Location+$ PropertyChanged=��� $��5,0,0,30q�$��/Icons/details-icon.png��$��25��$��25��$��1��$��0��$
��Left=�$	��Top=��� $
��Auto=�$��0��$��1��$��2��$��
35,0,30,30q�.���� $��WrapWithOverflow=�$��17(����� *SelectedDetail.Detail+� $��0��$	��Top=�$��
0,32,383,0q�$��2��	 �� �� .+��� $��Open Till: ��$��20(�$��0��$��Bottom=�$��0,0,26,0q��� $��5,0,5,0q�$��20(�$��Bottom=�$
��Left=�$��1������ *SelectedDetail.TillDate+ �� StringFormat$ {0:yyyy-MM-dd}��� $��0��$��0��$	��Top=�$��
0,65,383,0q�$��2��.+��� $��Final Date: ��$��20(�$��0��$��Bottom=�$��0,0,26,0q��� $��5,0,5,0q�$��20(�$��Bottom=�$��Center=�$��1������ *FinalOption.DateSlot+�� $��5,0,5,0q�$��20(�$��Bottom=�$��Right=�$��1������ *FinalOption.TimeSlot+�� -    ��Name$ OptionsForVote��$��Disabled=�$	��770��$��2��$��1������ *PollOptionsWithVotes+ �� SelectedItem �� *SelectedPollOptionWrapper+���� .R��� $��1q�
�������$��0,10,0,0q�._�� 	 �� $	��200 ��� $	��555 �
 �� $��60 ��� .+��� $��20(�$��0��$��0��$
��Left=����� *Option.DateSlot+�� $��20(�$��0��$��0��$��Center=�$��100, 0, 0, 0q����� *Option.TimeSlot+�� $ 
Horizontal=�$��1��.+��� $��18(����� *PositiveVoteCount+�� $��18(�$��5,0,0,0q�Yes�� $��18(�$��10,0,0,0q����� *NeutralVoteCount+�� $��18(�$��5,0,0,0q�Maybe�� $��18(�$��10,0,0,0q����� *NegativeVoteCount+�� $��18(�$��5,0,0,0q�No�� $	��555��$
��Auto=�$��Disabled=�$��1��$��2��$��0��.����  J� IsHitTestVisible$ False��$
��Auto������ *Votes+���� .R��� $ 
Horizontal=����� .R��� ���#6159d9$��1q�$��5q�._�� $	��200��
 �� �� �� �� .+��� $��20(�$��Center=���`� $ {0} {1}��.1���  �� Path$ User.firstName��� $ User.lastName��� $��15(�$��1��$��Center=����� *User.username+�� $��18(�$��2��$��Center=����� *Vote.VoteType+# [ �� $��18(�$��WrapWithOverflow=�$��3������ *Vote.Comment+�� -    ��Name$ Guest��