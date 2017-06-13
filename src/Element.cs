using System;
using Android.Content;
using Android.Views;

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
		public GravityFlags Gravity { get; set; } = GravityFlags.NoGravity;
		public bool AutoApplyIconTint { get; set; } = true;
		public EventHandler ClickHandler { get; set; }

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