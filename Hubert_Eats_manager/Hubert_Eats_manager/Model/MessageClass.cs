using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubert_Eats_manager.Model
{
    public class ConfirmationMessageClass
    {
        //Cree une fonction qui renvoi un dictionnaire de messages de confirmation
        public static Dictionary<string, string> GetConfirmationMessage()
        {
            Dictionary<string, string> test = new();
            return test;
        }

    }         

    public class ErrorMessageClass
    {
        public Dictionary<string, string> ErrorMessages = new Dictionary<string, string>()
        {
            { "UserNotFound", "L'utilisateur n'existe pas" },
            { "UserAlreadyExists", "L'utilisateur existe déjà" },
            { "PasswordIncorrect", "Le mot de passe est incorrect" },
            { "PasswordTooShort", "Le mot de passe est trop court" },
            { "PasswordTooLong", "Le mot de passe est trop long" }
        };
    }
}
