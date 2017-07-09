// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License

using System;

using MvvmAtom;

namespace MvvmAtomSample.Commands
{
    /// <summary>
    /// Command to display messagebox
    /// </summary>
    public class MessageCommand : AtomCommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public MessageCommand(AtomViewModelBase viewModel)
            : base(viewModel)
        {
        }

        /// <summary>
        /// Can execute anytime
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Perfoms navigation using Navigation Service
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            AtomViewModelBase.NavigationService.NavigateTo(this, null);
        }
    }
}
