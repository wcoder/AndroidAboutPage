using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 6/14/17.
	 */
	public static class AboutPageUtils
	{
		public static bool IsAppInstalled(Context context, string appName)
		{
			var pm = context.PackageManager;
			bool installed;
			try
			{
				pm.GetPackageInfo(appName, PackageInfoFlags.Activities);
				installed = true;
			}
			catch (PackageManager.NameNotFoundException)
			{
				installed = false;
			}
			return installed;
		}
		public static int GetThemeAccentColor(Context context)
		{
			int colorAttr;
			if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
			{
				colorAttr = Android.Resource.Attribute.ColorAccent;
			}
			else
			{
				//Get colorAccent defined for AppCompat
				colorAttr = context.Resources.GetIdentifier("colorAccent", "attr", context.PackageName);
			}
			var outValue = new TypedValue();
			context.Theme.ResolveAttribute(colorAttr, outValue, true);
			return outValue.Data;
		}
	}
}