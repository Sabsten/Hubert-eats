using Hubert_Eats_manager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace Hubert_Eats_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string otherUserName { get; set; }
        public string otherUserPassword { get; set; }
        public string otherUserPassword2 { get; set; }
        public string otherUserRole { get; set; }
        public string otherIdentifiant { get; set; }
        public List<List<string>> Data { get; set; }

        DataBaseManagerClass main = new();
        IdentificationClass credentials = new();
        Tuple<bool, string> LoginState;
        Tuple<bool, string> VmResponse = new(false, "");

        public MainWindow()
        {
            InitializeComponent();
            userName = "";
            userPassword = "";
            otherUserName = "";
            otherUserPassword = "";
            otherUserPassword2 = "";
            otherUserRole = "";
            otherIdentifiant = "";
            DataContext = this;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                Tuple<bool, string> LoginState = credentials.Login(userName.ToString(), userPassword.ToString());

                if (LoginState.Item1 == true)
                {
                    Resources["homeVisible"] = Visibility.Hidden;
                    Resources["pageSelection"] = Visibility.Visible;
                }else
                {
                    MessageBox.Show("Identification incorrect", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion survenue: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_AddUserSelection(object sender, RoutedEventArgs e)
        {
            Resources["pageSelection"] = Visibility.Hidden;
            Resources["addUserPage"] = Visibility.Visible;
        }

        private void Button_Click_EditUserSelection(object sender, RoutedEventArgs e)
        {
            Resources["pageSelection"] = Visibility.Hidden;
            Resources["editUserPage"] = Visibility.Visible;
        }

        private void Button_Click_RemoveUserSelection(object sender, RoutedEventArgs e)
        {
            Resources["pageSelection"] = Visibility.Hidden;
            Resources["removeUserPage"] = Visibility.Visible;
        }

        private void Button_Click_ConfirmUserCreation(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> UserInfo = new();
            if(!otherUserName.Contains(" ") || otherUserName == "")
            {
                MessageBox.Show("Merci de respecter la casse : Prénom NOM.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (otherUserPassword != otherUserPassword2 || otherUserPassword=="")
            {
                MessageBox.Show("La confirmation du mot de passe a échouée. Veuillez ressayer.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (otherUserRole == "")
            {
                MessageBox.Show("La sélection d'un rôle est nécessaire.", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                UserInfo.Add("Identifiant", otherUserName.Substring(0, 1).ToLower() + "." + otherUserName.Split(" ")[1].ToLower() + "@hubert.com");
                UserInfo.Add("Nom", otherUserName);
                UserInfo.Add("Password", otherUserPassword);
                UserInfo.Add("role", cmbRole.SelectionBoxItem.ToString());
                UserInfo.Add("createdBy", userName);
                UserInfo.Add("modifiedBy", userName);

                VmResponse = main.AddUser(UserInfo);
                while (VmResponse.Item1 == false)
                {
                    MessageBox.Show("Un utilisateur ayant le même identifiant est déclaré dans la base \n" +
                        "Merci de modifier légérement l'identifiant, conformément à la politique de nomage. (p.nom@hubert.com)", "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Console.WriteLine(UserInfo["Identifiant"]);
                    Window1 win1 = new Window1(UserInfo["Identifiant"]) ;
                    win1.ShowDialog();

                    UserInfo["Identifiant"] = win1.newOtherIdentifiant;
                    VmResponse = main.AddUser(UserInfo);
                }

                MessageBox.Show("L'indentifiant associé est : " + otherUserName.Substring(0, 1).ToLower() + "." + otherUserName.Split(" ")[1].ToLower() + "@hubert.com", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Resources["addUserPage"] = Visibility.Hidden;
                Resources["pageSelection"] = Visibility.Visible;
            }
        }

        private void Button_Click_ConfirmUserModification(object sender, RoutedEventArgs e)
        {
            //int selectioned = 0;
            Data = main.FindUser(otherIdentifiant);
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
            if(otherIdentifiant != "")
            {
                VmResponse = main.DeleteUser(otherIdentifiant);
            }
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
