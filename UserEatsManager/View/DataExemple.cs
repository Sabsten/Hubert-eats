using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Common;
using System.Data;
using System.Threading;
using ConsoleTables;
using MySql.Data.MySqlClient;
using ViewModel;

namespace View
{
    class MainProgram
    {
        private const string V = "Error: ";
        public const string Header = @"
                                            __  __      __              __                __      
                                           / / / /_  __/ /_  ___  _____/ /_   ___  ____ _/ /______
                                          / /_/ / / / / __ \/ _ \/ ___/ __/  / _ \/ __ `/ __/ ___/
                                         / __  / /_/ / /_/ /  __/ /  / /_   /  __/ /_/ / /_(__  ) 
                                        /_/ /_/\__,_/_.___/\___/_/   \__/   \___/\__,_/\__/____/  
                                        ";

        static void Main(string[] args)
        {
            // Étabilissez de la connexion à la base de données. 
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            try
            {
                while (true)
                {
                    Console.Title = "HEIUD";
                    clearConsole();
                    IdentificationClass credentials = new();
                    bool LoginState = credentials.Login();
                    if (LoginState == true)
                    {
                        clearConsole();
                        Console.WriteLine("Connection reussie.");
                        Program main = new();
                        while (true)
                        {
                            Console.WriteLine("Que souhaitez vous faire ? Tapez le code correspondant.");
                            Console.WriteLine("1 - Ajouter un utilisateur dans la base.");
                            Console.WriteLine("2 - Modifier un utilisateur dans la base.");
                            Console.WriteLine("3 - Supprimer un utilisateur dans la base.");
                            int nbChoix = int.Parse(Console.ReadLine());

                            clearConsole();
                            Tuple<bool, string> VmResponse = new(false, "");
                            if (nbChoix == 1)
                            {
                                Dictionary<string, string> UserInfo = new();
                                bool NomFormat = false;
                                string Nom = "";
                                while (NomFormat == false)
                                {
                                    Console.WriteLine("Merci de renseigner son nom et prénom (exemple : Gérard DUPONT) :");
                                    Nom = Console.ReadLine();
                                    if (Nom.IndexOf(" ") == -1)
                                    {
                                        ErrorMessage("Merci de respecter la casse : Prénom & ' ' & NOM.");
                                    }
                                    else
                                        NomFormat = false;
                                }
                                clearConsole();
                                UserInfo.Add("Identifiant", Nom.Substring(0, 1).ToLower() + "." + Nom.Split(" ")[1].ToLower() + "@hubert.com");
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
                                    {
                                        ErrorMessage("La confirmation du mot de passe a échouée. Veuillez ressayer.");
                                    }
                                }
                                UserInfo.Add("password", password1);
                                clearConsole();
                                Console.WriteLine("Merci de renseigner le code du role de l'utilisateur :");
                                Console.WriteLine("0 - Commercial");
                                Console.WriteLine("1 - Developpeur");
                                Console.WriteLine("2 - Technique");
                                Console.WriteLine("3 - DBManager");
                                UserInfo.Add("role", Console.ReadLine());
                                VmResponse = main.addUser(UserInfo);
                                if (VmResponse.Item2 == "Existing User")
                                {
                                    ErrorMessage("Un utilisateur ayant le même identifiant est déclaré dans la base.");
                                    Console.WriteLine("Merci de modifier légérement l'identifiant, conformément a la politique de nomage. (p.nom@hubert.com)");
                                    Console.WriteLine(UserInfo["Identifiant"]);
                                    UserInfo["Identifiant"] = Console.ReadLine();
                                    VmResponse = main.addUser(UserInfo);
                                }
                            }
                            else if (nbChoix == 2)
                            {
                                Console.WriteLine("Entrez un identifiant :");
                                string identifiant = Console.ReadLine();
                                List<Tuple<string, string, string, string, string>> Data = main.FindUser(identifiant);
                                ConsoleTablePrint(Data);
                                Console.WriteLine("------------");
                                Console.WriteLine("Selectionnez la donnée a modifier : ");
                                int selectioned = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Entrez une nouvelle valeur pour ce choix: ");
                                VmResponse = main.modifyUser(Console.ReadLine(), Data[0].Console.ReadLine(), identifiant);
                                string a = Data[0].Item3;
                            }
                            else
                            {
                                VmResponse = main.deleteUser(Console.ReadLine());
                            }
                            ActionStatus(VmResponse);
                        }
                    }
                    else
                    {

                        Console.WriteLine("Mauvais identifiants ou personne n'ayant pas les droits.");
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
                connection.Close();
                connection.Dispose();
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
        private static void ConsoleTablePrint(List<Tuple<string, string, string, string, string>> BddData)
        {
            ConsoleTable tables = new ConsoleTable("UserID", "Identifiant", "Prénom Nom", "Password", "Role");
            foreach (var Item in BddData)
            {
                tables.AddRow(Item.Item1, Item.Item2, Item.Item3, Item.Item4, Item.Item5);
            }
            tables.Write();
            Console.WriteLine();
        }
    }
}