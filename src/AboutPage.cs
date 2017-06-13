using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Android.Content.PM;
using Android.Support.Graphics.Drawable;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V4.Widget;
using Android.Util;
using Orientation = Android.Widget.Orientation;
using Uri = Android.Net.Uri;
using Android.Content.Res;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 6/14/17.
	 */
	public class AboutPage
	{
		private readonly Context _mContext;
		private readonly LayoutInflater _mInflater;
		private string _mDescription;
		private int _mImage;
		private bool _mIsRtl;
		private Typeface _mCustomFont;
		private readonly View _mView;

		/// <summary>
		/// The AboutPage requires a context to perform it's functions. Give it a context associated to an
		/// Activity or a Fragment. To avoid memory leaks, don't pass a Context here. 
		/// </summary>
		/// <param name="context"></param>
		public AboutPage(Context context)
		{
			_mContext = context;
			_mInflater = LayoutInflater.From(context);
			_mView = _mInflater.Inflate(Resource.Layout.about_page, null);
		}

		/// <summary>
		/// Provide a valid path to a font here to use another font for the text inside this AboutPage
		/// </summary>
		/// <param name="fontName"></param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage SetCustomFont(string fontName)
		{
			_mCustomFont = Typeface.CreateFromAsset(_mContext.Assets, fontName);
			return this;
		}

		/// <summary>
		/// Convenience method for AddEmail(string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="email">the email address to send to</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddEmail(string email)
		{
			return AddEmail(email, _mContext.GetString(Resource.String.about_contact_us));
		}

		/// <summary>
		/// Add a predefined Element that opens the users default email client with a new email to the
		/// email address passed as parameter
		/// </summary>
		/// <param name="email">the email address to send to</param>
		/// <param name="title">the title string to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddEmail(string email, string title)
		{
			var intent = new Intent(Intent.ActionSend);
			intent.SetType("message/rfc822");
			intent.PutExtra(Intent.ExtraEmail, new[] { email });

			var element = new Element
			{
				Title = title,
				IconDrawable = Resource.Drawable.about_icon_email,
				IconTint = Resource.Color.about_item_icon_color,
				Intent = intent
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddFacebook(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the facebook id to display</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddFacebook(string id)
		{
			return AddFacebook(id, _mContext.GetString(Resource.String.about_facebook));
		}

		/// <summary>
		/// Add a predefined Element that the opens Facebook app with a deep link to the specified user id
		/// If the Facebook application is not installed this will open a web page instead.
		/// </summary>
		/// <param name="id">the id of the Facebook user to display in the Facebook app</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddFacebook(string id, string title)
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.AddCategory(Intent.CategoryBrowsable);

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.facebook.katana"))
			{
				intent.SetPackage("com.facebook.katana");
				int versionCode = 0;
				try
				{
					versionCode = _mContext.PackageManager.GetPackageInfo("com.facebook.katana", 0).VersionCode;
				}
				catch (PackageManager.NameNotFoundException e)
				{
					e.PrintStackTrace();
				}

				if (versionCode >= 3002850)
				{
					var uri = Uri.Parse($"fb://facewebmodal/f?href=http://m.facebook.com/{id}");
					intent.SetData(uri);
				}
				else
				{
					var uri = Uri.Parse($"fb://page/{id}");
					intent.SetData(uri);
				}
			}
			else
			{
				intent.SetData(Uri.Parse($"http://m.facebook.com/{id}"));
			}

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_facebook),
				IconDrawable = Resource.Drawable.about_icon_facebook,
				IconTint = Resource.Color.about_facebook_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddTwitter(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the Twitter id to display</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddTwitter(string id)
		{
			return AddTwitter(id, _mContext.GetString(Resource.String.about_twitter));
		}

		/// <summary>
		/// Add a predefined Element that the opens the Twitter app with a deep link to the specified user id
		/// If the Twitter application is not installed this will open a web page instead.
		/// </summary>
		/// <param name="id">the id of the Twitter user to display in the Twitter app</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddTwitter(string id, string title)
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.AddCategory(Intent.CategoryBrowsable);

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.twitter.android"))
			{
				intent.SetPackage("com.twitter.android");
				intent.SetData(Uri.Parse($"twitter://user?screen_name={id}"));
			}
			else
			{
				intent.SetData(Uri.Parse($"http://twitter.com/intent/user?screen_name={id}"));
			}

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_twitter),
				IconDrawable = Resource.Drawable.about_icon_twitter,
				IconTint = Resource.Color.about_twitter_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddPlayStore(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the package id of the app to display</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddPlayStore(string id)
		{
			return AddPlayStore(id, _mContext.GetString(Resource.String.about_play_store));
		}

		/// <summary>
		/// Add a predefined Element that the opens the PlayStore app with a deep link to the
		/// specified app application id.
		/// </summary>
		/// <param name="id">the package id of the app to display</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddPlayStore(string id, string title)
		{
			var uri = Uri.Parse("market://details?id=" + id);
			var intent = new Intent(Intent.ActionView, uri);

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_play_store),
				IconDrawable = Resource.Drawable.about_icon_google_play,
				IconTint = Resource.Color.about_play_store_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddYoutube(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the id of the channel to deep link to</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddYoutube(string id)
		{
			return AddYoutube(id, _mContext.GetString(Resource.String.about_youtube));
		}

		/// <summary>
		/// Add a predefined Element that the opens the Youtube app with a deep link to the
		/// specified channel id.
		/// If the Youtube app is not installed this will open the Youtube web page instead.
		/// </summary>
		/// <param name="id">the id of the channel to deep link to</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddYoutube(string id, string title)
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.SetData(Uri.Parse($"http://youtube.com/channel/{id}"));

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.google.android.youtube"))
			{
				intent.SetPackage("com.google.android.youtube");
			}

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_youtube),
				IconDrawable = Resource.Drawable.about_icon_youtube,
				IconTint = Resource.Color.about_youtube_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddInstagram(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the id of the instagram user to deep link to</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddInstagram(string id)
		{
			return AddInstagram(id, _mContext.GetString(Resource.String.about_instagram));
		}

		/// <summary>
		/// Add a predefined Element that the opens the Instagram app with a deep link to the
		/// specified user id.
		/// If the Instagram app is not installed this will open the Intagram web page instead.
		/// </summary>
		/// <param name="id">the user id to deep link to</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddInstagram(string id, string title)
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.SetData(Uri.Parse("http://instagram.com/_u/" + id));

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.instagram.android"))
			{
				intent.SetPackage("com.instagram.android");
			}

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_instagram),
				IconDrawable = Resource.Drawable.about_icon_instagram,
				IconTint = Resource.Color.about_instagram_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddGitHub(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="id">the id of the GitHub user to display</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddGitHub(string id)
		{
			return AddGitHub(id, _mContext.GetString(Resource.String.about_github));
		}

		/// <summary>
		/// Add a predefined Element that the opens the a browser and displays the specified GitHub
		/// users profile page.
		/// </summary>
		/// <param name="id">the GitHub user to link to</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddGitHub(string id, string title)
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.AddCategory(Intent.CategoryBrowsable);
			intent.SetData(Uri.Parse($"https://github.com/{id}"));

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_github),
				IconDrawable = Resource.Drawable.about_icon_github,
				IconTint = Resource.Color.about_github_color,
				Intent = intent,
				Value = id
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Convenience method for AddWebsite(string, string) but with
		/// a predefined title string
		/// </summary>
		/// <param name="url">the URL to open in a browser</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddWebsite(string url)
		{
			return AddWebsite(url, _mContext.GetString(Resource.String.about_website));
		}

		/// <summary>
		/// Add a predefined Element that the opens a browser and loads the specified URL
		/// </summary>
		/// <param name="url">the URL to open in a browser</param>
		/// <param name="title">the title to display on this item</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddWebsite(string url, string title)
		{
			if (!url.StartsWith("http://")
				&& !url.StartsWith("https://"))
			{
				url = "http://" + url;
			}

			var uri = Uri.Parse(url);
			var browserIntent = new Intent(Intent.ActionView, uri);

			var element = new Element
			{
				Title = _mContext.GetString(Resource.String.about_website),
				IconDrawable = Resource.Drawable.about_icon_link,
				IconTint = Resource.Color.about_item_icon_color,
				Intent = browserIntent,
				Value = url
			};

			AddItem(element);
			return this;
		}

		/// <summary>
		/// Add a custom Element to this AboutPage
		/// </summary>
		/// <param name="element"></param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddItem(Element element)
		{
			var wrapper = (LinearLayout)_mView.FindViewById(Resource.Id.about_providers);
			wrapper.AddView(CreateItem(element));
			wrapper.AddView(
				GetSeparator(),
				new ViewGroup.LayoutParams(
					ViewGroup.LayoutParams.MatchParent,
					_mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_separator_height)));
			return this;
		}

		/// <summary>
		/// Set the header image to display in this AboutPage
		/// </summary>
		/// <param name="resource">the resource id of the image to display</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage SetImage(int resource)
		{
			_mImage = resource;
			return this;
		}

		/// <summary>
		/// Add a new group that will display a header in this AboutPage
		/// A header will be displayed in the order it was added.
		/// </summary>
		/// <param name="name">the title for this group</param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage AddGroup(string name)
		{
			var textView = new TextView(_mContext);
			textView.Text = name;
			TextViewCompat.SetTextAppearance(textView, Resource.Style.about_groupTextAppearance);
			var textParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

			if (_mCustomFont != null)
			{
				textView.Typeface = _mCustomFont;
			}

			int padding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_group_text_padding);
			textView.SetPadding(padding, padding, padding, padding);

			if (_mIsRtl)
			{
				textView.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;
				textParams.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;
			}
			else
			{
				textView.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
				textParams.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
			}
			textView.LayoutParameters = textParams;

			((LinearLayout)_mView.FindViewById(Resource.Id.about_providers)).AddView(textView);
			return this;
		}

		/// <summary>
		/// Turn on the RTL mode.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>AboutPage instance for builder pattern support</returns>
		public AboutPage IsRtl(bool value)
		{
			_mIsRtl = value;
			return this;
		}

		public AboutPage SetDescription(string description)
		{
			_mDescription = description;
			return this;
		}

		/// <summary>
		/// Create and inflate this AboutPage. After this method is called the AboutPage
		/// cannot be customized any more.
		/// </summary>
		/// <returns>the inflated View of this AboutPage</returns>
		public View Create()
		{
			var description = (TextView)_mView.FindViewById(Resource.Id.description);
			var image = (ImageView)_mView.FindViewById(Resource.Id.image);
			if (_mImage > 0)
			{
				image.SetImageResource(_mImage);
			}

			if (!string.IsNullOrEmpty(_mDescription))
			{
				description.Text = _mDescription;
			}

			description.Gravity = GravityFlags.Center;

			if (_mCustomFont != null)
			{
				description.Typeface = _mCustomFont;
			}

			return _mView;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private View CreateItem(Element element)
		{
			var wrapper = new LinearLayout(_mContext);
			wrapper.Orientation = Orientation.Horizontal;
			wrapper.Clickable = true;

			if (element.ClickHandler != null)
			{
				wrapper.Click += element.ClickHandler;
			}
			else if (element.Intent != null)
			{
				wrapper.Click += (sender, args) =>
				{
					try
					{
						_mContext.StartActivity(element.Intent);
					}
					catch (Exception)
					{
						// ignored
					}
				};
			}

			var outValue = new TypedValue();
			_mContext.Theme.ResolveAttribute(Android.Resource.Attribute.SelectableItemBackground, outValue, true);
			wrapper.SetBackgroundResource(outValue.ResourceId);

			int padding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_text_padding);
			wrapper.SetPadding(padding, padding, padding, padding);
			var wrapperParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			wrapper.LayoutParameters = wrapperParams;

			var textView = new TextView(_mContext);
			TextViewCompat.SetTextAppearance(textView, Resource.Style.about_elementTextAppearance);
			var textParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			textView.LayoutParameters = textParams;
			if (_mCustomFont != null)
			{
				textView.Typeface = _mCustomFont;
			}

			ImageView iconView = null;

			if (element.IconDrawable != 0)
			{
				iconView = new ImageView(_mContext);
				int size = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_size);
				var iconParams = new LinearLayout.LayoutParams(size, size);
				iconView.LayoutParameters = iconParams;

				int iconPadding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_padding);
				iconView.SetPadding(iconPadding, 0, iconPadding, 0);

				if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
				{
					var drawable = VectorDrawableCompat.Create(iconView.Resources, element.IconDrawable, iconView.Context.Theme);
					iconView.SetImageDrawable(drawable);
				}
				else
				{
					iconView.SetImageResource(element.IconDrawable);
				}

				var wrappedDrawable = DrawableCompat.Wrap(iconView.Drawable);
				wrappedDrawable = wrappedDrawable.Mutate();

				if (element.AutoApplyIconTint)
				{
					// ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
					var currentNightMode = _mContext.Resources.Configuration.UiMode & UiMode.NightMask;
					if (currentNightMode != UiMode.NightYes)
					{
						if (element.IconTint != 0)
						{
							DrawableCompat.SetTint(wrappedDrawable, ContextCompat.GetColor(_mContext, element.IconTint));
						}
						else
						{
							DrawableCompat.SetTint(wrappedDrawable, ContextCompat.GetColor(_mContext, Resource.Color.about_item_icon_color));
						}
					}
					else if (element.IconNightTint != 0)
					{
						DrawableCompat.SetTint(wrappedDrawable, ContextCompat.GetColor(_mContext, element.IconNightTint));
					}
					else
					{
						DrawableCompat.SetTint(wrappedDrawable, AboutPageUtils.GetThemeAccentColor(_mContext));
					}
				}
				
			}
			else
			{
				int iconPadding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_padding);
				textView.SetPadding(iconPadding, iconPadding, iconPadding, iconPadding);
			}

			textView.Text = element.Title;

			if (_mIsRtl)
			{
				var gravity = element.Gravity != GravityFlags.NoGravity ? element.Gravity : GravityFlags.Right;

				wrapper.SetGravity(gravity | GravityFlags.CenterVertical);
				textParams.Gravity = gravity | GravityFlags.CenterVertical;
				wrapper.AddView(textView);
				if (element.IconDrawable != 0)
				{
					wrapper.AddView(iconView);
				}
			}
			else
			{
				var gravity = element.Gravity != GravityFlags.NoGravity ? element.Gravity : GravityFlags.Left;

				wrapper.SetGravity(gravity | GravityFlags.CenterVertical);
				textParams.Gravity = gravity | GravityFlags.CenterVertical;
				if (element.IconDrawable != 0)
				{
					wrapper.AddView(iconView);
				}
				wrapper.AddView(textView);
			}

			return wrapper;
		}


		private View GetSeparator()
		{
			return _mInflater.Inflate(Resource.Layout.about_page_separator, null);
		}
	}
}