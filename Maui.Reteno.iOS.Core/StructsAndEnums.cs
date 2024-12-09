using ObjCRuntime;

namespace Maui.Reteno.iOS.Core
{
	[Native]
	public enum EcommerceOrderStatus : long
	{
		Initialized = 0,
		InProgress = 1,
		Delivered = 2,
		Cancelled = 3
	}

	[Native]
	public enum InAppMessageStatusEnum : long
	{
		ShouldBeDisplayed = 0,
		IsDisplayed = 1,
		ShouldBeClosed = 2,
		IsClosed = 3,
		ReceivedError = 4
	}

	[Native]
	public enum InteractionStatus : long
	{
		Delivered = 0,
		Opened = 1,
		Clicked = 2,
		Unknown = 3
	}

	[Native]
	public enum LinkSource : long
	{
		PushNotification = 0,
		InAppMessage = 1
	}

	[Native]
	public enum PauseBehaviour : long
	{
		SkipInApps = 0,
		PostponeInApps = 1
	}
}
