using Android.Content;
using Android.Content.PM;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 5/1/16.
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
	}
}