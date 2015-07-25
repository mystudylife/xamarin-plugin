using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using  KiipSDKXamarin.Droid;

namespace simplesample
{
	[Activity (Label = "simplesample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : BaseActivity
	{

		EditText _MomentId;
		EditText _MomentValue;
		Button _ButtonMoment;
		Button _ButtonStart;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			_MomentId = FindViewById<EditText> (Resource.Id.moment_id);
			_MomentValue = FindViewById<EditText> (Resource.Id.moment_value);
			_ButtonMoment = FindViewById<Button> (Resource.Id.btn_moment);
			_ButtonStart = FindViewById<Button> (Resource.Id.btn_start);
			
			_ButtonStart.Click += delegate {
				StartActivity(typeof(SecondaryActivity));
			};

			_ButtonMoment.Click += delegate {
				String momentId = _MomentId.Text;
				double? momentValue = _MomentValue.Text.Length > 0 ? (double?)Double.Parse(_MomentValue.Text) : null;

				if (!momentValue.HasValue) {
					Kiip.Instance.SaveMoment(momentId, this);
				} else {
					Kiip.Instance.SaveMoment(momentId, momentValue.Value, this);
				}
			};
		}
	}
}


