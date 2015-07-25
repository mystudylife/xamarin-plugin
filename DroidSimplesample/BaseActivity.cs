using System;
using Android.App;

using  KiipSDKXamarin.Droid;
using Android.OS;


namespace simplesample
{
	
	public class BaseActivity : Activity, Kiip.ICallback
	{
		private static String KIIP_TAG = "kiip_fragment_tag";
		private KiipFragment mKiipFragment;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);


			if (bundle != null) {
			mKiipFragment = (KiipFragment) FragmentManager.FindFragmentByTag(KIIP_TAG);
			} else {
			mKiipFragment = new KiipFragment();
			FragmentManager.BeginTransaction ().Add (mKiipFragment, KIIP_TAG).Commit();
			}

		}

		protected override void OnStart ()
		{
			base.OnStart ();
			Kiip.Instance.StartSession(this);

		}

		protected override void OnStop ()
		{
			base.OnStop ();


			Kiip.Instance.EndSession(this);

		}



		public virtual void OnFailed (Kiip kiip, Java.Lang.Exception exception)
		{

		}

		public virtual void OnFinished (Kiip kiip, Poptart poptart)
		{
			mKiipFragment.ShowPoptart(poptart);
		}
	}
}

