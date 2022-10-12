# Unit Testing

Welcome to my unit testing training project!

This project contains the sample code of my unit testing training, which I recently summarized in an article I published on my blog

[An Introduction to Unit Testing](https://blog.fabioscagliola.com/an-introduction-to-unit-testing)

All the examples are written in C# using [NUnit](https://nunit.org)

# Setup

Please take the following steps in order to run the sample code on Ubuntu 22.04

Install [Git](https://git-scm.com) and clone this repository

```bash
sudo apt-get update
sudo apt-get install git
git config --global user.email "john.smith@example.com"
git config --global user.name "John Smith"
git clone https://github.com/fabioscagliola/Unit-Testing.git /some/folder
```

Install the [.NET SDK](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

```bash
sudo apt-get update
sudo apt-get install -y dotnet6
```

Download [Visual Studio Code](https://code.visualstudio.com) and install it

Launch Visual Studio Code

Install the following extension

```
Name: C#
Id: ms-dotnettools.csharp
Description: C# for Visual Studio Code (powered by OmniSharp).
Version: 1.24.4
Publisher: Microsoft
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
```

Click **File** and then **Open Folder...**

Select the folder where you cloned the repository

Click **Terminal** ant then **New Terminal**

Use the following command to run the unit tests

```bash
dotnet test
```

# Code samples

This section describes the examples included in the unit testing training project

## Unit testing example 1

The **UnitTesting01.cs** file includes two unit tests that verify the Boolean values returned by the `IsRedBloodCell` method of the `OpticalSensor` class.

## Unit testing example 2

The **UnitTesting02.cs** file introduces the use of the `TestCase` attribute to merge the two unit tests of example 1 into one test that verifies the Boolean values returned by the `IsRedBloodCell` method of the `OpticalSensor` class.

## Unit testing example 3

The **UnitTesting03.cs** file, in addition to what is sown in example 2, demonstrates how to test for an exception that may now be thrown by the `IsRedBloodCell` method of the `OpticalSensor` class.

## Unit testing example 4

All the previous files provide examples of value-based testing (checking the value returned by a method). The **UnitTesting04.cs** file provides an example of state-based testing (checking for noticeable behavior changes).

## Unit testing example 5

In the **UnitTesting05.cs** file, the `GoHome` method of the `PressController` class depends on some piece of hardware; the dependency is now simulated by throwing an exception; in such a scenario, unless we get rid of the dependency, the unit test can only verify that the exception is thrown.

## Unit testing example 6

In the **UnitTesting06.cs** file, the `IPressController` interface is extracted from the `PressController` class, and two stubs are introduced: the `PressControllerStub` class and the `PressControllerStubNotGoingHome` class, both implementing the `IPressController` interface; with minor adjustments to the `Extraction` class and to the unit tests, the code is now covered: we got rid of the dependency using the stubs; please note that we never make assertions against the stubs.

## Unit testing example 7

In the **UnitTesting07.cs** file, the `Open` method of the `ClampController` class depends on some piece of hardware; the dependency is now simulated by throwing an exception; in such a scenario, unless we get rid of the dependency, the unit test can only verify that the exception is thrown.

## Unit testing example 8

In the **UnitTesting08.cs** file, the `IClampController` interface is extracted from the `ClampController` class, and the `ClampControllerMock` class is introduced as a mock, implementing the `IClampController` interface; with minor adjustments to the `Extraction` class and to the unit test, the code is now covered: we got rid of the dependency using the mock; please note that we do make assertions against the mock. In this example the mock is injected using a constructor.

## Unit testing example 9

In this example the mock is injected using a method.

## Unit testing example 10

In this example the mock is injected using a property.

