// Copyright (c) 2017 Sameer Khandekar
// Provided as is with MIT License
using System;
namespace MvvmAtom
{
    /// <summary>
    /// This encapsulates navigation at the view model layer
    /// providing ability for a view model to launch the next screen
    /// Avoiding any dependency on the underlying framework.
    /// Underlying platform should implement it to provide mapping between
    /// view model and the page
    /// </summary>
    public interface IAtomNavigationService
    {
        void NavigateTo(object sender, Type newModel);
    }
}
