   M S B A M L   `   `   `  ����>  :STC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DesignInControlDesignInControl  5   	       StcTimer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9DesignInControlclr-namespace:DesignInControl     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  	STC Timer��5   	   $��230.5��6   $	��377��6*    � 
ResizeMode$ CanMinimize=�5	   K    � Icon$ Resources/clock_8654.ico��6d    � DataContext 6	   ��  �� RelativeSource ��  �� Mode$
 Self=� � 	Resources 5
         CountdownAnimation �� 
TargetName �� TargetProperty	 W� From	
 W� To g� AutoReverse g� Duration  BlinkingTextAnimate	 �� To g� RepeatBehavior��%�  &	        &	 �     �� 5   
   .��5      W� $ progressBar��5      $ 
Percentage�5      $		 0.0X�5      $	
 1.0X�6$    .   6-   �� *
Duration+5      5      �� 5   
   .��5      �� $ progressBar��5      $, &(SegmentColor).(SolidColorBrush.Color)�5      $ TransparentX�5      $ 0:0:0.75D�6*   $ Forever��5       . 62   5      5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��Center=�6   $��Center=�6:    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ St��5      $��50,3,-50,-3q�6!   $��2��66   .+�5       � $��Center=�6   $��Center=�60   .+�5!      )   #DesignInControl.CircularProgressBar  $��Center=�66   $��Center=�6S      SegmentColor$ 	#FF878889��6n      StrokeThickness$ 7��6�      
Percentage$	 100Q�6�      Radius$ 80��6�     5"      -   5          Name$ progressBar��5"   6   $��Center=�6L   $ 0Q�6g   $ 7��6w   $ 80��6�   |�. 6�   �� 5#      -   5         ��Name$ button��5$        BubleButton#��[ 5#      $
��Left=�5%      $	��Top=�5&      $	��167��5'      $	��167��6%   ���	#00723B3B
������ $��3,3,0,0q�5+      |�.  {�.   � Cursor$
 Hand��5,   +   ��5$   )   �� *StringCountdown+5,   +   5-      5.      �� 5/   
   -   5        $ 
recoilTo20��5/      $��	20 мин��50      $
��Left=�51      $��	-82,3,0,0q�52      $	��Top=�53      $��95��54      $��48��6     
ButtonBlue#���  55      $��14.667(�56      $
 Hand��58      |�.  59      �� 5;   
   -   5        $ 
recoilTo30��5;      $��	30 мин��5<      $
��Left=�5=      $��
-82,65,0,0q�5>      $	��Top=�5?      $��95��5@      $��48��6     ButtonOrange#���  5A      $��14.667(�5B      $
 Hand��5D      |�.  6   �� 5F   
   -   5        $ 
recoilTo60��5F      $��1 час��5G      $
��Left=�5H      $��-82,125,0,-3q�5I      $	��Top=�5J      $��95��5K      $��48��6     ButtonGreen#���  5L      $��14.667(�5M      $��2��5O      $
 Hand��5P      |�.  6   �� 5R   
   -   5        $ 
restartbtn��5R      #��[ 5S      
������ $
��Left=�5U      $	��Top=�6,   $��31,135,0,-8q�5V      $��42��6&   $��43��61   ���	#00707070$��0q�5W   B   $��2��6V   {�.  $
 Hand��5X   #   |�.  .��5Y      �� $%��/Resources/update-arrow (1).png��6   $��33��6=   $��32��6I   6V   5Z      �� 5[   
   -	   5         ��Name$ image��5[      $
��Left=�6   $��74��6:   $��198,-12,-89,0q�6F   $	��Top=�6]   $��61��6u   $��Resources/23.png��6�   5\      5]      