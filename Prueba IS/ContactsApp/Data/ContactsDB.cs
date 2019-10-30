using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data
{
    /// <summary>
    /// Clase que almacenará los datos de los contactos
    /// </summary>
    public static class ContactsDB
    {
        #region [Properties]
        /// <summary>
        /// Lista en la que están guardados los datos referentes a los contactos
        /// </summary>
        public static List<Contact> Contacts;

        /// <summary>
        /// Diccionario en el que están guardados los datos referentes a los contactos
        /// </summary>
        public static Dictionary<string, List<Contact>> DictionaryContacts;

        #endregion

        #region [Methods]

        /// <summary>
        /// Inicializa la propiedad Contacts leyendo los datos del archivo csv
        /// </summary>
        public static void InitializeContactsDB()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Data", Properties.Resources.DataFile);
            Debug.Write(@path);
            Contacts = File.ReadLines(path)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { '|' }))
                .Select(n => new Contact
                {
                    Name = n[0],
                    City = n[1],
                    Number = n[2]
                }).ToList();

            DictionaryContacts = Contacts.GroupBy(x => x.City).ToDictionary(x => x.Key, x => x.ToList());
        }
        #endregion      
    }
}
