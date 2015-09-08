using Foundation;
using UIKit;

using KiipSDKXamarin.Touch;

namespace TouchSimpleSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		private const String APP_KEY = "d9726ffccffe91979aad9d995608f49e";
		private const String APP_SECRET = "70452598d56968f5a302e556ea0d35dc";

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif


			Kiip kiip = new Kiip();
			kiip.InitWithAppKey(APP_KEY, APP_SECRET);
			kiip.Delegate = new TestKiipDelegate(this);
			Kiip.SetSharedInstance(kiip);

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}


		class TestKiipDelegate : KiipDelegate
		{
			private AppDelegate _parent;
			public TestKiipDelegate(AppDelegate parent){
				_parent = parent;
			}

			public override void DidReceiveContent (Kiip kiip, string content, int quantity, string transactionId, string signature)
			{

			}
		}
	}


}


