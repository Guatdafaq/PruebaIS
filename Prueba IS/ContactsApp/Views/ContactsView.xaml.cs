using ContactsApp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp.Views
{
    /// <summary>
    /// Lógica de interacción para ContactsView.xaml
    /// </summary>
    public partial class ContactsView : Page
    {
        public ContactsView()
        {

            ContactsViewModel contactsVM = new ContactsViewModel();
            DataContext = contactsVM;
            InitializeComponent();
        }
    }
}
