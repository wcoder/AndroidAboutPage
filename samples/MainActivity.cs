using Android.App;
using Android.Content.Res;
using Android.Icu.Util;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
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

			SimulateDayNight(/* DAY */ 2);

			var versionElement = new Element {Title = "Version 6.2" };
			var adsElement = new Element { Title = "Advertise with us" };

			var aboutPage = new AboutPage(this)
				.IsRtl(false)
				.SetImage(Resource.Drawable.dummy_image)
				.AddItem(versionElement)
				.AddItem(adsElement)
				.AddGroup("Connect with us")
				.AddEmail("elmehdi.sakout@gmail.com")
				.AddWebsite("http://wcoder.github.io/")
				.AddFacebook("the.medy")
				.AddTwitter("evgeniypakalo")
				.AddYoutube("UCdPQtdWIsg7_pi4mrRu46vA")
				.AddPlayStore("com.ideashower.readitlater.pro")
				.AddGitHub("wcoder")
				.AddInstagram("evgeniypakalo")
				.AddItem(GetCopyRightsElement())
				.Create();

			SetContentView(aboutPage);
		}

		private Element GetCopyRightsElement()
		{
			var copyrights = string.Format(GetString(Resource.String.copy_right), Calendar.Instance.Get(CalendarField.Year));

			return new Element
			{
				Title = copyrights,
				IconDrawable = Resource.Drawable.about_icon_copy_right,
				IconTint = Resource.Color.about_item_icon_color,
				IconNightTint = Android.Resource.Color.White,
				Gravity = GravityFlags.Center,
				ClickHandler = (sender, args) =>
				{
					Toast.MakeText(this, copyrights, ToastLength.Short).Show();
				}
			};
		}

		private void SimulateDayNight(int currentSetting)
		{
			const int day = 0;
			const int night = 1;
			const int followSystem = 3;

			var currentNightMode = Resources.Configuration.UiMode & UiMode.NightMask;

			if (currentSetting == day && currentNightMode != UiMode.NightNo)
			{
				AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
			}
			else if (currentSetting == night && currentNightMode != UiMode.NightYes)
			{
				AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightYes;
			}
			else if (currentSetting == followSystem)
			{
				AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightFollowSystem;
			}
		}
	}
}

