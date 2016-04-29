using System;

using Android.App;
using Android.Runtime;


using  KiipSDKXamarin.Droid;
using Android.Util;

namespace simplesample
{
	[Application]
	public class App : Application , Kiip.IOnContentListener
	{
		private const String TAG = "kiip";
		private const String APP_KEY = "56ad95a4e7bc62dd04bb62babbdf480e";
		private const String APP_SECRET = "db5dd428c4c207fa1a16c7cfc234e3fd";

		public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
			Kiip kiip = Kiip.Init(this, APP_KEY, APP_SECRET);
			kiip.TestMode = (Java.Lang.Boolean)true;
			kiip.SetOnContentListener(this);
			Kiip.Instance = kiip;
		}

		public void OnContent (Kiip kiip, string content, int quantity, string transactionId, string signature)
		{
			Log.Debug (TAG, "onContent content=" + content + " quantity=" + quantity + " transactionId=" + transactionId + " signature=" + signature);
		}
	}
}

