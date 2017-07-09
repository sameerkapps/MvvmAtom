// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmAtom
{
    /// <summary>
    /// Base view model provides mechanism to notify registered commands when any property changes.
    /// Also standard mplementation to notify property change
    /// Virtual methods to take actions when screen appears and disappears
    /// </summary>
    public abstract class AtomViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Navigation service common to the App
        /// If view model plans to use it, it should be set up
        /// prior to use
        /// </summary>
        public static IAtomNavigationService NavigationService
        {
            get;
            set;
        }

        /// <summary>
        /// Registers a command to listen to any property change
        /// </summary>
        /// <param name="cmd">Cmd.</param>
        public void AddPropertyChangeListener(IAtomCommandBase cmd)
        {
            // validate the argument
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            // make sure that it is added only once
            var cmdHashCode = cmd.GetHashCode();
            foreach (var curr in Commands)
            {
                if (curr.GetHashCode() == cmdHashCode)
                {
                    return;
                }
            }

            // if it does not exist, add the command
            Commands.Add(cmd);
        }

        /// <summary>
        /// Removes command from property change listener
        /// </summary>
        /// <param name="cmd">Cmd.</param>
		public void RemovePropertyChangeListener(IAtomCommandBase cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            var cmdHashCode = cmd.GetHashCode();
            foreach (var curr in Commands)
            {
                if (curr.GetHashCode() == cmdHashCode)
                {
                    Commands.Remove(cmd);

                    break;
                }
            }
        }

        /// <summary>
        /// Called by page when page is appearing
        /// ViewModel can change actions accordingly e.g IsCameraOn = true;
        /// </summary>
        public virtual void OnAppearing()
        {

        }

        /// <summary>
        /// Called by page when page is disappearing
        /// ViewModel can change actions accordingly e.g IsCameraOn = false;
        /// </summary>
        public virtual void OnDisappearing()
        {

        }

        /// <summary>
        /// Property changed event is raised when property with the give name is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises Property changed event. If the caller does not specify the property name,
        /// Compiler automatically assigns the name of the caller.
        /// It also notifies the commands that are registered to listen to any property change.
        /// </summary>
        protected void RaisePropertyChanged([CallerMemberName]string propName = "")
        {
            // validation
            if (string.IsNullOrWhiteSpace(propName))
            {
                throw new ArgumentNullException(nameof(propName));
            }

            // invoke property change
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

            // notify all commands that are listening
            NotifyCommands(propName);
        }

        /// <summary>
        /// Notifies the commands that a property has changed
        /// </summary>
        /// <param name="propName">Property name.</param>
        protected void NotifyCommands(string propName)
        {
            if (_isListenerCreated)
            {
                foreach (var cmd in Commands)
                {
                    cmd.EvaluateCanExecuteChanged(propName);
                }
            }
        }

        List<IAtomCommandBase> _commands;

        bool _isListenerCreated = false;
        // This is lazy initialization, to save memory and perf issue
        // if not 
        private List<IAtomCommandBase> Commands
        {
            get
            {
                if(_commands == null)
                {
                    _commands = new List<IAtomCommandBase>();
                    _isListenerCreated = true;
                }

                return _commands;
            }
        }
    }
}
