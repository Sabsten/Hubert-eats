using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;

namespace Hubert_Eats_manager.View
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    {
        public string newOtherIdentifiant { get; set; }
        public string otherIdentifiant { get; set; }
        public string UserInfo { get; set; }

        Tuple<bool, string> VmResponse = new(false, "");
        public Window1(string otherIdentifiant)
        {
            InitializeComponent();
            this.newOtherIdentifiant = "";
            this.otherIdentifiant = otherIdentifiant;
        }

        private void Button_Click_ConfirmUserModification(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
