// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TouchSimpleSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DeviceID { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITapGestureRecognizer DismissKeyboardTapGesture { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MomentIdField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MomentValueField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SaveMomentButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DeviceID != null) {
				DeviceID.Dispose ();
				DeviceID = null;
			}
			if (DismissKeyboardTapGesture != null) {
				DismissKeyboardTapGesture.Dispose ();
				DismissKeyboardTapGesture = null;
			}
			if (MomentIdField != null) {
				MomentIdField.Dispose ();
				MomentIdField = null;
			}
			if (MomentValueField != null) {
				MomentValueField.Dispose ();
				MomentValueField = null;
			}
			if (SaveMomentButton != null) {
				SaveMomentButton.Dispose ();
				SaveMomentButton = null;
			}
		}
	}
}
