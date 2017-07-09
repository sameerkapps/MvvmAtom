// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License.

using System;

namespace MvvmAtom
{
	/// <summary>
	/// This provides centralized mechanism to evaluate if change in the state is required
	/// based on the change in the properties in the view model.
	/// e.g this can help evaluate CanExecute based on multiple properties. 
	/// This also provides functionality to raise CanExecuteChanged notification. 
    /// It provides access to the ViewModel that hosts the command. It enables commands to access properties 
    /// in the view model.
	/// </summary>
	public abstract class AtomCommandBase : IAtomCommandBase
    {
        /// <summary>
        /// Constructor optionally accepting view model
        /// </summary>
        /// <param name="viewModel">View model.</param>
        public AtomCommandBase(AtomViewModelBase viewModel = null, bool registerPropChange = true)
        {
            // view model can be null if not used
            ViewModel = viewModel;
            if (registerPropChange)
            {
                ViewModel?.AddPropertyChangeListener(this);
            }
        }

        /// <summary>
        /// Raised when CanExecute changes
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// To be implemented by the derived class
        /// </summary>
        /// <returns></returns>
        /// <param name="parameter">Parameter.</param>
        public virtual bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To be implemented by the derived class
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="parameter">Parameter.</param>
        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises the can execute changed event
        /// </summary>
        /// <param name="e">E.</param>
        public virtual void RaiseCanExecuteChanged(EventArgs e = null)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        /// <summary>
        /// ViewModel is provided for access to its properties
        /// </summary>
        /// <value>The view model.</value>
        public AtomViewModelBase ViewModel
        {
            get;
        }

        /// <summary>
        /// This is called when any property on the View Model changes
        /// Derived class can evaluate, if this command should change CanExecute state
        /// </summary>
        /// <param name="propName">Property name.</param>
        public virtual void EvaluateCanExecuteChanged(string propName)
        {
            // A property has changed in the view model
            // evaluate, if CanExecute needs to change
        }
    }
}
