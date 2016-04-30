using Android.Content;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 5/1/16.
	 */
	public class Element
	{
		public string Tag { get; set; }
		public string Title { get; set; }
		public int Icon { get; set; }
		public int Color { get; set; }
		public string Value { get; set; }
		public Intent Intent { get; set; }

		public Element()
		{
		}

		public Element(string tag, string title, int icon)
		{
			Tag = tag;
			Title = title;
			Icon = icon;
		}
	}
}