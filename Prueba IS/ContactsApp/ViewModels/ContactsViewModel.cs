using ContactsApp.Data;
using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactsApp.ViewModels
{
    /// <summary>
    /// Controla la lógica de la aplicación respecto a las operaciones con contactos
    /// </summary>
    public class ContactsViewModel : INotifyPropertyChanged
    {

        #region [Variables]
        private string searchCity;

        private ObservableCollection<Contact> searchedContacts;

        private ICommand searchCommand;
        private ICommand listCommand;
        #endregion

        #region [Properties]
        /// <summary>
        /// Almacena los contactos resultantes de las diferentes consultas
        /// </summary>
        public ObservableCollection<Contact> SearchedContacts
        {
            get { return this.searchedContacts; }
            set
            {
                if (!string.Equals(this.searchedContacts, value))
                {
                    this.searchedContacts = value;
                    OnPropertyChanged("SearchedContacts");
                }
            }
        }

        /// <summary>
        /// Almacena la ciudad por la que se va a buscar en una consulta
        /// </summary>
        public string SearchCity
        {
            get { return this.searchCity; }
            set
            {
                if (!string.Equals(this.searchedContacts, value))
                {
                    this.searchCity = value;
                    OnPropertyChanged("SearchCity");
                }
            }
        }
        #endregion

        #region [Constructors]
        /// <summary>
        /// Constructor de la clase ContactsViewModel
        /// </summary>
        public ContactsViewModel()
        {
            ContactsDB.InitializeContactsDB();

            SearchCommand = new CommandBase(param => SearchContacts());
            ListCommand = new CommandBase(param => ListContacts());
        }

        #endregion

        #region [Events]
        /// <summary>
        /// Manejador de eventos para propiedades de la clase
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Función que lanza la notificación al resto de la aplicación de que una propiedad ha cambiado su valor
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region [Methods]
        /// <summary>
        /// Comando para ejecutar una función de búsqueda
        /// </summary>
        public ICommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        /// <summary>
        /// Comando para ejecutar una función de listado
        /// </summary>
        public ICommand ListCommand
        {
            get { return listCommand; }
            set { listCommand = value; }
        }

        /// <summary>
        /// Función para buscar contactos en la base de datos
        /// </summary>
        private void SearchContacts()
        {
            SearchedContacts = new ObservableCollection<Contact>(ContactsDB.DictionaryContacts[SearchCity]);
        }

        /// <summary>
        /// Función para listar los contactos de la base de datos
        /// </summary>
        private void ListContacts()
        {
            SearchedContacts = new ObservableCollection<Contact>(ContactsDB.Contacts);
        }
        #endregion

    }
}
