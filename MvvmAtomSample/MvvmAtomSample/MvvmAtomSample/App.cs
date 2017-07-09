// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;

using Xamarin.Forms;

using MvvmAtomSample.Views;
using MvvmAtomSample.ViewModels;
using MvvmAtom;
using MvvmAtomSample.NavigationService;

namespace MvvmAtomSample
{
    public class App : Application
    {
        public App()
        {
            // Make sure that you initialize the navigation service
            AtomViewModelBase.NavigationService = new SampleNavigationService();

            // Create main page and its view model
            var content = new MvvmAtomSampleMainPage();
            content.BindingContext = new MvvmAtomSampleMainViewModel();

            // The root page of your application
            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
