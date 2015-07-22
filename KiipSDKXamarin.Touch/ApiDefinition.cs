using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace KiipSDKXamarin.Touch
{



	delegate void SaveMomentDelegate (KPPoptart poptart, NSError error);


	//	[Static]
	//	partial interface Kiip {
	//				[Field ("KPErrorDomain") , "__Internal"]
	//				String KPErrorDomain { get; }
	//
	//				[Field ("KPVersion") , "__Internal"]
	//				String KPVersion { get; }
	//
	//				[Field ("kKPCapabilities_Real") , "__Internal"]
	//				String kKPCapabilities_Real { get; }
	//
	//				[Field ("kKPCapabilities_Virtual") , "__Internal"]
	//				String kKPCapabilities_Virtual { get; }
	//
	//				[Field ("kKPCapabilities_Video") , "__Internal"]
	//				String kKPCapabilities_Video { get; }
	//	}

	[BaseType (typeof(NSObject))]
	interface Kiip
	{

		//		[Field ("KPErrorDomain") , "__Internal"]
		//		String KPErrorDomain { get; }
		//
		//		[Field ("KPVersion") , "__Internal"]
		//		String KPVersion { get; }
		//
		//		[Field ("kKPCapabilities_Real") , "__Internal"]
		//		String kKPCapabilities_Real { get; }
		//
		//		[Field ("kKPCapabilities_Virtual") , "__Internal"]
		//		String kKPCapabilities_Virtual { get; }
		//
		//		[Field ("kKPCapabilities_Video") , "__Internal"]
		//		String kKPCapabilities_Video { get; }

		/** @name Accessing Kiip Properties */

		/**
		Setting whether or not Kiip views should sync their rotation with the application on their own/
		*/
		[Export ("shouldAutoRotate")]
		bool ShouldAutoRotate { get; set; }

		/**
		 The global orientation for all Kiip views. Must set shouldAutoRotate to YES for this to work.
		 */
		[Export ("interfaceOrientation")]
		UIInterfaceOrientation InterfaceOrientation { get; set; }

		/**
		 The view that will be displayed in a notification.
		 */

		[Export ("notificationView")]
		KPNotificationView NotificationView { get; set; }

		/**
		 Defines the capabilities that this application is able to support.
		 
		 *THIS SHOULD ONLY BE SET BY WRAPPERS*
		 
		 This must be called AFTER setting the delegate to override the automatically detected capabilities.
		 
		 Use kKPCapabilities_Real, kKPCapabilities_Virtual, kKPCapabilities_Video
		 */
		[Export ("capabilities")]
		NSArray Capabilities { get; set; }

		/**
		 The user's email address. Setting this will auto-populate units with their email address.
		 */
		[Export ("email")]
		String Email { get; set; }

		/**
		 The user's gender. Setting this will help target rewards to your users more effectively.
		 */
		[Export ("gender")]
		String Gender { get; set; }

		/**
		 The user's birthday. Setting this will help target rewards to your users more effectively.
		 */
		[Export ("birthday")]
		NSDate Birthday { get; set; }

		/**
		 The the string Kiip uses to uniquely identify devices.
		 */
		[Export ("deviceIdentifier")]
		String DeviceIdentifier { get; }


		/** @name Setting and Getting the Delegate */

		/**
		The delegate of the Kiip object.

		@discussion The delegate must adopt the KiipDelegate formal protocol.
		*/
		[Export ("delegate", ArgumentSemantic.Assign)]
		KiipDelegate Delegate { get; [Bind ("setDelegate:")] set; }

		/** @name Setting and Getting the Kiip instance */

		/**
		Returns the shared Kiip instance.
		*/
		[Static, Export ("sharedInstance")]
		Kiip SharedInstance ();

		/**
		 Sets the shared Kiip instance
		 
		 @param kiip New shared Kiip instance.
		 */
		[Static, Export ("setSharedInstance:")]
		void SetSharedInstance (Kiip kiip);


		/** @name Creating a new Kiip object */

		/**
		Initializes a Kiip object with the specified values.

		@param appKey The Application's key.
		@param appSecret The Application's secret.
		*/
		[Export ("initWithAppKey:andSecret:")]
		NSObject InitWithAppKey (String appKey, String appSecret);



		/** @name Saving Moments */

		/**
		Saves a moment.

		@param momentId The unique identifier of the moment to be recorded.
		@param handler A block to be called when the HTTP request asynchronously completes, with a Poptart
		and an Error. The Poptart may return nil if no reward has been issued. The Error will be 
		nil if the request completed successfully.
			*/



			[Export ("saveMoment:withCompletionHandler:")]
		void SaveMoment (String momentId, SaveMomentDelegate handler);

		/**
		 Saves a moment.

		 @param momentId The unique identifier of the moment to be recorded.
		 @param value The value of the moment.
		 @param handler A block to be called when the HTTP request asynchronously completes, with a Poptart
		 and an Error. The Poptart may return nil if no reward has been issued. The Error will be
		 nil if the request completed successfully.
		 */

		[Export ("saveMoment:value:withCompletionHandler:")]
		void SaveMoment (String momentId, double value, SaveMomentDelegate handler);
	}


	[BaseType (typeof(NSObject))]
	[Model][Protocol]
	interface KiipDelegate
	{

		/**
		Tells the delegate that Kiip attempted to start a new session.

		@param kiip The Kiip instance that started the session.
		@param poptart A unit to be displayed. May be nil.
		@param error If not nil, an error occured.
		*/

		[Export ("kiip:didStartSessionWithPoptart:error:")]
		void DidStartSessionWithPoptart (Kiip kiip, KPPoptart poptart, NSError error);

		/**
		 Tells the delegate that Kiip attempted to end it's session.

		 @param kiip The Kiip instance that ended the session.
		 @param error If not nil, an error occured.
		 */
		[Export ("kiip:didEndSessionWithError:")]
		void DidEndSessionWithError (Kiip kiip, NSError error);
	
		/**
		Tells the delegate that the user has recieved in-game content.

		@param kiip The Kiip instance that indicated the user should receive in-game content.
		@param content The identifier of the content that should be awarded to the user.
		@param quantity The amount of content that should be awarded to the user.
		@param transactionId The unique identifer of this transaction.
		@param signature The signature that can be checked to validate this transaction.
		*/
		[Export ("kiip:didReceiveContent:quantity:transactionId:signature:")]
		void DidReceiveContent (Kiip kiip, String content, int quantity, String transactionId, String signature);

		/** @name Video Playback Callbacks */

		/**
		Tells the delegate that a video session has begun.

		@param kiip The Kiip instance that has begun playing video.
		*/

		[Export ("kiipVideoPlaybackDidBegin:")]
		void KiipVideoPlaybackDidBegin (Kiip kiip);

		/**
		 Tells the delegate that a video session has ended.
		 
		 @param kiip The Kiip instance that has finished playing video.
		 */
		[Export ("kiipVideoPlaybackDidEnd:")]
		void KiipVideoPlaybackDidEnd (Kiip kiip);

	}


/**
 Use the KPModal class to display a full screen Kiip unit such as a reward.
 */

	[BaseType (typeof(NSObject))]
	interface KPModal
	{
		/** @name Access Modal Properties */

		/**
		The title of the loading dialog.
		*/
		[Export ("title")]
		String Title { get; set; }


/**
 The message of the loading dialog.
 */
		[Export ("message")]
		String Message { get; set; }



		/** @name Setting and Getting the Delegate */

		/**
		The delegate of the Modal object.
		*/
		[Export ("delegate", ArgumentSemantic.Assign)]
		KPModalDelegate Delegate { get; set; }


	}


/**
 The KPModalDelegate protocol defines the methods that a delegate of KPModal should implement. This
 delegate implements callbacks to actions such as when a modal is shown or is dismissed.
 */

	[BaseType (typeof(NSObject))]
	[Model][Protocol]
	interface KPModalDelegate
	{

		/**
		Tells the delegate that a Modal will be presented.

		@param modal The Modal that will be presented.
		*/
		[Export ("willPresentModal:")]
		void WillPresentModal (KPModal modal);

		/**
 		Tells the delegate that a Modal was dismissed.
 
 		@param modal The Modal that was dismissed.
 		*/
		[Export ("didDismissModal:")]
		void DidDismissModal (KPModal modal);

	}

/**
 Use the KPNotification class to display an unobtrusive view to notify your users they have 
 received something such as a reward.
 */
	[BaseType (typeof(NSObject))]
	interface KPNotification
	{


		/** @name Accessing Notification Properties */

		/**
		The title of the notification.
		*/
		[Export ("title")]
		String Title { get; set; }

		/**
 The message of the notification.
 */
		[Export ("message")]
		String Message { get; set; }


		/**
 The gravity of the notification.
 
 @discussion Dictacts the position that the notification gets displayed on the screen.
 */
		[Export ("gravity")]
		KPGravity gravity { get; set; }

		/**
 The icon of the notification.
 */
		//TODO use file references instead of keeping image in memory
		[Export ("icon")]
		UIImage Icon { get; set; }


		/** @name Setting and Getting the Delegate */

		/**
		The delegate of the Notification object.
		*/
		[Export ("delegate", ArgumentSemantic.Assign)]
		KPNotificationDelegate Delegate { get; set; }
	}


/**
 The KPNotificationDelegate protocol defines the methods that a delegate of KPNotification should implement. This
 delegate implements callbacks to actions such as when a notification is shown or is dismissed.
 */
	[BaseType (typeof(NSObject))]
	[Model][Protocol]
	interface KPNotificationDelegate
	{

		/** @name Managing Notifications */


		/**
		Tells the delegate that a Notification will be presented.

		@param notification The Notification that will be presented.
		*/
		[Export ("willPresentNotification:")]
		void WillPresentNotification (KPNotification notification);


		/**
 		Tells the delegate that a Notification was dismissed.
 
 		@param notification The Notification that was dismissed.
 		*/

		[Export ("didDismissNotification:")]
		void DidDismissNotification (KPNotification notification);

		/**
 		Tells the delegate that a Notification was dismissed by clicking it.
 
		 @param notification The Notification that was dismissed.
 		*/
		[Export ("didDismissNotificationWithClick:")]
		void DidDismissNotificationWithClick (KPNotification notification);

	}


	[BaseType (typeof(UIButton))]
	interface KPNotificationView
	{
		/**
		The poptart that will be displayed.

		@discussion The setter for this property should be overritten to read the Notification's properties
			to change the rendering of this view to match the current Poptart.
		*/
		[Export ("poptart")]
		KPPoptart Poptart { get; set; }

	}



/**
 Use the KPPoptart to display Kiip units such as rewards to your users.
 */
	[BaseType (typeof(NSObject))]
	interface KPPoptart
	{
		/**
		The unique identifier of the poptart.
		*/
		[Export ("viewId")]
		String ViewId { get; set; }

		/**
 		The notification of the poptart.
 		*/
		[Export ("notification")]
		KPNotification Notification { get; set; }

		/**
 		The modal of the poptart.
 		*/
		[Export ("modal")]
		KPModal Modal { get; set; }


		/** @name Setting and Getting the Delegate */

		/**
		The delegate of the Poptart object.
		*/
		[Export ("delegate", ArgumentSemantic.Assign)]
		KPPoptartDelegate Delegate { get; set; }



		/** @name Showing the Poptart */

		/**
		Show the Poptart.
		*/
		[Export ("show")]
		void Show ();

	}



	[BaseType (typeof(NSObject))]
	[Model][Protocol]
	interface KPPoptartDelegate
	{

		/**
		Tells the delegate a Poptart will be presented.

		@param poptart The poptart that will be presented.
		*/
		[Export ("willPresentPoptart:")]
		void WillPresentPoptart (KPPoptart poptart);

		/**
		 Tells the delegate a Poptart was dismissed.
		 
		 @param poptart The poptart that was dismissed.
		 */
		[Export ("didDismissPoptart:")]
		void DidDismissPoptart (KPPoptart poptart);
	}

}