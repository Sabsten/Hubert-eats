using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubert_Eats_manager.Model
{
    class MessageClass
    {
        //Cree une fonction qui renvoi un dictionnaire de messages de confirmation
        private static readonly Dictionary<string, string> ConfirmationMessages = new()
        {
            { "UserDeleted", "L'utilisateur a bien été supprimé de la base." },
            { "UserModified", "L'utilisateur a bien été Modifié de la base." },
            { "UserAdded", "L'utilisateur a bien été ajouté de la base."},

        };
        public static string GetConfirmationMessage(string key) => ConfirmationMessages[key];
   

        private static readonly Dictionary<string, string> ErrorMessages = new()
        {
            { "UserNotFound", "L'utilisateur n'existe pas dans la base. Merci de réessayer." },
            { "PasswordIncorrect", "Le mot de passe est incorrect. Merci de réessayer." },
            { "UserAlreadyExists", "L'utilisateur existe déjà." },
            { "UserNotDeleted", "L'utilisateur n'a pas pu être supprimé. Merci de contacter un administrateur." },
            { "UserNotModified", "L'utilisateur n'a pas pu être modifié. Merci de contacter un administrateur." },
            { "UserNotAdded", "L'utilisateur n'a pas pu être ajouté. Merci de contacter un administrateur." },
            { "UserNotAllowed","Utilisateur enregistré, mais n'a pas accès a Hubert-Eats Manager. Merci de contacter votre manager pour vous donner les droits." }
        };
        public static string GetErrorMessage(string key) => ErrorMessages[key];
    }
}
