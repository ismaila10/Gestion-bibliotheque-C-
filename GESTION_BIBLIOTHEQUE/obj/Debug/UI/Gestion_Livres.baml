   M S B A M L   `   `   `  ����O  KGESTION_BIBLIOTHEQUE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GESTION_BIBLIOTHEQUE.UIGESTION_BIBLIOTHEQUE.UI  5   	   ,    &GESTION_BIBLIOTHEQUE.UI.Gestion_Livres   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GESTION_BIBLIOTHEQUE.UI     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $
��auto��5	   	   $
��auto��6   .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��25* �6   �� 5      $��6* �6   �� 5      $	��31* �6   �� 5      $	��31* �6   �� 5      $	��31* �6   �� 5      $	��31* �6   .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   .   $��6��6�   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      �� $
��Left=�6   ���	#FFC79532$	��930��6L   $	��625��6X   $��	0,-20,0,0q�6f   $	��Top=�6y   $��5��6�   ���	#FFC79532���	#FF392B10 � 	Resources 5       �� 
TargetType �� Property �� Value ��Name	 �� Triggers
 �� Value �� Binding �� RelativeSource �� Mode �� AncestorType �� Path �� 
TargetName��%�  '��       �� 5      " ��6   .�5      ��  � ��$ 5q�6<   �� 5       � ��$ 1q�64   �� 5       � �� 5      �� 5   "   .R�5   &   �� $
 grid��6-   ���	#FFE6C27C._�5   *   �� ��5   .   �� 5    2   $��0q�6<   $��16(�6G   #��z��6U   5"   +   5#   '   	 5$   &   �� 5%   *   $

 True��6�    66   ��  �� $ FindAncestor=�" ��$ 
IsSelected�.a�5&   .   �� $
 grid��65    � ��
 �����6]   5'   +   5)   #   5+      5,      5.      .@�5/      �� $�� Ajouter Livre ��6   $��Showcard Gothic)�63   $��14(�6P   ���	#FF392B10���	#FFC79532��50      �� 51       �� EndPoint$	 0,1&�6.    �� 
StartPoint$	 0,0&�6=   .��52      �  � Color$ 	#FFF0F0F0��6+    � Offset$ 0Q�6=   � 53      $ 	#FFC79532��6+   $ 1Q�6=   54      .��57      � $��2,2,2,2q�6   ���#e4cb9d  58      �� 59      $	��33* �6/   �� 5:      $	��23* �6/   �� 5;      $
��149* �6/   �� 5<      $	��59* �6/   �� 5=      $
��656* �6/    � RowDefinitions 5?      �� 5@      $
��123* �6,   �� 5A      $
��319* �6,   .+�5C      �� $��Détails livre��6$   $
��Left=�6;   $��17,34,0,140q�6V   $��2��6k   $	��412��6|   ���	#FFC79532$��4��6�   $��1��6�   �� 5D      $��Auteur��6$   $
��Left=�64   $��242,36,0,281q�6O   $��2��6e   $	��364��6v   ���	#FFC79532$��4��6�   �� 5G      -   5         ��Name$ categorie_txt��5G   �   $
��Left=�6#   $��45,82,0,307q�6>   $��38��6S    �� TextWrapping$
 Wrap=�6_   $	��180��6s   ���	#FF0E0C0C
�������$��Century Gothic)�6�   $��16(�6�   $��1��6�   $��3��6�   $��2��6  $
��Bold"�6  {�.  6-  �� 5H      $��
Catégorie��6    $��32��64   $��16(�6@   $��	24,84,1,0q�6N   $	��Top=�6a   $��1��6y   $��2��6�   $��Stencil)�6�   �� 5I      -   5        $ nom_auteur_txt��5I   �   $
��Left=�6"   $��38��6=   $��
396,14,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��180��6�   ���	#FF0E0C0C
�������$��1��6�   $��
Lucida Fax)�6�   $��16(�6�   $��4��6
  $
��Bold"�6  {�.  6,  �� 5J      -   5        $ nationalite_auteur_txt��5J   "   $
��Left=�6B   $��38��6]   $��
396,87,0,0q�6i   $
 Wrap=�6}   $	��Top=�6�   $	��180��6�   
���   �
�������$��1��6�   $��
Lucida Fax)�6�   $��16(�6  $��4��6  $
��Bold"�6  {�.  61  �� 5K      -   5        $ prenom_auteur_txt��5K   #   $
��Left=�6>   $��38��6Y   $��396,100,0,0q�6e   $
 Wrap=�6z   $	��Top=�6�   $	��180��6�   
���   �
�������$��
Lucida Fax)�6�   $��16(�6�    J� RenderTransformOrigin$ 0.389,-0.134&�6�   $��4��6$  $
��Bold"�64  {�.  6F  �� 5L      -   5        $ maison_edition_txt��5L   "   $
��Left=�6>   $��38��6Y   $��45,1,0,0q�6e   $
 Wrap=�6w   $	��Top=�6�   $	��180��6�   
�������$��1��6�   
���   �$��
Lucida Fax)�6�   $��16(�6�   $ 0.533,3.354&�6	  $��3��6-  $��2��6=  $
��Bold"�6Q  {�.  6c  �� 5M      $��Titre��6    $��
20,93,24,0q�60   $ 0.89,-0.001&�6D   $��Stencil)�6h   $��16(�6}   $��30��6�   $	��Top=�6�   $��2��6�   �� 5N      $��Prénom��6    $
��Left=�61   $��
264,0,0,26q�6L   $��Bottom=�6`   $��Stencil)�6{   $��16(�6�   $��93��6�   $��29��6�   $ 0.587,1.163&�6�   $��4��6�   �� 5O      $	��Nom��6    $
��Left=�6.   $��
286,26,0,0q�6I   $	��Top=�6]   $��Stencil)�6u   $��1��6�   $��16(�6�   $ 0.46,-0.297&�6�   $��4��6�   �� 5P      $��Nationalité��6    $
��Left=�66   $��
256,95,0,0q�6Q   $	��Top=�6e   $��Stencil)�6}   $��1��6�   $��16(�6�   $��40��6�   $	��118��6�   $��4��6�   �� 5Q      $��Maison d'Edition��6    $
��Left=�6;   $��21,6,0,0q�6V   $	��Top=�6h   $��Stencil)�6�   ���	#FF392B10$ 0.26,-0.577&�6�   $��1��6�   $��16(�6�   $��36��6�   $	��151��6�   $��2��6  $��2��6  �� 5R      $
��Left=�6    $��3,86,0,0q�6;   $	��Top=�6M   $	��106��6e   $��2��6r   $��1��6�   �� 5S      $��Quantité en Stock��6    $
��Left=�6<   $��
18,232,0,0q�6W   $	��Top=�6k   $��Stencil)�6�   $��16(�6�   $��30��6�   $	��174��6�   $��2��6�   $��1��6�   $��2��6�   �� 5T      -   5         ��Name$ annuler_btn��5T   !   $��Annuler��66   $
��Left=�6H   $��449,331,0,0q�6c   $��1��6x   $	��Top=�6�   $��92��6�   ���	#FFC79532$��42��6�   ���	#FF392B10���	#FF392B10$ 
0.43,2.381&�6  $��4��63  �� 5U      -   5        $ valider_btn��5U   !   $��Valider��66   $
��Left=�6H   $��262,329,0,0q�6c   $��1��6x   $	��Top=�6�   $��94��6�   ���	#FFC79532$��42��6�   ���	#FF392B10���	#FF392B10$ 3.118,0.919&�6  $��4��64  �� 5V      -	   5        $ qteStock_txt��5V   "   $
��Left=�68   $��
45,227,0,0q�6S   $	��Top=�6g   $	��180��6   
����������	#FF0A0808$��
Lucida Fax)�6�   $��18(�6�    �� 	MaxLength$ 10��6�   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6�   $��38��6  $��3��6   $��1��60  $
��Bold"�6=  {�.  $��2��6a  �� 5W      $��Niveau d'Etude��6    $��16(�69   $
��Left=�6G   $��
22,162,0,0q�6b   $��1��6v   $	��Top=�6�   $��2��6�   $��Stencil)�6�   $��2��6�   �� 5X      $��Quantité à ajouter��6    $
��Left=�6=   $��262,209,0,0q�6X   $	��Top=�6m   $��Stencil)�6�   $��16(�6�   $��30��6�   $	��202��6�   $��1��6�   $��4��6�   �� 5Y      -
   5        $ quantite_txt��5Y   "   $
��Left=�68   $��463,204,0,0q�6S   $��1��6h   $	��Top=�6u   $	��118��6�   
����������	#FF0A0808$��
Lucida Fax)�6�   $��18(�6�   $ 10��6�   $ Display=�6�   $��38��6"  $��4��6.  $ 0.458,-4.118&�6>  $
��Bold"�6c  �� 5Z      -   5         ��Name$ combo_titre��5Z   #   
�������$
��Left=�6K   $��	45,90,0,0q�6f   $	��Top=�6y   $	��180��6�   $��2��6�   $��3��6�   $��38��6�   $��
Lucida Fax)�6�   $��16(�6  $
��Bold"�6#  �� 5[      -   5        $ 
niveau_txt��5[   "   
�������$
��Left=�6I   $��38��6d   $��
45,153,0,0q�6p   $��1��6�   $
 Wrap=�6�   $	��Top=�6�   $	��180��6�   $��3��6�   $��2��6�   $��
Lucida Fax)�6�   $
��Bold"�6  $��16(�6  {�.  6%  �� 5\      -   5        $��Nouveau��5\   !   $��2��63   $
��Left=�6C   $��
78,333,0,0q�6^   $��1��6r   $	��Top=�6   $	��114��6�   ���	#FFC79532$��2��6�   �� 5]      $��*��6    $
��Left=�6,   $��
174,90,0,0q�6G   $	��Top=�6[   $��20��6s   $��18(�6~   $
��Bold"�6�   $��4��6�   �� 5^      $��*��6    $
��Left=�6,   $��589,205,0,0q�6G   $	��Top=�6\   $��21��6t   $��18(�6   $
��Bold"�6�   $��1��6�   $��4��6�   5`      5a      �� 5b      $�� Liste des Livres ��6   $��14(�66   $��Showcard Gothic)�6D   ���	#FF392B10���	#FFC79532��5c      �� 5d      $	 0,1&�6.   $	 0,0&�6=   .��5e      � $ 	#FFF0F0F0��6+   $ 0Q�6=   � 5f      $ 	#FFC79532��6+   $ 1Q�6=   5g      .��5j      � ���#e4cb9d$��2,2,2,2q�61     5k      �� 5l      $	��81* �6/   �� 5m      $	��20* �6/   �� 5n      $
��820* �6/    5p      �� 5q      $	��47* �6,   �� 5r      $
��136* �6,   .+�5u      �� $��LISTES DES LIVRES��6    $
��Left=�6<   $��
249,26,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   $��Cooper Black)�6�   $��16(�6�   $��2��6�   �� 5v      -   5        $ modifier_btn��5v   !   $��Modifier��67   $
��Left=�6J   $��277,374,0,0q�6e   $��1��6z   $	��Top=�6�   $	��120��6�   ���	#FFC79532���	#FF392B10���	#FF392B10$��2��6  $��40��6  $ 0.542,0.875&�6(  �� 5w      -   5        $ selectLine_txt��5w   "   $��2��6:   $
��Left=�6J   $��23��6e   $��	26,47,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   �� 5x      -   5        $ recherche_txt��5x   "   $��2��69   $
��Left=�6I   $��40��6d   $��
652,80,0,0q�6p   $	��Top=�6�   $	��137��6�   
����������	#FF392B10$��
Lucida Fax)�6�   $��16(�6�   $ 10��6�   $ Display=�6  ���	#FF392B10$
��Bold"�6q  �� 5y      $��Rechercher par titre��6    $��2��6?   $
��Left=�6O   $��
431,87,0,0q�6j   $	��Top=�6~   $	��198��6�   �� 5z      $��Nombre DE LIVRES��6    $
��Left=�6;   $��	35,87,0,0q�6V   $	��Top=�6i   $ 1.067,1.704&�6�   $��3��6�   $	��138��6�   �� 5{      -   5        $ 
nombre_txt��5{   "   $��2��66   $
��Left=�6F   $��33��6a   $��	88,85,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $��78��6�   ���	#FFFFFBFB���	#FF392B10{�.  6�   &   System.Windows.Controls.DataGrid  5|      -   5          Name$ 
dataLivres��5|   #   $��3��67   $
��Left=�6K   $   HorizontalScrollBarVisibility$ Visible=�6f      GridLinesVisibility$	 All=�6�       CanUserResizeRows  .  ���	#FF392B10���	#FF392B10!   AutoGenerateColumns! .  "   	RowHeight$" 35Q�6  #   AlternatingRowBackground# �	#FFCFA34D$   RowBackground$ �	#FFE6C27C$	��358��6]  $��35,0,0,0q�6j  $	��Top=�6|  $	��855��6�  %   HorizontalGridLinesBrush% �	#FF392B10&   VerticalGridLinesBrush& �	#FF392B10'   CanUserResizeColumns' .  (   CanUserReorderColumns( .  )   CanUserSortColumns) .  *   
IsReadOnly* . $��1��6  +   	CellStyle+ 5}      �� 5~   "   *  $System.Windows.Controls.DataGridCell"  6(   , �� Triggers, 5   &   P� 5�   *   - P� Property- �@ 
IsSelected. P� Value. . . �5�   .   ��  � �� �	#FFC795326X   �� 5�   .    � ��
 �����6X   �� 5�   .    � ��
 �����6Y   �� 5�   .    � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #   /   ColumnHeaderStyle/ 5�      �� 5�   "   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6(   0 �� 	Resources0 5�   &      ColumnHeaderGripperStyle1 �� 
TargetType2 �� Padding��%�   &	        �� 5�   *   " n�6Q   .�5�   .   ��  � ��$ 8��6F   �� 5�   .    � ��
 ���� 6K   �� 5�   .    � �� 5�   2   �� 5�   6   "1 n�6F   .R�5�   :   �� 
���  ��#2 z��6R   5�   7   5�   /   5�   +   5�   '   .�5�   &   ��  � �� 5�   *   �� 5�   .   "1  6>   .R�5�   2   � ���	#FFC79532 5�   6   �� 5�   :   $��40 �6H   .+�5�   6   �� $��39��6G   #��z��6U   3 J� SnapsToDevicePixels#3 z3 5�   0   #��z��6m   4 J� OpacityMask
4 �   �6�   �� 5�   6   $��1��6@   $��39��6M   $��Stretch=�6Y   ���	#FF392B106w   5�   3   5�   /   5�   '   5�   #   5   Columns5 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,	  &System.Windows.Controls.DataGridColumn6 	  Header$/6 )                           Titre du livre��6U   7   
FontFamily$7 
Lucida Fax)�6�   8   FontSize$8 14Q�6�   9 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	9 255
 6�   :   
FontWeight$
: Bold"�6�   ; 	  MaxWidth$	; 400Q�6�   1  +System.Windows.Controls.DataGridBoundColumn<   Binding< 65   �� *Titre_Livre+=   ElementStyle= 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #     5�   "   $6                    Auteur��6P   $7 
Lucida Fax)�6s   $8 14Q�6�   $	9 159
 6�   $
: Bold"�6�   < 65   �� *Auteur+= 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #     5�   "   $6            Catégorie��6S   $7 
Lucida Fax)�6q   $8 14Q�6�   $	9 135
 6�   $
: Bold"�6�   < 65   �� *	Categorie+= 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #     5�   "   $6            Niveau étude��6V   $7 
Lucida Fax)�6w   $	9 150
 6�   $8 14Q�6�   $
: Bold"�6�   < 65   �� *Niveau_Etude+= 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #     5�   "   $6        Nombre de Livres��6W   $7 
Lucida Fax)�6x   $	9 165
 6�   $8 14Q�6�   $
: Bold"�6�   < 65   �� *Nombre_Livres+= 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$ Center=�6T   �� 5�   .    � ��$ Center=�6R   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      