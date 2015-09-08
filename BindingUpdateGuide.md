Setting up Xamarin developer environment:

Follow this link to find detailed instruction on how to setup
development environment on both mac and window
http://developer.xamarin.com/guides/ios/getting\_started/installation.

 

SDK minimum requirement:

The IOS binding should have the same requirement as the kiip native
objective c library.

On Android the binding requires OS version 4.03 or higher  

 

To update the Android binding simply replace
 KiipSDKXamarin.Droid/Jars/KiipSDK.jar and replace the art resources in
KiipTouchArtResources. Rebuilding the KiipSDKXamarin.Touch solution
should generate the new binding. The new dll can be found under the
 KiipSDKXamarin.Touch/bin/{debug}or{release}.

 

To update the IOS binding first extract  the static library file KiipSDK
found under KiipSDK.framework/Versions/A/KiipSDK  from the
KiipSDK.framework. Rename the file to libKiipSDK.a. Copy the static
library  to KiipSDKXamarin.Touch/Resources and replace the art resources
in KiipTouchArtResources. Rebuilding the KiipSDKXamarin.Droid solution
should generate the new binding. The new dll can be found under the
 KiipSDKXamarin.Droid/bin/{debug}or{release}.
