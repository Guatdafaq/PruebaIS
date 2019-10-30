using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactsApp.ViewModels
{
    /// <summary>
    /// Clase base para manejar los comandos simples de la aplicación
    /// </summary>
    public class CommandBase : ICommand
    {

        #region [Variables]
        private Action<object> execAction;
        private Func<object, bool> canExecFunc;
        #endregion

        #region [Constructors]
        /// <summary>
        /// Constructor de la clase CommandBase
        /// </summary>
        /// <param name="execAction">Nombre de la función a ejecutar</param>
        public CommandBase(Action<object> execAction)
        {
            this.execAction = execAction;
            this.canExecFunc = null;
        }

        /// <summary>
        /// Constructor de la clase CommandBase
        /// </summary>
        /// <param name="execAction">Nombre de la función a ejecutar</param>
        /// <param name="canExecFunc">Determina si se ejecuta o no la acción</param>
        public CommandBase(Action<object> execAction, Func<object, bool> canExecFunc)
        {
            this.execAction = execAction;
            this.canExecFunc = canExecFunc;
        }
        #endregion

        #region [Methods]
        /// <summary>
        /// Comprueba si se puede realizar la acción
        /// </summary>
        /// <param name="parameter">Función a ejecutar</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (canExecFunc != null)
            {
                return canExecFunc.Invoke(parameter);
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region [Events]
        /// <summary>
        /// Notifica que la posibilidad de ejecución ha cambiado
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Ejecuta la acción
        /// </summary>
        /// <param name="parameter">Acción a ejecutar</param>
        public void Execute(object parameter)
        {
            if (execAction != null)
            {
                execAction.Invoke(parameter);
            }
        }
        #endregion

    }
}
