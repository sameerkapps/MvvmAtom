// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License

using System;
using MvvmAtom;

namespace MvvmAtomSample.ViewModels
{
    /// <summary>
    /// Navigate to another screen when all the required fields
    /// have values
    /// </summary>
	public class NavigateCommand : AtomCommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel"></param>
		public NavigateCommand (AtomViewModelBase viewModel)
			: base(viewModel)
		{
		}

        /// <summary>
        /// Evaluate if any property of interest has changed
        /// </summary>
        /// <param name="propName"></param>
		public override void EvaluateCanExecuteChanged (string propName)
		{
			if (propName == nameof (MvvmAtomSampleMainViewModel.UserName) ||
			    propName == nameof (MvvmAtomSampleMainViewModel.Password) ||
			    propName == nameof (MvvmAtomSampleMainViewModel.Required)) 
			{
				RaiseCanExecuteChanged ();
			}
		}

        /// <summary>
        /// Check, if ready to navigate or not
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
		public override bool CanExecute (object parameter)
		{
			return !string.IsNullOrWhiteSpace (SampleViewModel.UserName?.Trim ()) &&
				          !string.IsNullOrWhiteSpace(SampleViewModel.Password) &&
				          !string.IsNullOrWhiteSpace(SampleViewModel.Required?.Trim());
		}

        /// <summary>
        /// Ask NavigationService to navigate to the next view model
        /// </summary>
        /// <param name="parameter"></param>
		public override void Execute (object parameter)
		{
            AtomViewModelBase.NavigationService.NavigateTo(this, typeof(SecondPageViewModel));
		}

        /// <summary>
        /// Avoid casting at other places.
        /// </summary>
        private MvvmAtomSampleMainViewModel SampleViewModel 
		{
			get 
			{
				return (MvvmAtomSampleMainViewModel)ViewModel;
			}
		}
	}
}
