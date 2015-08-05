Integrate Kiip

 

SDK minimum requirement:

The IOS binding should have the same requirement as the kiip native
objective c library.

 

Adding Kiip Resources

In the KiipSDKXamarin directory, you'll find the KiipTouchArtResources
folder. Copy the contain of  KiipTouchArtResources to your project
esources folder.

 

Adding Kiip Library Reference

There is two methods to reference the library:

1.  1)Adding the   KiipSDKXamarin/KiipSDKXamarin.Touch solution directly
    to your project and referencing the solution directly. 

2.  2)Precompiling the  KiipSDKXamarin/KiipSDKXamarin.Touch solution and
     referencing the generated dll. 

 

Intialize Kiip

Once you verify you’ve successfully linked the Kiip framework in your
project, navigate to your AppDelegate.cs. You will need the following
import:

using KiipSDKXamarin.Touch;\

Now, you can initialize Kiip in the FinishedLaunching  method, located
in AppDelegate.cs.

 

It should look something like this:

public override bool FinishedLaunching (UIApplication application,
NSDictionary launchOptions)\
{\
        Kiip kiip = new Kiip();\
        kiip.InitWithAppKey("AppKey", "AppSecret");\
        Kiip.SetSharedInstance(kiip);\
        return true;

}

 

See the sample AppDelegate.cs  in
KiipSDKXamarin/TouchSimplesample/AppDelegate .cs\

Call a Kiip Moment

Kiip moments are simply points in your Application where you want to
reward your user. The end user is allowed to earn rewards multiple times
for the same moment. If there is a reward available, the SDK will
display the reward to the user.

 

using KiipSDKXamarin.Touch;

Kiip.SharedInstance().SaveMoment(momentId, (KPPoptart poptart, NSError
error)=\>{\
        if(poptart != null){\
                poptart.Show();\
        }\
} );\

 

Reward Virtual Currency

If your app provides virtual currency, then you can reward your users
with that, as well.

First, you’ll need to enable virtual currency rewards in the dashboard,
and assign values to each dollar amount.

Then, place the following listener in your AppDelegate.cs in order to
listen for currency rewards.

Kiip.SharedInstance().Delegate = new MyKiipDelegate(this);

class MyKiipDelegate : KiipDelegate{\
        private AppDelegate \_parent;\
        public MyKiipDelegate(AppDelegate parent){\_parent = parent;}\
\
        public override void DidReceiveContent (Kiip kiip, string
content, int quantity,                         string transactionId,
string signature)\
        {\
                // Give the currency to the user by using your in-app
currency management.\
        }\
}\

