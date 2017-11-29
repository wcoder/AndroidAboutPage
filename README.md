# AndroidAboutPage ![version](http://img.shields.io/badge/original-v1.2.1-brightgreen.svg?style=flat) [![NuGet Badge](https://buildstats.info/nuget/AndroidAboutPage)](https://www.nuget.org/packages/AndroidAboutPage/)

Port of [android-about-page](https://github.com/medyo/android-about-page) for Xamarin.Android

---

Create an awesome About Page for your Android App in 2 minutes

![Android About Page Cover](https://raw.githubusercontent.com/medyo/android-about-page/master/resources/cover.png)

This library allows to generate beautiful About Pages with less effort, it's fully customizable and supports opening specific intent

```csharp
View aboutPage = new AboutPage(this)
	.IsRtl(false)
	.SetImage(Resource.Drawable.dummy_image)
	.AddItem(versionElement)
	.AddItem(adsElement)
	.AddGroup("Connect with us")
	.AddEmail("elmehdi.sakout@gmail.com")
	.AddWebsite("http://wcoder.github.io/")
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

> Install-Package AndroidAboutPage

## Dependencies

* Xamarin.Android.Support.v7.AppCompat

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
| ------------- |:------------------|
| `string` Title | Set title of the element|
| `int` IconTint | Set color of the element|
| `int` IconDrawable | Set icon of the element|
| `string` Value | Set Element value like Facebook ID|
| `Intent` Intent | Set an intent to be called on `OnClick` |
| `GravityFlags` Gravity | Set a unique tag value to the element|
| `Action` ClickHandler | If `intent` isn't suitable for you need, implement your custom behaviour by overriding the click event |


## Sample Project
[sample](https://github.com/wcoder/AndroidAboutPage/tree/master/samples)

## Translations
The library does supports the following languages :

* English (default)
* German (by [vanniktech](https://github.com/vanniktech))
* Italian (by [greenaddress](https://github.com/greenaddress))
* Croatian (by [skmlcd](https://github.com/skmlcd))
* Arabic (by [zecharyah](https://github.com/zecharyah))
* Slovenian (by [skmlcd](https://github.com/skmlcd))
* Ukrainian (by [NumezmaT](https://github.com/NumezmaT))
* Russian (by [NumezmaT](https://github.com/NumezmaT))
* Romanian (by [Vally79](https://github.com/Vally79))
* Portuguese Brazil (by [rbaprado](https://github.com/rbaprado))
* French (by [medyo](https://github.com/medyo))
* Simplified Chinese (by [whiskeyfei](https://github.com/whiskeyfei))
* Spanish (by [danramirez](https://github.com/danramirez))
* Japanese (by [chibatching](https://github.com/chibatching))
* Turkish (by [tekseker](https://github.com/tekseker))
* Catalan (by [unxavi](https://github.com/unxavi))
* Czech (by [semanticer](https://github.com/semanticer))
* Hungarian (by [jbarat](https://github.com/jbarat))
* Korean (by [Alfex4936](https://github.com/Alfex4936))
* Swedish (by [Krillsson](https://github.com/Krillsson))
* Polish (by [karmil32](https://github.com/karmil32))
* Persian (by [mortezasun](https://github.com/mortezasun))
* Traditional Chinese (by [ppcrong](https://github.com/ppcrong))
* Serbian (by [ljmocic](https://github.com/ljmocic))
* Greek (by [jvoyatz](https://github.com/jvoyatz))
* Indian (by [kartikarora](https://github.com/kartikarora))

Please make a Pull request to add a new language.

## License

```
The MIT License (MIT)
Copyright (c) 2016 Mehdi Sakout, Yauheni Pakala

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```
