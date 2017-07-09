// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;
using System.Windows.Input;

using MvvmAtom;

namespace MvvmAtomSample.ViewModels
{
    /// <summary>
    /// Sample view model that hosts commands and properties
    /// </summary>
    public class MvvmAtomSampleMainViewModel : AtomViewModelBase
    {
        /// <summary>
        /// Constructor to initiate commands
        /// </summary>
        public MvvmAtomSampleMainViewModel()
        {
            CopyCommand = new CopyCommand(this);
            NavigateCommand = new NavigateCommand(this);
        }

        /// <summary>
        /// User name
        /// </summary>
        private string _userName;
        public String UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (!string.Equals(_userName, value))
                {
                    _userName = value;
                    // Just one call, the base view model class will notify commands
                    // So they can change their state as required
                    RaisePropertyChanged(); 
                }
            }
        }

        /// <summary>
        /// Password
        /// </summary>
        private string _password;
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (!string.Equals(_password, value))
                {
                    _password = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Another required field
        /// </summary>
        private string _required;
        public String Required
        {
            get
            {
                return _required;
            }

            set
            {
                if (!string.Equals(_required, value))
                {
                    _required = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Copy command
        /// </summary>
        public ICommand CopyCommand
        {
            get;
        }

        /// <summary>
        /// Navigate command
        /// </summary>
        public ICommand NavigateCommand
        {
            get;
        }

    }
}
