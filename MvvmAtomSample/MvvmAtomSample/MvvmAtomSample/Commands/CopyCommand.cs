// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License

using System;
using System.Diagnostics;
using MvvmAtom;
using MvvmAtomSample.ViewModels;

namespace MvvmAtomSample
{
    /// <summary>
    /// Copy command, enabled when username has any value
    /// Execute, simply writes using Debug.Writeline
    /// </summary>
	public class CopyCommand : AtomCommandBase
	{
		public CopyCommand (AtomViewModelBase viewModel)
			: base(viewModel)
		{
		}

        /// <summary>
        /// Raise execute changed, if the property being changed is UserName
        /// </summary>
        /// <param name="propName"></param>
		public override void EvaluateCanExecuteChanged (string propName)
		{
			if(propName == nameof(MvvmAtomSampleMainViewModel.UserName))
			{
				RaiseCanExecuteChanged ();
			}
		}

        /// <summary>
        /// Validation that user name has at least one non-space character
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
		public override bool CanExecute (object parameter)
		{
			return !string.IsNullOrWhiteSpace (SampleViewModel.UserName?.Trim ());
		}

        /// <summary>
        /// Just make sure that it gets called
        /// </summary>
        /// <param name="parameter"></param>
		public override void Execute (object parameter)
		{
			Debug.WriteLine ("CopyCommand Executed");
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
