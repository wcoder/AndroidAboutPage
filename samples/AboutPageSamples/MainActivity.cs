using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using AndroidAboutPage;

namespace AboutPageSamples
{
	[Activity(
		Label = "AboutPageSamples",
		MainLauncher = true,
		Icon = "@drawable/icon",
		Theme = "@style/AppTheme")]
	public class MainActivity : AppCompatActivity
	{
		// Original from:
		// https://github.com/medyo/android-about-page/blob/master/app/src/main/java/mehdi/sakout/aboutpage/sample/MainActivity.java
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Element versionElement = new Element { Title = "Version 6.2" };
			Element adsElement = new Element { Title = "Advertise with us" };

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

			SetContentView(aboutPage);
		}
	}
}

