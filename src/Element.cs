using Android.Content;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 6/14/17.
	 */
	public class Element
	{
		public string Title { get; set; }
		public int IconDrawable { get; set; }
		public int IconTint { get; set; }
		public int IconNightTint { get; set; }
		public string Value { get; set; }
		public Intent Intent { get; set; }
		public int Gravity { get; set; }
		public bool AutoApplyIconTint { get; set; } = true;

		public Element()
		{
		}

		public Element(string title, int iconDrawable)
		{
			Title = title;
			IconDrawable = iconDrawable;
		}
	}
}