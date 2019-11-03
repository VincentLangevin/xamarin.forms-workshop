# Xamarin.Forms - Hands On Lab

Today we will build a cloud connected [Xamarin.Forms](https://docs.microsoft.com/xamarin/) application that will display a list of Monkeys from around the world. We will start by building the business logic backend that pulls down json-ecoded data from a RESTful endpoint. We will then leverage [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/index?WT.mc_id=docs-workshop-jamont) to find the closest monkey to us and also show the monkey on a map.

## Setup Guide
Follow our simple [setup guide](https://docs.microsoft.com/xamarin/get-started/installation/index?WT.mc_id=docs-workshop-jamont) to ensure you have Visual Studio 2019 and Xamarin setup and ready to deploy.

Hey there! James here from the Xamarin team at Microsoft. I am so excited to have you as part of PRE13 - Build your first iOS & Android app with C#, Xamarin, and Azure Workshop at Ignite! This workshop will be hands on and a bring your own device workshop. You can develop on PC or Mac and all you will need to do is install Visual Studio 2019 or Visual Studio for Mac 2019 with the Xamarin workload.

Before the conference I recommend going through the quick 10 minute [Xamarin Tutorial](https://dotnet.microsoft.com/learn/xamarin/hello-world-tutorial/intro) that will guide you through installation and also ensuring everything is configured correct.

If you are new to mobile development, we recommend deploying to a physical Android device which can be setup in just a few steps. If you don't have a device, don't worry as you can setup an [Android emulator with hardware acceleration](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/). If you don't have time to set this up ahead of time, don't worry as we are here to help during the workshop.

Beyond that you will be good to go for the workshop! If you have some spare time we have prepared a full Xamarin 101 series to cover the basics of mobile development with .NET.

I have also put together an abstract of what you can expect for the day long workshop:

    - 30 Min Session - Introduction to Xamarin Session & Setup Help
    - Single Page List of Data
    - MVVM & Data Binding
    - Navigation
    - Platform Specific Optimizations
    - Application Resources
    - 30 Min Session - Introduction to App Center
    - Integrating Data Services
    - Adding Azure Functions for Data
    - User Specific Data
    - Analytics, Crash reporting, and more

If you have any questions please email me at [motz@microsoft.com](mailto:motz@microsoft.com) or reach out to me on Twitter @JamesMontemagno. 

### iOS Debugging

In order to build and debug an iOS device you need a MAC:

    1. A physical MAC on your network (using the same subnet) OR
    2. A provisioned MAC machine in the cloud [macincloud](http://www.macincloud.com). 

Visual Studio has a simulator which will tunnel to your MAC device to build the app and then run the emulator, Visual Studio does a screen share using the TLS tunnel to communicate quickly.

### MVVVM Helpers 

[MVVM Helpers](https://github.com/jamesmontemagno/mvvm-helpers) includes a ObservableRangeCollection to allow adding, removing, and replacing a range of items to which will raise a single colleciton changed notification. Ideal if you are dealing with thousands of items to bind to for the UI.

### Xamarin Essentials

Micorosft created an abstraction layer to access all the common hardware features and native platform features across all platforms (ie GPS, SMS, File Storage, etc).  Xamarin Essentials is optimized so that at compile time the linker will only include the API/Libraries that are actually used by your code so you have a slim run-time as a result.

[Xamarin Essentials Documentation](https://docs.microsoft.com/en-us/xamarin/essentials/)

### Data Template Selectors

For a control that can display a heterogenus collection (different models like a monkey, dog, or cat) and each one has their own view, you can create a DataTemplateSelector to help the UI display the correct view for the data type.

### Xamarin Components

[Xamarin Components](https://github.com/xamarin/XamarinComponents) 

### AppCenter

Handles Cross Cutting concerns in a single API.  For example, accessing data from AzureCosmosDB takes two lines of code, is strongly typed, and the API handles the authentication required.