   M S B A M L   `   `   `  ����O  KGESTION_BIBLIOTHEQUE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GESTION_BIBLIOTHEQUEGESTION_BIBLIOTHEQUE  5   	       GESTION_BIBLIOTHEQUE.Menu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GESTION_BIBLIOTHEQUE     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��720��5      $
��1290��6'     � WindowStartupLocation$  CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � WindowStyle$
 None=�6o   .��5	      � .+�5
   
   �� $	��Top=�6   .+�5      � ���	#FF785614$��17��6*   � 5      $��5q�6   .+�5      �� $��Center=�6    �� Orientation$ 
Horizontal=�6:   $��504,0,310,0q�6S   .+�5      �� $'��! GESTION BIBLIOTHEQUE DE BOINADJI��6    $��Center=�6I   $��20(�6d   $��Cooper Black)�6r   $��	20,0,20,4q�6�   ���	#FF392B10$��26��6�   $	��426��6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   $
��10 0q�6R   .+�5      �� $��30��6   $��30��6(   $��0q�6a   
���������64   Z� ��6J   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ BellOutline=�62   5      �� 5      $��30��6   $��30��6(   $��0q�6a   
�������$��0 0 10 0q�6   ��64   Z� ��6J   Z� .��5        $ Settings=�62   5      �� 5      -   5         ��Name$ ButtonFechar��5      $��30��63   $��30��6>   $��0q�6w   
���������6J   Z� ��6`   Z� .��5        $ Power=�62   5      5      5      5      � 5   
   $��309,55,-1,-4q�6   .+�5       � -   5         �Name$ GridPrincipal��5       $��Center=�6*   $��Center=�6H   5!      � 5"   
   $	��310��6   $
��Left=�6   ���	#FFC79532.+�5#      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5#   2   $��-95,0,-27,-76q�6�   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6U   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+	   Duration$	 0:0:0.2X�.��5$      � -   5        $ 
GridCursor��5$      $��	0 100 0 0q�6+   ���	#FF0069C0$��10��6U   $
��Left=�6`   $��60��6{   $	��Top=�6�   5%      �� 5&      -   5        $ deconnexion��5&      $��Déconnexion��6*   $
��Left=�6@   $��
71,626,0,0q�6[   $	��Top=�6o   $	��159��6�   ���	#FFE4CB9D���	#FF392B10$��41��6�   $��Berlin Sans FB)�6�   $��22(�6  ���	#FF392B106  �� 5(      $
��Left=�6   $��	32,23,0,0q�63   $
��Wrap=�6F   $#��GESTION BIBLIOTHEQUE BOINADJI��6Z   $	��Top=�6   $	��107��6�   $	��198��6�   $��24(�6�   $��Showcard Gothic)�6�   ���	#FFF9F1F16�   �� 5)      -   5        
 ��Name$
 ListViewMenu��5)      $��0,130,2,169q�6-   ���	#FF392B10$��Showcard Gothic)�6Y   $��17(�6v    �� SelectedIndex$ 0��6�   .@�5*      �� $��65��6   .��5+      �� $ 
Horizontal=�6!   .+�5,        $
 Home=�62   $��30��6>   $��30��6I   $��Center=�6U   $��5q�6p   �� 5-      $��Accueil��6$   $��Center=�63   $
��20 0q�6N   5.      5/      �� 50      $��65��6   .��51      �� $ 
Horizontal=�6!   .+�52        $ AccountBoxOutline=�62   $��30��6K   $��30��6V   $��Center=�6b   $��5q�6}   �� 53      $��Gestion des inscriptions��6$   $��Center=�6E   $
��20 0q�6`   54      55      �� 56      $��65��6   .��57      �� $ 
Horizontal=�6!   .+�58        $ FormatListBulleted=�62   $��30��6L   $��30��6W   $��Center=�6c   $��5q�6~   �� 59      $��Gestion des livres��6$   $��Center=�6>   $
��20 0q�6Y   5:      5;      �� 5<      $��65��6   .��5=      �� $ 
Horizontal=�6!   .+�5>        $ TruckDelivery=�62   $��30��6G   $��30��6R   $��Center=�6^   $��5q�6y   �� 5?      $��Gestion des prets��6$   $��Center=�6=   $
��20 0q�6X   5@      5A      �� 5B      $��65��6   .��5C      �� $ 
Horizontal=�6!   .+�5D        $ AccountStar=�62   $��30��6E   $��30��6P   $��Center=�6\   $��5q�6w   �� 5E      $��Gestion des utilisateurs��6$   $��Center=�6E   $
��20 0q�6`   5F      5G      5H      5I      5J      5K      