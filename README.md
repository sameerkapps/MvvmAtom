# Develop MVVM Mobile Apps faster with MvvmAtom
Writing MVVM framework yourself can take longer due to the learning curve and efforts to write it from the scratch. Available frameworks are large in size and there is a learning curve to learn them.

MvvmAtom provides the middle ground by providing the base classes and wiring for most commonly used MVVM features. That results in a short learning curve with quicker development. Having fewer layers would make it more responsive.

Apart from the above, MvvmAtom provides a unique feature that enables a command to enable/disable itself when a property change occurs in the view model. This avoids having view model track relation between a property and the command(s) that may get affected due to change in its value. It provides clearer centralized decision making in commands rather than sparsely structured decision making in the view model.

MvvmAtom classes and interfaces are explained here in brief:

**AtomViewModelBase**

This is a base view model class that provides an implementation of the INotifyPropertyChanged interface. 

**AtomCommandBase**

This is the base class for commands. This stores the parent view model as a member. So it is accessible during the lifetime. Any property change in the view model will be notified to the command. It will enable commands to take appropriate action(s).

**IAtomNavigationService**

A view model should be able to navigate to another view model using this interface. The underlying app must implement the navigation interface to launch the appropriate page and bind new view model to it.

The MvvmAtomSample shows how to use this package. 

My blog has the details about this library:

https://sameer.blog/2017/07/09/develop-mvvm-mobile-apps-faster-with-mvvmatom/

The NuGet package can be found here:

https://www.nuget.org/packages/MvvmAtom/1.0.0


