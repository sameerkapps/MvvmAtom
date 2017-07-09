// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;

using MvvmAtom;
using MvvmAtomSample.ViewModels;
using MvvmAtomSample.Views;

namespace MvvmAtomSample.NavigationService
{
    /// <summary>
    ///  This is a very rudimentary service done for demo.
    ///  You can write a better service than this. If you create a NuGet package /open source with
    ///  new service and are utilizing MvvmAtom package, please let me know.
    /// </summary>
    internal class SampleNavigationService : MvvmAtom.IAtomNavigationService
    {
        /// <summary>
        /// Implementation of navigation. This is specific to Xamarin.Forms
        /// </summary>
        /// <param name="sender">Caller</param>
        /// <param name="newModel">Type of the target view model</param>
        public void NavigateTo(object sender, Type newModel)
        {
            // if the target is SecondPageViewModel
            // create that page, bonding and navigate to it
            if (newModel == typeof(SecondPageViewModel))
            {
                var callerVM = ((MvvmAtomSampleMainViewModel)((AtomCommandBase)sender).ViewModel);
                var vm = new SecondPageViewModel();
                vm.UserName = callerVM.UserName;
                var page = new SecondPage() { BindingContext = vm };

                App.Current.MainPage.Navigation.PushAsync(page);
            }
            else // Just show a message box
            {
                var callerVM = ((SecondPageViewModel)((AtomCommandBase)sender).ViewModel);
                App.Current.MainPage.DisplayAlert("Demo message box", $"Thanks for watching this Demo - {callerVM.UserName}!", "OK");
            }
        }
    }
}
