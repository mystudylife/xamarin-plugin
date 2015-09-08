using System;
using ObjCRuntime;

[assembly: LinkWith ("libKiipSDK.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, Frameworks = "CoreTelephony QuartzCore SystemConfiguration AdSupport Passkit MediaPlayer")]
