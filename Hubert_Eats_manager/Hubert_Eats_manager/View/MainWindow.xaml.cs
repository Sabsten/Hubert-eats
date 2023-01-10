﻿
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
        private string userName;
        private string userPassword;
        private string inputUsername;
        private string inputUserPassword;
        private string inputUserPassword2;
        private string inputUserRole;
        private string inputIdentifiant;
        public List<List<string>> Data;
        public Tuple<bool, string> VmResponse;
        private string inputUserName;

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
                VmResponse = new(false, "");
                IdentificationClass credentials = new();
                Tuple<bool, string> LoginState = credentials.Login(userName, userPassword);

                if (LoginState.Item1)
                {
                    Resources["homeVisible"] = Visibility.Hidden;
                    Resources["pageSelection"] = Visibility.Visible;
                    foreach(var item in DataBaseManagerClass.AllData())
                        myDataGrid.Items.Add(item);
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

        private void Button_Click_RemoveUserSelection(object sender, RoutedEventArgs e)
        {     
        }

        private void Button_Click_ConfirmUserCreation(object sender, RoutedEventArgs e)
        {
            GetInfosClearText();
            if(!inputUserName.Contains(" ") || inputUserName == "")
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
                UserInfo.Add("Identifiant", inputUserName.Substring(0, 1).ToLower() + "." + inputUserName.Split(" ")[1].ToLower() + "@hubert.com");
                UserInfo.Add("Nom", inputUserName);
                UserInfo.Add("Password", inputUserPassword);
                UserInfo.Add("role", inputUserRole);
                UserInfo.Add("createdBy", userName);
                UserInfo.Add("modifiedBy", userName);
                DataBaseManagerClass main = new();
                VmResponse = main.AddUser(UserInfo);
                while (VmResponse.Item1 == false)
                {
                    MessageBox.Show("Un utilisateur ayant le même identifiant est déclaré dans la base \n" +
                        "Merci de modifier légérement l'identifiant, conformément à la politique de nomage. (p.nom@hubert.com)", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Console.WriteLine(UserInfo["Identifiant"]);
                    //Window1 win1 = new Window1(UserInfo["Identifiant"]) ;
                    //win1.ShowDialog();

                    //UserInfo["Identifiant"] = win1.newOtherIdentifiant;
                    VmResponse = main.AddUser(UserInfo);
                }

                MessageBox.Show("L'indentifiant associé est : " + inputUserName.Substring(0, 1).ToLower() + "." + inputUserName.Split(" ")[1].ToLower() + "@hubert.com", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Resources["addUserPage"] = Visibility.Hidden;
                Resources["pageSelection"] = Visibility.Visible;
            }
        }

        private void Button_Click_ConfirmUserModification(object sender, RoutedEventArgs e)
        {
            //int selectioned = 0;
            DataBaseManagerClass main = new();
            Data = main.FindUser(inputUserName);
            //while (Data[0].Count > selectioned && selectioned >= 0)
            //{
              //  //ConsoleTablePrint(Data);
                //Console.WriteLine("Selectionnez la donnée a modifier : ");
                //selectioned = Int32.Parse(Console.ReadLine());

            //}
            //Console.WriteLine("Entrez une nouvelle valeur pour ce choix: ");
            //VmResponse = main.ModifyUser(Console.ReadLine(), selectioned, Data, otherIdentifiant, userName);
        }

        private void Button_Click_ConfirmUserRemoval(object sender, RoutedEventArgs e)
        {
            if(inputUserName != "")
            {
                DataBaseManagerClass main = new();
                VmResponse = main.DeleteUser(inputUserName);
            }
        }
        private void GetInfosClearText()
        {
            inputUserName = UsernameAddUser.Text;
            UsernameAddUser.Clear();

            inputUserPassword = PasswordAddUser.Text;
            PasswordAddUser.Clear();

            inputUserPassword2 = PasswordConfirmationAddUser.Text;
            PasswordConfirmationAddUser.Clear();

            inputUserRole = RoleAddUser.Text;
        }
    }

    class MainProgram
    {
        private static string UserName;
        private const string V = "Error: ";
        private static string Header = @"
                                            __  __      __              __                __      
                                           / / / /_  __/ /_  ___  _____/ /_   ___  ____ _/ /______
                                          / /_/ / / / / __ \/ _ \/ ___/ __/  / _ \/ __ `/ __/ ___/
                                         / __  / /_/ / /_/ /  __/ /  / /_   /  __/ /_/ / /_(__  ) 
                                        /_/ /_/\__,_/_.___/\___/_/   \__/   \___/\__,_/\__/____/  
                                                                                                  
                                                                                                  
identifé en tant que : " + UserName + "                                                      " +
"                                                                             ";

        /*static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Title = "HubertEatsInternal";
                    clearConsole();
                    Console.WriteLine("Merci de vous connecter.");
                    Console.WriteLine("Identifiant :");
                    UserName = Console.ReadLine();
                    Console.WriteLine("Mot de passe :");
                    string password = Console.ReadLine();
                    DataBaseManagerClass main = new();
                    IdentificationClass credentials = new();
                    Tuple<bool, string> LoginState = credentials.Login(UserName, password);
                    if (LoginState.Item1 == true)
                    {
                        clearConsole();
                        Console.WriteLine("Connection reussie.");

                        while (true)
                        {
                            Console.WriteLine("Que souhaitez vous faire ? Tapez le code correspondant.");
                            Console.WriteLine("1 - Ajouter un utilisateur dans la base.");
                            Console.WriteLine("2 - Modifier un utilisateur dans la base.");
                            Console.WriteLine("3 - Supprimer un utilisateur dans la base.");
                            int nbChoix = int.Parse(Console.ReadLine());

                            clearConsole();
                            Tuple<bool, string> VmResponse = new(false, "");
                            if (nbChoix == 1) //Cas ajout utilisateur
                            {
                                Dictionary<string, string> UserInfo = new();
                                string Nom = "";
                                while (!Nom.Contains(" "))
                                {
                                    Console.WriteLine("Merci de renseigner son nom et prénom (exemple : Gérard DUPONT) :");
                                    Nom = Console.ReadLine();
                                    if (!Nom.Contains(" "))
                                        ErrorMessage("Merci de respecter la casse : Prénom & ' ' & NOM.");
                                }
                                clearConsole();
                                UserInfo.Add("Identifiant", Nom.Substring(0, 1).ToLower() + "." + Nom.Split(" ")[1].ToLower() + "@hubert.com");
                                ConfirmationMessage("L'indentifiant associé est : " + Nom.Substring(0, 1).ToLower() + "." + Nom.Split(" ")[1].ToLower() + "@hubert.com");
                                UserInfo.Add("Nom", Nom);
                                string password1 = "";
                                string password2 = "_";
                                while (password1 != password2)
                                {
                                    Console.WriteLine("[1/2] Merci de renseigner le mot de passe choisi :");
                                    password1 = Console.ReadLine();
                                    Console.WriteLine("[2/2] Merci de confirmer le mot de passe choisi :");
                                    password2 = Console.ReadLine();
                                    if (password1 != password2)
                                        ErrorMessage("La confirmation du mot de passe a échouée. Veuillez ressayer.");
                                }
                                UserInfo.Add("Password", password1);
                                clearConsole();
                                Console.WriteLine("Merci de renseigner le code du role de l'utilisateur :");
                                Console.WriteLine("0 - Commercial");
                                Console.WriteLine("1 - Developpeur");
                                Console.WriteLine("2 - Technique");
                                Console.WriteLine("3 - DBManager");
                                UserInfo.Add("role", Console.ReadLine());
                                UserInfo.Add("createdBy", UserName);
                                UserInfo.Add("modifiedBy", UserName);
                                VmResponse = main.AddUser(UserInfo);
                                if (VmResponse.Item1 == false)
                                {
                                    ErrorMessage("Un utilisateur ayant le même identifiant est déclaré dans la base.");
                                    Console.WriteLine("Merci de modifier légérement l'identifiant, conformément à la politique de nomage. (p.nom@hubert.com)");
                                    Console.WriteLine(UserInfo["Identifiant"]);
                                    UserInfo["Identifiant"] = Console.ReadLine();
                                    clearConsole();
                                    VmResponse = main.AddUser(UserInfo);
                                }
                            }
                            else if (nbChoix == 2)
                            {
                                Console.WriteLine("Entrez un identifiant :");
                                string identifiant = Console.ReadLine();
                                int selectioned = 0;
                                List<List<string>> Data = main.FindUser(identifiant);
                                while (Data[0].Count > selectioned && selectioned >= 0)
                                {
                                    ConsoleTablePrint(Data);
                                    Console.WriteLine("Selectionnez la donnée a modifier : ");
                                    selectioned = Int32.Parse(Console.ReadLine());

                                }
                                Console.WriteLine("Entrez une nouvelle valeur pour ce choix: ");
                                VmResponse = main.ModifyUser(Console.ReadLine(), selectioned, Data, identifiant, UserName);
                            }
                            else
                            {
                                VmResponse = main.DeleteUser(Console.ReadLine());
                            }
                            ActionStatus(VmResponse);
                        }
                    }
                    else
                    {
                        ErrorMessage(LoginState.Item2);
                        Console.WriteLine("Merci de relancer l'application");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(V + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
            }
        }

        private static void ActionStatus(Tuple<bool, string> VmResponse)
        {
            if (VmResponse.Item1 == true)
                ConfirmationMessage(VmResponse.Item2);
            else
                ErrorMessage(VmResponse.Item2);
        }
        private static void clearConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Header);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            clearConsole();
        }
        private static void ConfirmationMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void ConsoleTablePrint(List<List<string>> BddData)
        {
        }*/
    }

}