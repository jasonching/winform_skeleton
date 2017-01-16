# Winform Skeleton

# MVP

## The View
Take the NumGenForm as an example.  The NumGenForm.cs is the view layer, which is a typical win form class.  This class is abstracted from the presenter by implementing INumGenView interface.
```
internal partial class NumGenForm : Form, INumGenView
{
```

## The Presenter
The presenter access the view by referencing the interface only.  Be notice that all core logic is done in the Engine.  The role of the presenter is to handle the behavior of the view, not the core logic.

```
public class NumGenPresenter : IPresenter
{
	public INumGenView Form { get; set; }
	public NumGenEngine NumGenEngine { get; set; }
```

## The Engine
This is where the core logic goes.  To make sure this class has nothing to do with the presentation layer, I have put it into a seperate project MyApp.Engine.  This is a standard library project that has no presentation logic at all.  Ideally, you don't have to change anything here if you decide to change the whole application to web tomorrow.

# IoC
If you are not using IoC, you are not a good C# developer.  Just like Java developer not using Spring.  What IoC gives you is a single place to handle all the object association and life cycle management.  It keeps your code clean.  And it helps you to management objects in a controllable way.  And it brings your interface abstraction into a whole new level.  It makes unit testing a lot easier.  And no more the [ugly Singleton implementation](https://msdn.microsoft.com/en-us/library/ff650316.aspx)!

In this project, there are 2 Bootstrapper files under MyApp.WinForm.Windsor.Bootstrapper.  All the object wiring are done there.  We are keeping the ViewBootstrapper seperate becuase we are going to use a TestContainerBootstrapper to creating mocking views when we are running unit test.

I choose [Castle Windsor](http://www.castleproject.org/projects/windsor/) because it is the most common choice and I don't see anything wrong with it.

[Ninject](http://www.ninject.org/) is good also.  You can think about it.

See how the magic works in LauncherPresenter
```   
private void LaunchNumGenForm()
{
    var numGenPresenter = GlobalContainerAccessor.Instance.Container.Resolve<NumGenPresenter>();
    numGenPresenter.Show(Form);
    }
}
```
This method create and launch the NumGen Form when user clicks on the launch button.
Here we are calling Castle to resolve the NumGenPresenter object.  This object will have the whole stack of MVP objects hook into it, including the Form and the Engine.  It's all handled by the IoC framework in one line of code.

# Logging
log4net is used.  [Common.Logging] (https://github.com/net-commons/common-logging) is the wrapper on top.
The log4net configuration is done in log4net.config.  Check [here](https://logging.apache.org/log4net/release/manual/configuration.html) for all the options.

log4net reference is not required in MyApp.Engine project we are using it via Common.Logging.

To do logging, all you have to do is to define a global logger variable in the class.  The logger has provide all the standard logging functions you ever need.

```
public class NumGenEngine
{
    private static readonly ILog logger = LogManager.GetLogger(typeof(NumGenEngine));

    public int GenerateNumber()
    {
        logger.InfoFormat("Generating Number: {0}", number);
    }
}
```

I am not using Castle to hook up the logger object.  In the real world, you will not be creating all your object instances via Castle.  And that object you created by the 'new' keyword will have to log also.  Using this static pattern is way more flexible then relying on Castle.

# Testing
In C#, you have 2 choices of unit testing framework: NUnit, and MS Test.  I choose NUnit.

When you are doing test, you should keep the practice to put your test case in 3 sections: Given, When, Then.  Given a certain condition, when something happens, then verify the result.

The magic here is mocking.

We are using [Moq](https://github.com/Moq/moq4/wiki/Quickstart) here.  It's powerful and beautiful.  No other mocking framework can compare to it in C# world.

When mocking and the proper MVP pattern in place, you can verify your presenter and engine are working by stimulating how the view react via the mocking object.

See below example.  We stimulate a NumGen button click from the launcher view.  And we verify that the Show method is being invoked once from the NumGen view.

```
[Test]
public void LaunchNumGenFormTest()
{
    // Given
    var presenter = WindsorContainer.Resolve<LauncherPresenter>();

    // When
    MockObjectsProvider.MockLauncherView.Raise(
        v => v.NumGenButtonClick += null, 
        EventArgs.Empty);

    // Then
    MockObjectsProvider.MockNumGenView.Verify(
        v => v.Show(MockObjectsProvider.MockLauncherView.Object), 
        Times.Once, 
        "Show signal is not sent to the NumGenView");
}
