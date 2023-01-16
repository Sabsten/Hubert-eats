
using Hubert_Eats_manager.Model;
using Microsoft.Win32;
using Model;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO.Enumeration;
using MySql.Data.MySqlClient;

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
            Form_Initialize();
            try
            {
                userName = TextBoxUsername.Text.Trim();
                userPassword = TextBoxPassword.Password.Trim();
                Tuple<bool, string> VmResponse = new(true, "");
                Tuple<bool, string> LoginState = IdentificationClass.Login(userName, userPassword);
                if (LoginState.Item1)
                {
                    
                    UserLoggedClass.UserName = userName;
                    string connected = "Connecté en tant que : " + userName;
                    ConnectedAs.Text = connected;

                    UserLoggedClass.UserRole = DataBaseManagerClass.GetRole(userName);
                    if (UserLoggedClass.UserRole == "Developpeur")
                    {
                        MessageBox.Show(MessageClass.GetErrorMessage("UserNotAllowed"));
                    }
                    else
                    {
                        AddTab.Visibility = Visibility.Collapsed;
                        ModifierTab.Visibility = Visibility.Collapsed;
                        DeleteTab.Visibility = Visibility.Collapsed;
                        ConsultationTab.Visibility = Visibility.Collapsed;
                        LogTab.Visibility = Visibility.Collapsed;
                        List<string> Permission = RolePermissionClass.GetPermission(UserLoggedClass.UserRole);

                        
                        if (Permission.Contains("Add"))
                            AddTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Modify"))
                            ModifierTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Delete"))
                            DeleteTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Consult"))
                            ConsultationTab.Visibility = Visibility.Visible;
                        if (Permission.Contains("Log"))
                            LogTab.Visibility = Visibility.Visible;
                        Resources["homeVisible"] = Visibility.Hidden;
                        Resources["pageSelection"] = Visibility.Visible;
                    }
                }
                else if (LoginState.Item2 =="root")
                {
                    seederVisible.Visibility = Visibility.Visible;
                    Resources["homeVisible"] = Visibility.Hidden;

                }
                else
                {
                    ErrorMessage.Text = LoginState.Item2;
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion survenue: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
                ModifyDataGrid.ItemsSource = DataBaseManagerClass.FindUserr(UsernameTextBoxModifyTab.Text);
                ModifyDataGrid.Items.Refresh();
                if (ModifyDataGrid.Items.Count != 0)
                {
                    ModifyCombobox.Visibility = Visibility.Visible;
                }
                else
                {
                    ChoixActifCombobox.Visibility = Visibility.Collapsed;
                    ChoixRoleCombobox.Visibility = Visibility.Collapsed;
                    ChoixValue.Visibility = Visibility.Collapsed;
                    ModifyCombobox.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                DeleteGetInfosClearText();
                DeleteDataGrid.ItemsSource = DataBaseManagerClass.FindUserr(inputUsername);
                DeleteDataGrid.Items.Refresh();
                if (DeleteDataGrid.Items.Count == 1)
                {
                    DeleteUserButton.Visibility = Visibility.Visible;
                }
                else
                {
                    DeleteUserButton.Visibility = Visibility.Hidden;
                }
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
                case "LogTab":
                    DataGridLog.ItemsSource = DataBaseManagerClass.LogSQLDataToDatagrid();
                    DataGridLog.Items.Refresh();
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
                VmResponse = DataBaseManagerClass.AddUser(inputUsername.Substring(0, 1).ToLower() + "." + inputUsername.Split(" ")[1].ToLower() + "@hubert.com", inputUsername, inputUserPassword, inputUserRole);
                while (VmResponse.Item1 == false)
                {
                    MessageBox.Show("Un utilisateur ayant le même identifiant est déclaré dans la base \n" +
                        "Merci de modifier légérement l'identifiant, conformément à la politique de nomage. (p.nom@hubert.com)", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //VmResponse = DataBaseManagerClass.FindUser(inputUsername).ToArray()[0];
                    if (VmResponse.Item1)
                    {
                        MessageBox.Show("L'indentifiant associé est : " + inputUsername.Substring(0, 1).ToLower() + "." + inputUsername.Split(" ")[1].ToLower() + "@hubert.com", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Resources["addUserPage"] = Visibility.Hidden;
                        Resources["pageSelection"] = Visibility.Visible;
                    }
                }
            }
        }

        private void Button_Click_ConfirmUserModification(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_TextChanged_1(object sender, RoutedEventArgs e)
        {
        }


        private void Button_Click_DlConsultData(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click_DlData(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE");
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DateTime thisDate = DateTime.Today;
                CultureInfo format = new CultureInfo("pt-BR");
                var button = sender as Button;
                if (button.Name == "DlLogData")
                {
                    CSVClass.ExportToCSV(DataBaseManagerClass.LogSQLDataToDatagrid(), dialog.FileName + "\\LogDatabase_" + thisDate.ToString("d", format).Replace("/", "_") + ".csv");
                }
                else
                {
                    CSVClass.ExportToCSV(DataBaseManagerClass.SQLDataToDatagrid(), dialog.FileName + "\\ExtractUserDatabase__" + thisDate.ToString("d", format).Replace("/", "_") + ".csv");
                }
            }
        }
        
        private void Form_Initialize()
        {
            AddUserButton.Visibility = Visibility.Hidden;
            ModifyCombobox.Visibility = Visibility.Hidden;
            ChoixValue.Visibility = Visibility.Hidden;
            ChoixRoleCombobox.Visibility = Visibility.Hidden;
            ChoixActifCombobox.Visibility = Visibility.Hidden;
            ModifyButton.Visibility = Visibility.Hidden;
            DeleteUserButton.Visibility = Visibility.Hidden;
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

            //parameterValue = ModifyValue.Text;
            //ModifyValue.Clear();
        }

        private void Button_Click_Create_Usertable(object sender, RoutedEventArgs e)
        {
            var resp = SeederClass.CreateUserTable();
            UserTableState.Text = resp.Item2;
            if (resp.Item1 == true)
                UserTableState.Foreground = System.Windows.Media.Brushes.Green;
            else
            {
                UserTableState.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void Button_Click_Create_LogTable(object sender, RoutedEventArgs e)
        {
            var resp = SeederClass.CreateLogTable();
            LogTableState.Text = resp.Item2;
            if (resp.Item1 == true)
                LogTableState.Foreground = System.Windows.Media.Brushes.Green;
            else
            {
                LogTableState.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void Button_Click_Use_Seeder(object sender, RoutedEventArgs e)
        {
            var resp = SeederClass.ApplySeeder();
            SeederState.Text = resp.Item2;
            if (resp.Item1 == true)
                SeederState.Foreground = System.Windows.Media.Brushes.Green;
            else
            {
                SeederState.Foreground = System.Windows.Media.Brushes.Red;
            }

        }

        private void ModifyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Combobox = (ComboBox)sender;
            var selectedItem = (ComboBoxItem)Combobox.SelectedItem;
            switch (selectedItem.Content.ToString())
            {
                case "Identifiant":
                case "Nom Prénom":
                case "Mot de passe":
                    ChoixActifCombobox.Visibility = Visibility.Collapsed;
                    ChoixRoleCombobox.Visibility = Visibility.Collapsed;
                    ChoixValue.Visibility = Visibility.Visible;
                    break;
                case "Rôle":
                    ChoixActifCombobox.Visibility = Visibility.Collapsed;
                    ChoixValue.Clear();
                    ChoixValue.Visibility = Visibility.Collapsed;
                    ChoixRoleCombobox.Visibility = Visibility.Visible;
                    break;
                case "Compte actif ?":
                    ChoixRoleCombobox.Text = "";
                    ChoixRoleCombobox.Visibility = Visibility.Collapsed;
                    ChoixValue.Clear();
                    ChoixValue.Visibility = Visibility.Collapsed;
                    ChoixActifCombobox.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void ModifyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void DeleteDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoleAddUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Combobox = (ComboBox)sender;
            var selectedItem = (ComboBoxItem)Combobox.SelectedItem;
            if (UsernameAddUser.Text != "" && PasswordAddUser.Text != "" && PasswordConfirmationAddUser.Text != "" && selectedItem.Content.ToString() != "")
            {
                AddUserButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddUserButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
