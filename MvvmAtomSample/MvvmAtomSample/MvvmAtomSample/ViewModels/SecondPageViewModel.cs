// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License

using System;
using System.Windows.Input;

using MvvmAtom;
using MvvmAtomSample.Commands;

namespace MvvmAtomSample.ViewModels
{
    /// <summary>
    /// View model to display name and
    /// Host command that shows message box
    /// </summary>
    public class SecondPageViewModel : AtomViewModelBase
    {
        /// <summary>
        /// Constructor initializes the command
        /// </summary>
        public SecondPageViewModel()
        {
            MessageCommand = new MessageCommand(this);
        }

        /// <summary>
        /// UserName field
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Command to launch alert
        /// </summary>
        public ICommand MessageCommand { get; }
    }
}
