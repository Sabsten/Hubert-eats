   M S B A M L   `   `   `  ����  Hubert_Eats_manager$    Hubert_Eats_manager.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5   	   $	��510��6   $	��800��6)   $	��510��65   $	��800��6E   $	��510��6T   $	��800��6d    � 	Resources 5
        System.Windows.Visibility   homeVisible  seederVisible  pageSelection��%y   &	        &	      &	 =      5   
   Visible=�62    5   
   
Hidden=�63    5   
   
Hidden=�63   5      .��5      � .+�5   
   � #y��   6   $��Center=�6:   $	��800��6W   $	��484��6c   $��Bottom=�6p   .+�5      �� -   5         ��Name$ ErrorMessage��5      
���  ��$��38,196,490,266q�6A   �� 5      -   5        +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowAnimationDuration$ 0:0:0h�5       $  MaterialDesignRaisedAccentButton#��[ 5      $��38,0,440,89q�6K    � Cursor$
 Hand��6`   $��Valider��6n   $��32��6�   $��Bottom=�6�   � 5      $��10��6    � IsIndeterminate$
 True��6&    � Orientation$ Vertical=�6=   �� 5      $$��../assets/Logo_Hubert_Eats.png��5      $��UniformToFill=�5      $��10,0,424,323q�6'   �� 5      -   5         ��Name$ TextBoxUsername��5       �� TextWrapping$
 Wrap=�5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Nom d'utilisateur��5      $��
40,242,0,0q�6D   
 J� RenderTransformOrigin$
 0.5,0.5&�6X   $��28��6x   $	��Top=�6�   $
��Left=�6�   $	��209��6�   .��6�   z�5       V� 5!      .~�5"      �� �� 5#      �� 5$       �� Angle$ 0Q�6*   T� 5%      5&      .��5'   +   ��5(      �� 5)       �� Path$
 test�5*       �� UpdateSourceTrigger$ PropertyChanged=�5+      5,      .��5-       5.      G� 50      -   5         G�Name$ TextBoxPassword��51         
HelperText$  ��52      $	 Mot de passe��53      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��55       # MaterialDesignRevealPasswordBox#��[ 57      $��
40,293,0,0q�6J   $
��Left=�6^   $	��209��6y   $��27��6�   $	��Top=�6�   0  *MaterialDesignThemes.Wpf.PasswordBoxAssist   Password 54      �� *userPasswrd+ �� Mode$ TwoWay=�{�56      �� *	IsChecked+ �� ElementName$" RevealPasswordDefaultEnabled��57   �   #  MaterialDesignThemes.Wpf.Card  58      ���#D8E3E2$��	406,0,0,0q�5:      .��5;      � $
 0.494,0.499&�6   $��	0,0,0,-11q�6<    � ColumnDefinitions 5<      �� 5=      �� 5>      $��43 �6+    � RowDefinitions 5@      �� 5A      $��20 �5B   	   �� 5C      $	��77* �6(   �� 5D      $	��76* �6(   �� 5E      $
��Auto �5F   	   $��16��6   .+�5J      �� $��2��5K      $��10,10,-2,10q�5L      $��2��6   .+�5M      �� $
��Bold"�5N   	   $	��298��6   �� 6(   $�Hubert-Eats Manager��6,   6J   �� 5O      $
��Wrap=�5P      $	��294��6!   $	��190��6-   �� 6<   �� 6B   �� 6N   $H�BBienvenue sur l'application de gestions des utilisateurs internes ��6R   �� 6�   $�à��6�   �� 6�   $P�J Hubert-Eats. Merci de vous connecter pour avoir l'accès a l'application.��6�   �� 6  �� 6  �� 6  �� 6"  $A�;En cas de problème avec l'application, merci de contacter ��6&  �� 6j  $�le support de la DSI :��6n  �� 6�  �� 6�  �� 6�  $
�☎ ��6�  �� 6�   � Language$ fr-fr�6�  $�: +33 9 15 89 78 31��6�  �� 6�  �� 6�  $ fr-fr�6�  $"�📧 : assistance@hubert.com��6	  6.  5Q      �� 5R      $��3��5S      $��	138,8,0,8q�5T      $
��Left=�5U       �� Orientation$ 
Horizontal=�5V      $��0��62   $��1��6<   5W      �� 5X      $��10,10,20,10q�5Y      $��Huber-Eats en images...��5Z        MaterialDesignCardGroupBox#��[ 5[      $��2��6M   $��2��6a   ��5\      �� 5]      .R�5^   "   �� $ 
Horizontal=�5_   %   .+�5`   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��32��5a   )   $��32��5b   )   $��Center=�5c   )      Kind$ 	ImageArea=�5d   )   �� 5e   &   $��8,0,0,0q�5f   )   $��Center=�5g   )    $  MaterialDesignSubtitle1TextBlock#��[ 5h   )   ��5i   )   �� 5j   #   5k      .��5m      �� $��Center=�5n      $��/assets/slider_3.jpg��5o      $��	0,0,0,-15q�6;   $	��193��6N   $��Bottom=�6[   5p      5q      5r      5s      � 5u   
   -   5         �Name$ seederVisible��5u      #y��  6&   .+�5v      �� -   5        $��	80,76,0,0q�5w      $ 1:1:1h�5x      #��[ 5y      $
 Hand��6O   $��32��6�   $	��Top=�6�   $
��Left=�6�   $	��356��6�   .��6�   !Creer la table des utilisateurs5{      �� 5|      -   5        $ UserTableState��5|      $��	0,48,10,0q�61   $��89��6D   $	��Top=�6P   $��Right=�6h   $	��332��6�   �� 5}      -   5        $��
80,225,0,0q�5~      $ 1:1:1h�5      #��[ 5�      $
 Hand��6O   $
��Left=�6�   $	��356��6�   $��32��6�   $	��Top=�6�   .��6�   Creer la table log5�      �� 5�      -	   5        $ LogTableState��5�      $��458,197,0,0q�60   $
��Left=�6E   $	��318��6`   $��76��6l   $	��Top=�6x   �� 5�      -
   5        $��	80,0,0,77q�5�      $ 1:1:1h�5�      #��[ 5�      $
 Hand��6S   $
��Left=�6�   $	��356��6�   $��32��6�   $��Bottom=�6�   .��6�   &$Appliquer le remplissage automatique5�      �� 5�      -   5        $ SeederState��5�      $��
451,0,0,10q�6.   $	��141��6B   $��Bottom=�6O   $
��Left=�6j   $	��332��6�   5�      � 5�   
   #y��  6   .+�5�      � $��Center=�6   $	��200��6.   .+�5�      � $��-295,-34,-297,-44q�6   .+�5�        .��5�      �� -   5        3  -MaterialDesignThemes.Wpf.NavigationRailAssist   ShowSelectionBackground$
 True��5�       J� SnapsToDevicePixels$
 True��5�       * &MaterialDesignNavigationRailTabControl#��[ 5�      $	��472��5�      $��0,0,10,0q�6*   .@�5�      �� -   5         ��Name$ AddTab��5�   &   
��� � ���5�   "   �� 5�   &   $
��auto��5�   &   $
��auto��5�   &   .+�5�   *     $��24��5�   )   $��24��5�   )   $��Center=�5�   )   $	 Add=�5�   )   �� 5�   *   $��Center=�5�   %   $��Ajouter��5�   %   5�   '   .��5�   "   �� $��16q�5�   %   .+�5�   &   �� $��0,0,0,8q�5�   %    $  MaterialDesignHeadline5TextBlock#��[ 5�   %   $��Ajouter un utilisateur��5�   %   �� 5�   &   -   5        $ UsernameAddUser��5�   .   $	��Top=�5�   -   $��0,10,0,0q�5�   -   $%	 Nom et prénom de l'utilisateur��5�   -    	 MaterialDesignFilledTextBox#��[	 5�   -   .��6b   ��5�   *   �� 5�   .   $ Text1�5�   1   $ PropertyChanged=�5�   1   5�   /   .��5�   8   5�   '   �� 5�   &   -   5        $ PasswordAddUser��5�   .   $	��Top=�5�   )   $	 Mot de passe��5�   )   #��[	 5�   )   $��0,20,0,0q�5�   )   .��6;   ��5�   *   �� 5�   .   $ Text1�5�   -   $ PropertyChanged=�5�   -   5�   /   .��5�   8   5�   '   �� 5�   &   -   5        $! PasswordConfirmationAddUser��5�   .   $	��Top=�5�   )   $	 Confirmation mot de passe��5�   )   #��[	 5�   )   $��0,20,0,0q�5�   )   .��6;   ��5�   *   �� 5�   .   $ Text1�5�   -   $ PropertyChanged=�5�   -   5�   /   .��5�   8   5�   '   �� 5�   &   -   5         ��Name$ RoleAddUser��5�   /   $��0,20,0,0q�5�   +   -	  'MaterialDesignThemes.Wpf.ComboBoxAssist 	  	MaxLength$ 2��5�   +   $	 Rôle��5�   +      HintOpacity$	 .26Q�5�   +     �� 
IsEditable$  False��5�   +   $��43��6>   .@�5�   *   �� $��Database Manager��5�   -   �� 5�   *   $��
Commercial��5�   -   �� 5�   *   $��	Technique��5�   -   �� 5�   *   $��Developpeur Tier��5�   -   5�   '   �� 5�   &   -   5        ! ��Name$! AddUserButton��5�   )   $��0,40,0,0q�5�   )   $ 1:1:1h�5�   )   #��[ 5�   )   $
 Hand��6c   .��5�   S   	Valider5�   '   �� 5�   &   -   5        $ AddUserState��5�   0   $��0,10,0,0q�6G   $��37��6Y   $
��Left=�6e   $	��641��6�   5�   #   5�      �� 5�      -   5        $ ModifierTab��5�   &   ��5�   "   �� 5�   &   $
��auto��5�   #   $
��auto��5�   #   .+�5�   *     $��24��5�   )   $��24��5�   )   $��Center=�5�   )   $ BorderColor=�5�   )   �� 5�   *   $��Center=�5�   )   $��Modifier��5�   )   5�   '   .��5�   "   � $��16q�5�   %   .+�5�   &   �� $��-2,0,0,8q�5   %   #��[ 5  %   $��Modifier un utilisateur��5  %   �� 5  &   -   5        $ UsernameTextBoxModifyTab��5  -   $	��Top=�5  -   $��	-2,51,2,0q�5  -   $%	 Nom d'utilisateur (@hubert.com)��5  -   #��[	 5  -   .��6b   ��5	  *   �� 5
  .   $ Text1�5  1   $ PropertyChanged=�5  1   5  /   .��5  8   5  '   �� 5  &   -   5        $! FindUserButtonModifyTab��5  )   $ 0:0:0h�5  )   $��-2,108,2,300q�5  )   #��[ 5  )   $
 Hand��6c   .��6q   '%Verifier l'existance de l'utilisateur5  '   &
   System.Windows.Controls.DataGrid
  5  &   -   5        " 
 Name$" ModifyDataGrid��5  /   -  'MaterialDesignThemes.Wpf.DataGridAssist#   SelectedCellBorderBrush
# �����$ 
  CanUserAddRows$$ False��5  +   % 
  SelectionMode$% Extended=�5  +   & 
  SelectionUnit$
& Cell=�5  +   
������' 
  AutoGenerateColumns$
' True��5  +   $	��678��6F   $��0,157,0,212q�6R   �� 5  &   -   5        $ ModifyCombobox��5   )   $ 2��5!  +   $	 Champ à modifier��5"  +   $	 .26Q�5#  +   $  False��5$  +   $��31��6>   $��	0,233,0,0q�6J   $	��Top=�6]   .@�5%  *   �� $��Identifiant��5&  -   �� 5'  *   $��Nom Prénom��5(  -   �� 5)  *   $��Mot de passe��5*  -   �� 5+  *   $��Rôle��5,  -   �� 5-  *   $��Compte actif ?��5.  -   5/  '   �� 50  &   -   5        $ 
ChoixValue��51  -   $��0,276,0,122q�52  -   $	 Nouvelle valeur��53  -   #��[	 54  -   $��42��6b   .��6n   ��55  *   �� 56  .   $ Text1�57  1   $ PropertyChanged=�58  1   59  /   .��5:  8   5;  '   �� 5<  &   -   5        $ ChoixRoleCombobox��5=  )   $ 2��5>  +   $"	 Merci de choisir un élement��5?  +   $	 .26Q�5@  +   $  False��5A  +   $��32��6>   $��
-2,286,2,0q�6J   $	��Top=�6^   .@�5B  *   �� $��Database Manager��5C  -   �� 5D  *   $��
Commercial��5E  -   �� 5F  *   $��	Technique��5G  -   �� 5H  *   $��Developpeur Tiers��5I  -   5J  '   �� 5K  &   -   5        $ ChoixActifCombobox��5L  )   $��	0,289,0,0q�5M  +   $ 2��5N  +   $"	 Merci de choisir un élement��5O  +   $	 .26Q�5P  +   $  False��5Q  +   $	��Top=�6>   $��28��6V   .@�5R  *   �� $��Activer le compte��5S  -   �� 5T  *   $��Désactiver le compte��5U  -   5V  '   �� 5W  &   -   5        $! ModifyButton��5X  )   $ 0:0:0h�5Z  )   $��
0,347,0,61q�5[  )   #��[ 5\  )   $
 Hand��6c   .��6q   Modifier l'utilisateur5^  '   �� 5_  &   -   5        $ ModifyUserState��5_  0   $��10,393,0,10q�6J   $��37��6_   $
��Left=�6k   $	��641��6�   5`  #   5a     �� 5b     -   5        $ 	DeleteTab��5b  &   ��5c  "   �� 5d  &   $
��auto��5e  %   $
��auto��5f  %   .+�5g  *     $��24��5h  )   $��24��5i  )   $��Center=�5j  )   $ Delete=�5k  )   �� 5l  *   $��Center=�5m  )   $��	Supprimer��5n  )   5o  '   .��5q  "   �� $��16q�5r  %   .+�5s  &   �� $��0,0,0,8q�5t  %   #��[ 5u  %   $��Supprimer un utilisateur��5v  %   �� 5w  &   -   5        $ UsernameDelete��5z  -   $��0,10,0,0q�5x  )   $	��Top=�5y  -   $%	 Nom d'utilisateur (@hubert.com)��5{  -   #��[	 5|  -   .��6b   ��5}  *   �� 5~  .   $ Text1�5  1   $ PropertyChanged=�5�  1   5�  /   .��5�  8   5�  '   �� 5�  &   -    5        $! FindUserButtonDeleteTab��5�  )   $ 0:0:0h�5�  )   $��0,20,0,0q�5�  )   #��[ 5�  )   $
 Hand��6c   .��6q   '%Verifier l'existance de l'utilisateur5�  '   
  5�  &   -!   5        $" DeleteDataGrid��5�  /   $��0,20,0,0q�5�  ,   
# �����$$ False��5�  +   $% Extended=�5�  +   $
& Cell=�5�  +   
�������$��65��5�  C   5�  '   �� 5�  &   -"   5        $! DeleteUserButton��5�  )   $ 0:0:0h�5�  )   $��0,20,0,0q�5�  )   #��[ 5�  )   $
 Hand��6c   .��6q   Supprimer l'utilisateur5�  '   �� 5�  &   -#   5        $ DeleteUserState��5�  0   $��0,50,0,0q�6I   $��53��6[   5�  #   5�     �� 5�     -$   5        $ ConsultationTab��5�  &   ��5�  "   �� 5�  &   $
��auto��5�  #   $
��auto��5�  #   .+�5�  *     $��24��5�  )   $��24��5�  )   $��Center=�5�  )   $ Glasses=�5�  )   �� 5�  *   $��Center=�5�  )   $��	Consulter��5�  )   5�  '   .��5�  "   �� $��16q�5�  %   .+�5�  &   �� $��0,0,0,8q�5�  %   #��[ 5�  %   $(��"Consultation de la base de donnée��5�  %   
  5�  &   -%   5        $" 
myDataGrid��5�  /   $	��350��5�  +   
# �����$$ False��5�  +   $% Extended=�5�  +   $
& Cell=�5�  +   
������$
' True��5�  +   5�  '   �� 5�  &   -&   5        $! DlConsultData��5�  )   $ 0:0:0h�5�  )   $��0,10,0,0q�5�  )   #��[ 5�  )   $
 Hand��6c   .��6q   75Télécharger un extrait de la base de donnée (.csv)5�  '   5�  #   5�     �� 5�     -'   5        $ LogTab��5�  &   ��5�  "   �� 5�  &   $
��auto��5�  #   $
��auto��5�  #   .+�5�  *     $��24��5�  )   $��24��5�  )   $��Center=�5�  )   $ Glasses=�5�  )   �� 5�  *   $��Center=�5�  )   $
��Logs��5�  )   5�  '   .��5�  "   �� $��16q�5�  %   .+�5�  &   �� $��0,0,0,8q�5�  %   #��[ 5�  %   $#��Consultation des logs servers��5�  %   
  5�  &   -(   5        $" DataGridLog��5�  =   $	��350��6/   
# �����$$ False��5�  /   $% Extended=�5�  /   $
& Cell=�5�  /   
������$
' True��5�  /   5�  '   �� 5�  &   -)   5        $! 	DlLogData��5�  )   $ 0:0:0h�5�  )   $��0,10,0,0q�5�  )   #��[ 5�  )   $
 Hand��6c   .��6q   75Télécharger un extrait de la base de donnée (.csv)5�  '   5�  #   5�     5�     5�     �� 5�     -*   5        $ ConnectedAs��5�      $��81,448,396,4q�66   5�     5�     5�     5�     5�     