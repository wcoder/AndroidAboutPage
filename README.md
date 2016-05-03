# AndroidAboutPage ![version](http://img.shields.io/badge/original-v1.0.5-brightgreen.svg?style=flat) [![NuGet](https://img.shields.io/nuget/v/FB2Library.svg?label=NuGet)](https://www.nuget.org/packages/AndroidAboutPage/)

Port of [android-about-page](https://github.com/medyo/android-about-page) for Xamarin.Android

---

Create an awesome About Page for your Android App in 2 minutes

![Android About Page Cover](https://raw.githubusercontent.com/medyo/android-about-page/master/resources/cover.png)

This library allows to generate beautiful About Pages with less effort, it's fully customizable and supports opening specific intent

```csharp
View aboutPage = new AboutPage(this)
	.IsRTL(false)
	.SetImage(Resource.Drawable.dummy_image)
	.AddItem(versionElement)
	.AddItem(adsElement)
	.AddGroup("Connect with us")
	.AddEmail("elmehdi.sakout@gmail.com")
	.AddWebsite("http://medyo.github.io/")
	.AddFacebook("the.medy")
	.AddTwitter("medyo80")
	.AddYoutube("UCdPQtdWIsg7_pi4mrRu46vA")
	.AddPlayStore("com.ideashower.readitlater.pro")
	.AddGitHub("medyo")
	.AddInstagram("medyo80")
	.Create();
```

## Setup

Grab the latest version from NuGet

> PM Install-Package AndroidAboutPage

## Dependencies

* Xamarin.Android.Support.v4
* Xamarin.Android.Support.v7.AppCompat
* Xamarin.Android.Support.Vector.Drawable
* Xamarin.Android.Support.Animated.Vector.Drawable

## Usage
### 1. Add Description

```csharp
SetDescription(string)
```

### 2. Add Image
```csharp
SetImage(int)
```

### 3. Add predefined Social network
The library has already some predefined social networks like :  

* Facebook
* Twitter
* Instagram
* Youtube
* PlayStore

```csharp
AddFacebook(string PageID)
AddTwitter(string AccountID)
AddYoutube(string AccountID)
AddPlayStore(string PackageName)
AddInstagram(string AccountID)
AddGitHub(string AccountID)
```

### 4. Add Custom Element
For example `app version` :

```csharp
Element versionElement = new Element();
versionElement.Title = "Version 6.2";
AddItem(versionElement)
```

### 5. Available attributes for Element Class

| Function        | Description  |
| ------------- |:-------------:| -----:|
| string Title | Set title of the element|
| int Color | Set color of the element|
| int Icon | Set icon of the element|
| string Value | Set Element value like Facebook ID|
| string Tag | Set a unique tag value to the element|
| Intent Intent | Set an intent to be called on `OnClick` |


## Sample Project
[sample](https://github.com/wcoder/AndroidAboutPage/tree/master/samples)


## License

```
The MIT License (MIT)
Copyright (c) 2016 Mehdi Sakout, Yauheni Pakala

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```
