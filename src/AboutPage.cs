using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Support.Graphics.Drawable;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Util;
using Orientation = Android.Widget.Orientation;
using Uri = Android.Net.Uri;

namespace AndroidAboutPage
{
	/**
	 * Created original by medyo on 3/25/16.
	 * Ported to Xamarin by Yauheni Pakala on 5/1/16.
	 */
	public class AboutPage
	{
		private readonly Context _mContext;
		private readonly LayoutInflater _mInflater;
		private string _mDescription;
		private int _mImage;
		private bool _mIsRTL;
		private Typeface _mCustomFont;
		private readonly View _mView;

		public AboutPage(Context context)
		{
			_mContext = context;
			_mInflater = LayoutInflater.From(context);
			_mView = _mInflater.Inflate(Resource.Layout.about_page, null);
		}

		public AboutPage SetCustomFont(string fontName)
		{
			_mCustomFont = Typeface.CreateFromAsset(_mContext.Assets, fontName);
			return this;
		}

		/// <summary>
		/// Add Email Element
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public AboutPage AddEmail(string email)
		{
			var intent = new Intent(Intent.ActionSend);
			intent.SetType("message/rfc822");
			intent.PutExtra(Intent.ExtraEmail, new[] { email });

			var emailElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_contact_us),
				Icon = Resource.Drawable.about_icon_email,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.about_item_icon_color),
				Intent = intent
			};

			AddItem(emailElement);
			return this;
		}

		/// <summary>
		/// Add Facebook Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddFacebook(string id)
		{
			Intent intent = new Intent();
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
					Uri uri = Uri.Parse("fb://facewebmodal/f?href=" + "http://facebook.com/" + id);
					intent.SetData(uri);
				}
				else
				{
					Uri uri = Uri.Parse("fb://page/" + id);
					intent.SetData(uri);
				}
			}
			else
			{
				intent.SetData(Uri.Parse("http://facebook.com/" + id));
			}

			Element facebookElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_facebook),
				Icon = Resource.Drawable.about_icon_facebook,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.facebook_color),
				Intent = intent,
				Value = id
			};

			AddItem(facebookElement);
			return this;
		}

		/// <summary>
		/// Add Twitter Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddTwitter(string id)
		{
			Intent intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.AddCategory(Intent.CategoryBrowsable);

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.twitter.android"))
			{
				intent.SetPackage("com.twitter.android");
				intent.SetData(Uri.Parse($"twitter://user?user_id={id}"));
			}
			else
			{
				intent.SetData(Uri.Parse($"http://twitter.com/{id}"));
			}

			Element twitterElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_twitter),
				Icon = Resource.Drawable.about_icon_twitter,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.twitter_color),
				Intent = intent,
				Value = id
			};
			
			AddItem(twitterElement);
			return this;
		}

		/// <summary>
		/// Add Play store Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddPlayStore(string id)
		{
			Uri uri = Uri.Parse("market://details?id=" + id);
			Intent goToMarket = new Intent(Intent.ActionView, uri);

			Element playStoreElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_play_store),
				Icon = Resource.Drawable.about_icon_google_play,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.play_store_color),
				Intent = goToMarket,
				Value = id
			};

			AddItem(playStoreElement);
			return this;
		}

		/// <summary>
		/// Add Youtube Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddYoutube(string id)
		{
			Intent intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.SetData(Uri.Parse($"http://youtube.com/channel/{id}"));

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.google.android.youtube"))
			{
				intent.SetPackage("com.google.android.youtube");
			}

			Element youtubeElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_youtube),
				Icon = Resource.Drawable.about_icon_youtube,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.youtube_color),
				Intent = intent,
				Value = id
			};

			AddItem(youtubeElement);
			return this;
		}

		/// <summary>
		/// Add Instagram Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddInstagram(string id)
		{
			Intent intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.SetData(Uri.Parse("http://instagram.com/_u/" + id));

			if (AboutPageUtils.IsAppInstalled(_mContext, "com.instagram.android"))
			{
				intent.SetPackage("com.instagram.android");
			}

			Element instagramElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_instagram),
				Icon = Resource.Drawable.about_icon_instagram,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.instagram_color),
				Intent = intent,
				Value = id
			};

			AddItem(instagramElement);
			return this;
		}

		/// <summary>
		/// Add GitHub Element
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AboutPage AddGitHub(string id)
		{
			Intent intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.AddCategory(Intent.CategoryBrowsable);
			intent.SetData(Uri.Parse($"https://github.com/{id}"));

			Element gitHubElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_github),
				Icon = Resource.Drawable.about_icon_github,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.github_color),
				Intent = intent,
				Value = id
			};

			AddItem(gitHubElement);
			return this;
		}

		/// <summary>
		/// Add Website Element
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public AboutPage AddWebsite(string url)
		{
			if (!url.StartsWith("http://") && !url.StartsWith("https://"))
			{
				url = "http://" + url;
			}

			Uri uri = Uri.Parse(url);
			Intent browserIntent = new Intent(Intent.ActionView, uri);

			Element websiteElement = new Element
			{
				Title = _mContext.GetString(Resource.String.about_website),
				Icon = Resource.Drawable.about_icon_link,
				Color = ContextCompat.GetColor(_mContext, Resource.Color.about_item_icon_color),
				Intent = browserIntent,
				Value = url
			};

			AddItem(websiteElement);
			return this;
		}

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

		public AboutPage SetImage(int resource)
		{
			_mImage = resource;
			return this;
		}

		public AboutPage AddGroup(string name)
		{

			TextView textView = new TextView(_mContext);
			textView.Text = name;
			if (Build.VERSION.SdkInt < BuildVersionCodes.M)
			{
				textView.SetTextAppearance(_mContext, Resource.Style.About_GroupTextAppearance);
			}
			else
			{
				textView.SetTextAppearance(Resource.Style.About_GroupTextAppearance);
			}

			LinearLayout.LayoutParams textParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

			if (_mCustomFont != null)
			{
				textView.Typeface = _mCustomFont;
			}

			int padding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_group_text_padding);
			textView.SetPadding(padding, padding, padding, padding);

			if (_mIsRTL)
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

		public AboutPage IsRTL(bool value)
		{
			_mIsRTL = value;
			return this;
		}

		public AboutPage SetDescription(string description)
		{
			_mDescription = description;
			return this;
		}

		public View Create()
		{
			TextView description = (TextView)_mView.FindViewById(Resource.Id.description);
			ImageView image = (ImageView)_mView.FindViewById(Resource.Id.image);
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


		private View CreateItem(Element element)
		{
			LinearLayout wrapper = new LinearLayout(_mContext);
			wrapper.Orientation = Orientation.Horizontal;
			wrapper.Clickable = true;

			if (element.Intent != null)
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

			TypedValue outValue = new TypedValue();
			_mContext.Theme.ResolveAttribute(Android.Resource.Attribute.SelectableItemBackground, outValue, true);
			wrapper.SetBackgroundResource(outValue.ResourceId);

			int padding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_text_padding);
			wrapper.SetPadding(padding, padding, padding, padding);
			LinearLayout.LayoutParams wrapperParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			wrapper.LayoutParameters = wrapperParams;

			TextView textView = new TextView(_mContext);
			if (Build.VERSION.SdkInt < BuildVersionCodes.M)
			{
				textView.SetTextAppearance(_mContext, Resource.Style.About_elementTextAppearance);
			}
			else
			{
				textView.SetTextAppearance(Resource.Style.About_elementTextAppearance);
			}

			LinearLayout.LayoutParams textParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			textView.LayoutParameters = textParams;
			if (_mCustomFont != null)
			{
				textView.Typeface = _mCustomFont;
			}

			ImageView iconView = null;

			if (element.Icon != 0)
			{
				iconView = new ImageView(_mContext);
				int size = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_size);
				LinearLayout.LayoutParams iconParams = new LinearLayout.LayoutParams(size, size);
				iconView.LayoutParameters = iconParams;

				int iconPadding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_padding);
				iconView.SetPadding(iconPadding,0,iconPadding,0);

				if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
				{
					var drawable = VectorDrawableCompat.Create(iconView.Resources, element.Icon, iconView.Context.Theme);
					iconView.SetImageDrawable(drawable);
				}
				else
				{
					iconView.SetImageResource(element.Icon);
				}

				Drawable wrappedDrawable = DrawableCompat.Wrap(iconView.Drawable);
				wrappedDrawable = wrappedDrawable.Mutate();

				if (element.Color != 0)
				{
					DrawableCompat.SetTint(wrappedDrawable, element.Color);
				}
				else
				{
					DrawableCompat.SetTint(wrappedDrawable, ContextCompat.GetColor(_mContext, Resource.Color.about_item_icon_color));
				}
			}
			else
			{
				int iconPadding = _mContext.Resources.GetDimensionPixelSize(Resource.Dimension.about_icon_padding);
				textView.SetPadding(iconPadding, iconPadding, iconPadding, iconPadding);
			}


			textView.Text = element.Title;


			if (_mIsRTL)
			{
				wrapper.SetGravity(GravityFlags.Right | GravityFlags.CenterVertical);
				textParams.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;
				wrapper.AddView(textView);
				if (element.Icon != 0)
				{
					wrapper.AddView(iconView);
				}

			}
			else
			{
				wrapper.SetGravity(GravityFlags.Left | GravityFlags.CenterVertical);
				textParams.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
				if (element.Icon != 0)
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