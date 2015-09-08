using System;

using UIKit;

using KiipSDKXamarin.Touch;
using Foundation;

namespace TouchSimpleSample
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.


			String deviceIdentifier = Kiip.SharedInstance ().DeviceIdentifier;
			DeviceID.Text = deviceIdentifier;

			DismissKeyboardTapGesture.AddTarget (DismissKeyboard);

			SaveMomentButton.TouchUpInside += (object sender, EventArgs e) => {
				DismissKeyboard();
				String momentId = MomentIdField.Text;
				double? momentValue = MomentValueField.Text.Length > 0 ? (double?)Double.Parse(MomentValueField.Text) : null;

				if (!momentValue.HasValue) {
					Kiip.SharedInstance().SaveMoment(momentId, (KPPoptart poptart, NSError error)=>{
						if(poptart != null){
							poptart.Show();
						}
					});
				} else {
					Kiip.SharedInstance().SaveMoment(momentId, momentValue.Value, (KPPoptart poptart, NSError error)=>{
						if(poptart != null){
							poptart.Show();
						}
					});
				}
			};

			var myUITextFieldDelegate = new MyUITextFieldDelegate (this);
			MomentIdField.Delegate = myUITextFieldDelegate;
			MomentValueField.Delegate = myUITextFieldDelegate;
		}

	
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void DismissKeyboard(){
			MomentIdField.ResignFirstResponder ();
			MomentValueField.ResignFirstResponder ();
		}


		class MyUITextFieldDelegate : UITextFieldDelegate
		{
			ViewController _parent;
			public MyUITextFieldDelegate(ViewController parent)
			{
				_parent = parent;
			}
			public override bool ShouldReturn (UITextField textField)
			{

				if (_parent.MomentIdField == textField) {
					_parent.MomentValueField.BecomeFirstResponder ();
				}
				else if (_parent.MomentValueField == textField) {
					textField.ResignFirstResponder ();
				}

				return false;
			}
		}

	}


}

