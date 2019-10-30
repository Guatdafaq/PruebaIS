using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Models
{
    /// <summary>
    /// Clase que sirve de modelo para los datos de los contactos
    /// </summary>
    public class Contact
    {
        #region [Variables]
        private string name;
        private string city;
        private string number;
        #endregion

        #region [Properties]
        /// <summary>
        /// Nombre del contacto
        /// </summary>
        public string Name { 
            
            get { return name; }
            set {
                name = value;
            }
        
        }
        /// <summary>
        /// Ciudad del contacto
        /// </summary>
        public string City
        {

            get { return city; }
            set
            {
                city = value;
            }

        }
        /// <summary>
        /// Número de teléfono del contacto
        /// </summary>
        public string Number
        {
            
            get { return number; }
            set
            {
                number = value;
            }

        }
        #endregion
    }
}
