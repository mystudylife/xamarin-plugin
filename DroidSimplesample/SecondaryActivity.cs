using System;
using Android.App;

namespace simplesample
{
	[Activity (Label = "SecondaryActivity", Icon = "@drawable/icon", ParentActivity = typeof(MainActivity))]
	public class SecondaryActivity : MainActivity
	{
		public SecondaryActivity ()
		{
		}
	}
}

