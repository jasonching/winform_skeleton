# Winform Skeleton

This is a winform skeleton for making all below things working together with MVP pattern.
* Castle Windsor
* log4net
* Testing
 * NUnit
 * Moq

# MVP
Take the NumGenForm as an example.  The NumGenForm.cs is the view layer, which is a typical win form class.  This class is abstracted from the presenter by implementing INumGenView interface.
```
internal partial class NumGenForm : Form, INumGenView
{
```

