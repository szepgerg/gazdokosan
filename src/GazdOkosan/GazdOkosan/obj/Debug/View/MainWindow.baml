   M S B A M L   `   `   `  ����E  AGazdOkosan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GazdOkosan.ViewModelGazdOkosan.ViewModel  5   	        GazdOkosan.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:GazdOkosan.ViewModel     5   	     � Title$  Gazdálkodj Okosan��5   	   $	��350��6#   $	��525��60   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5	      $	��325 �6   .+�5   
   o� $��0��6   .@�5      m� $��Fájl��6   .@�5      m� $��Új játék��6    m� Command 6-   �� *NewGameCommand+m� 5      $��	Kilépés��6    6,   �� *ExitCommand+5      m� 5      $��Súgó��6    6%   �� *HelpCommand+5      5       � 5   
   $��Játéktér��6   $	��274��6#   $��	10,11,0,0q�60   $	��Top=�6C   $
��Left=�6[   $	��372��6v   $��1��6�   �� 5   
   -   5        $��dobas��5   w   $��Dobás��6   $
��Left=�6!   $��25��6<   $��387,11,0,289q�6H   $	��120��6^   $��1��6j   ��6�   �� *DobasParancs+�� 5   
   $��Takarékbetét váltás��6   $
��Left=�6/   $��25��6J   $��387,41,0,259q�6V   $	��120��6l   $��1��6x   �� 5   
   $��Ház vásárlás��6   $
��Left=�6(   $��25��6C   $��387,71,0,229q�6O   $	��120��6e   $��1��6q   �� 5   
   $��Törlesztés��6   $
��Left=�6&   $��25��6A   $��387,101,0,199q�6M   $	��120��6d   $��1��6p   �� 5   
   $��Feladás��6   $
��Left=�6#   $��25��6>   $��387,131,0,169q�6J   $	��120��6a   $��1��6m   5      5      