// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;
using System.Windows.Input;

namespace MvvmAtom
{
    public interface IAtomCommandBase : ICommand
    {
		/// <summary>
		/// Raises the can execute changed event
		/// </summary>
		/// <param name="e">E.</param>        
		void RaiseCanExecuteChanged(EventArgs e = null);

		/// <summary>
		/// ViewModel is provided for access to its properties
		/// </summary>
		/// <value>The view model.</value>
		AtomViewModelBase ViewModel
		{
			get;
		}

        /// <summary>
        /// This is called when any property on the View Model changes
        /// Derived class can evaluate, if this command should change CanExecute state
        /// </summary>
        /// <param name="propName">Property name.</param>
        void EvaluateCanExecuteChanged(string propName);
    }
}
