
using Hubert_Eats_manager.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace Hubert_Eats_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userName;
        public string userPassword;
        public string inputUsername;
        public string inputUserPassword;
        public string inputUserPassword2;
        public string inputUserRole;
        public string inputIdentifiant;
        public string parameterSelected;
        public string parameterValue;
        public List<List<string>> Data;
        public Tuple<bool, string> VmResponse;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                userName = TextBoxUsername.Text.Trim();
                userPassword = TextBoxPassword.Password.Trim();
                Tuple<bool, string> VmResponse = new(true, "");
                Tuple<bool, string> LoginState = IdentificationClass.Login(userName, userPassword);
                if (LoginState.Item1)
                {
                    
                    UserLoggedClass.UserName = userName;
                    ConnectedAs.Text = "Connecté en tant que : " + userName;
                    UserLoggedClass.UserRole = DataBaseManagerClass.GetRole(userName);
                    if (UserLoggedClass.UserRole == "Developpeur")
                    {
                        MessageBox.Show("Utilisateur enregistré, mais n'a pas accès a Hubert-Eats Manager. Merci de contacter votre manager.");
                    }
                    else
                    {
                        AddTab.Visibility = Visibility.Collapsed;
                        ModifierTab.Visibility = Visibility.Collapsed;
                        DeleteTab.Visibility = Visibility.Collapsed;
                        ConsultationTab.Visibility = Visibility.Collapsed;
                        List<string> Permission = RolePermissionClass.GetPermission(UserLoggedClass.UserRole);

                        
                        if (Permission.Contains("Add"))
                            AddTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Modify"))
                            ModifierTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Delete"))
                            DeleteTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Consult"))
                            ConsultationTab.Visibility = Visibility.Visible;
                        Resources["homeVisible"] = Visibility.Hidden;
                        Resources["pageSelection"] = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show(LoginState.Item2, "Identification incorrect", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion survenue: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void TextBox_TextChanged_1(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_TextChanged_2(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_AddUserSelection(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_EditUserSelection(object sender, RoutedEventArgs e)
        {
        }

        public void Button_Click_ConfirmUserRemoval(object sender, RoutedEventArgs e)
        {
        }

        public void Button_Click_ModifyUser(object sender, RoutedEventArgs e)
        {
            ModifyGetInfosClearText();
            DataBaseManagerClass.ModifyUser(parameterValue, parameterSelected, inputUsername);
        }

        private void Button_Click_FindUser(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "FindUserButtonModifyTab")
            {
                ModifyDataGrid.ItemsSource = DataBaseManagerClass.FindUserr(inputUsername);
                ModifyDataGrid.Items.Refresh();
            }
            else
            {
                DeleteGetInfosClearText();
                DeleteDataGrid.ItemsSource = DataBaseManagerClass.FindUserr(inputUsername);
                DeleteDataGrid.Items.Refresh();

            }
        }

        private void Button_Click_DeleteUser(object sender, RoutedEventArgs e)
        {
            DeleteGetInfosClearText();
            DataBaseManagerClass.DeleteUser(inputUsername);
        }
        public void TabControl_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Name as string;
            switch (tabItem)
            {
                case "AddTab":
                    break;

                case "DeleteTab":
                    break;

                case "ModifierTab":
                    break;

                case "ConsultationTab":
                    myDataGrid.ItemsSource = DataBaseManagerClass.SQLDataToDatagrid();
                    myDataGrid.Items.Refresh();
                    break;

            }
        }

        private void Button_Click_ConfirmUserCreation(object sender, RoutedEventArgs e)
        {
            AddGetInfosClearText();
            if (!inputUsername.Contains(" ") || inputUsername == "")
            {
                MessageBox.Show("Merci de respecter la casse : Prénom NOM.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (inputUserPassword != inputUserPassword2 || inputUserPassword2 == "")
            {
                MessageBox.Show("La confirmation du mot de passe a échouée. Veuillez ressayer.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (inputUserRole == "")
            {
                MessageBox.Show("La sélection d'un rôle est nécessaire.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Dictionary<string, string> UserInfo = new();
                UserInfo.Add("Identifiant", inputUsername.Substring(0, 1).ToLower() + "." + inputUsername.Split(" ")[1].ToLower() + "@hubert.com");
                UserInfo.Add("Nom", inputUsername);
                UserInfo.Add("Password", inputUserPassword);
                UserInfo.Add("role", inputUserRole);
                UserInfo.Add("createdBy", userName);
                UserInfo.Add("modifiedBy", userName);
                VmResponse = DataBaseManagerClass.AddUser(UserInfo);
                while (VmResponse.Item1 == false)
                {
                    MessageBox.Show("Un utilisateur ayant le même identifiant est déclaré dans la base \n" +
                        "Merci de modifier légérement l'identifiant, conformément à la politique de nomage. (p.nom@hubert.com)", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Console.WriteLine(UserInfo["Identifiant"]);
                    //Window1 win1 = new Window1(UserInfo["Identifiant"]) ;
                    //win1.ShowDialog();

                    //UserInfo["Identifiant"] = win1.newOtherIdentifiant;
                    VmResponse = DataBaseManagerClass.AddUser(UserInfo);
                    if (VmResponse.Item1)
                    {

                    }
                }

                MessageBox.Show("L'indentifiant associé est : " + inputUsername.Substring(0, 1).ToLower() + "." + inputUsername.Split(" ")[1].ToLower() + "@hubert.com", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Resources["addUserPage"] = Visibility.Hidden;
                Resources["pageSelection"] = Visibility.Visible;
            }
        }

        private void Button_Click_ConfirmUserModification(object sender, RoutedEventArgs e)
        {
        }

        private void AddGetInfosClearText()
        {
            inputUsername = UsernameAddUser.Text;
            UsernameAddUser.Clear();

            inputUserPassword = PasswordAddUser.Text;
            PasswordAddUser.Clear();

            inputUserPassword2 = PasswordConfirmationAddUser.Text;
            PasswordConfirmationAddUser.Clear();

            inputUserRole = RoleAddUser.Text;
        }
        private void DeleteGetInfosClearText()
        {
            inputUsername = UsernameDelete.Text;
            UsernameAddUser.Clear();
        }
        private void ModifyGetInfosClearText()
        {
            inputUsername = UsernameTextBoxModifyTab.Text;
            UsernameTextBoxModifyTab.Clear();

            parameterSelected = ModifyCombobox.Text;

            parameterValue = ModifyValue.Text;
            ModifyValue.Clear();
        }
    }
}
