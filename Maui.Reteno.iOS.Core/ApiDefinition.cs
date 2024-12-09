using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace Maui.Reteno.iOS.Core
{
	// @interface Address : NSObject
    [BaseType(typeof(NSObject))]
    interface Address
    {
        [Export("initWithRegion:town:address:postcode:")]
        IntPtr Constructor([NullAllowed] string region, [NullAllowed] string town, [NullAllowed] string address, [NullAllowed] string postcode);

        [Export("isEqual:")]
        bool IsEqual(NSObject @object);
    }

    // @interface UserCustomField : NSObject
    [BaseType(typeof(NSObject))]
    interface UserCustomField
    {
        [Export("initWithKey:value:")]
        IntPtr Constructor(string key, string value);

        [Export("isEqual:")]
        bool IsEqual(NSObject @object);
    }

    [BaseType(typeof(NSObject))]
    interface MessagesResult
    {
        [Export("messages", ArgumentSemantic.Copy)]
        AppInboxMessage[] Messages { get; }

        [Export("totalCount")]
        nint TotalCount { get; }

        [Export("currentPage")]
        nint CurrentPage { get; }

        [Export("pageSize")]
        nint PageSize { get; }
    }

    // @interface UserAttributes : NSObject
    [BaseType(typeof(NSObject))]
    interface UserAttributes
    {
        [Export("initWithPhone:email:firstName:lastName:languageCode:timeZone:address:fields:")]
        IntPtr Constructor(
            [NullAllowed] string phone,
            [NullAllowed] string email,
            [NullAllowed] string firstName,
            [NullAllowed] string lastName,
            [NullAllowed] string languageCode,
            [NullAllowed] string timeZone,
            [NullAllowed] Address address,
            UserCustomField[] fields);

        [Export("isEqual:")]
        bool IsEqual(NSObject @object);
    }

    // @interface Recommendations : NSObject
    [BaseType(typeof(NSObject))]
    interface Recommendations
    {
        [Export("logEventWithRecomVariantId:impressions:clicks:forcePush:")]
        void LogEvent(string recomVariantId, RecomEvent[] impressions, RecomEvent[] clicks, bool forcePush);

        [Export("getRecomsWithRecomVariantId:productIds:categoryId:filters:fields:success:failure:")]
        void GetRecoms(
            string recomVariantId,
            string[] productIds,
            [NullAllowed] string categoryId,
            [NullAllowed] RecomFilter[] filters,
            [NullAllowed] string[] fields,
            Action<NSDictionary<NSString, NSObject>> success,
            Action<NSError> failure);
    }

    // @interface RecomEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface RecomEvent
    {
        [Export("initWithDate:productId:")]
        IntPtr Constructor(NSDate date, string productId);
    }

    // @interface RecomFilter : NSObject
    [BaseType(typeof(NSObject))]
    interface RecomFilter
    {
        [Export("initWithName:values:")]
        IntPtr Constructor(string name, string[] values);
    }

        // @interface Ecommerce : NSObject
    [BaseType(typeof(NSObject))]
    interface Ecommerce
    {
        [Export("logEventWithType:date:forcePush:")]
        void LogEvent(EventObjcType type, NSDate date, bool forcePush);
    }

    // @interface EventObjcType : NSObject
    [BaseType(typeof(NSObject))]
    interface EventObjcType
    {
        [Static]
        [Export("productViewedWithProduct:currencyCode:")]
        EventObjcType ProductViewed(EcommerceProduct product, [NullAllowed] string currencyCode);

        [Static]
        [Export("productCategoryViewedWithCategory:")]
        EventObjcType ProductCategoryViewed(EcommerceProductCategory category);

        [Static]
        [Export("productAddedToWishlistWithProduct:currencyCode:")]
        EventObjcType ProductAddedToWishlist(EcommerceProduct product, [NullAllowed] string currencyCode);

        [Static]
        [Export("cartUpdatedWithCartId:products:currencyCode:")]
        EventObjcType CartUpdated(string cartId, EcommerceProductInCart[] products, [NullAllowed] string currencyCode);

        [Static]
        [Export("orderCreatedWithOrder:currencyCode:")]
        EventObjcType OrderCreated(EcommerceOrder order, [NullAllowed] string currencyCode);

        [Static]
        [Export("orderUpdatedWithOrder:currencyCode:")]
        EventObjcType OrderUpdated(EcommerceOrder order, [NullAllowed] string currencyCode);

        [Static]
        [Export("orderDeliveredWithExternalOrderId:")]
        EventObjcType OrderDelivered(string externalOrderId);

        [Static]
        [Export("orderCancelledWithExternalOrderId:")]
        EventObjcType OrderCancelled(string externalOrderId);

        [Static]
        [Export("searchRequestWithQuery:isFound:")]
        EventObjcType SearchRequest(string query, [NullAllowed] BoolObjc isFound);
    }

    // @interface EcommerceProduct : NSObject
    [BaseType(typeof(NSObject))]
    interface EcommerceProduct
    {
        [Export("initWithProductId:price:isInStock:attributes:")]
        IntPtr Constructor(
            string productId,
            float price,
            bool isInStock,
            [NullAllowed] NSDictionary<NSString, NSArray<NSString>> attributes);
    }

    // @interface EcommerceProductCategory : NSObject
    [BaseType(typeof(NSObject))]
    interface EcommerceProductCategory
    {
        [Export("initWithProductCategoryId:attributes:")]
        IntPtr Constructor(
            string productCategoryId,
            [NullAllowed] NSDictionary<NSString, NSArray<NSString>> attributes);
    }

    // @interface EcommerceProductInCart : NSObject
    [BaseType(typeof(NSObject))]
    interface EcommerceProductInCart
    {
        [Export("initWithProductId:price:quantity:discount:name:category:attributes:")]
        IntPtr Constructor(
            string productId,
            float price,
            nint quantity,
            [NullAllowed] NSNumber discount,
            [NullAllowed] string name,
            [NullAllowed] string category,
            [NullAllowed] NSDictionary<NSString, NSArray<NSString>> attributes);
    }

    // @interface EcommerceOrder : NSObject
    [BaseType(typeof(NSObject))]
    interface EcommerceOrder
    {
        [Export("initWithExternalOrderId:totalCost:status:date:cartId:email:phone:firstName:lastName:shipping:discount:taxes:restoreUrl:statusDescription:storeId:source:deliveryMethod:paymentMethod:deliveryAddress:items:attributes:")]
        IntPtr Constructor(
            string externalOrderId,
            float totalCost,
            EcommerceOrderStatus status,
            NSDate date,
            [NullAllowed] string cartId,
            [NullAllowed] string email,
            [NullAllowed] string phone,
            [NullAllowed] string firstName,
            [NullAllowed] string lastName,
            [NullAllowed] NSNumber shipping,
            [NullAllowed] NSNumber discount,
            [NullAllowed] NSNumber taxes,
            [NullAllowed] string restoreUrl,
            [NullAllowed] string statusDescription,
            [NullAllowed] string storeId,
            [NullAllowed] string source,
            [NullAllowed] string deliveryMethod,
            [NullAllowed] string paymentMethod,
            [NullAllowed] string deliveryAddress,
            [NullAllowed] EcommerceOrderItem[] items,
            [NullAllowed] NSDictionary<NSString, NSDictionary<NSString, NSObject>> attributes);
    }

    // @interface EcommerceOrderItem : NSObject
    [BaseType(typeof(NSObject))]
    interface EcommerceOrderItem
    {
        [Export("initWithExternalItemId:name:category:quantity:cost:url:imageUrl:description:")]
        IntPtr Constructor(
            string externalItemId,
            string name,
            string category,
            double quantity,
            float cost,
            string url,
            [NullAllowed] string imageUrl,
            [NullAllowed] string description);
    }

    // @interface BoolObjc : NSObject
    [BaseType(typeof(NSObject))]
    interface BoolObjc
    {
        [Export("initWithBool:")]
        IntPtr Constructor(bool value);
    }

    // @interface AnonymousUserAttributes : NSObject
    [BaseType(typeof(NSObject))]
    interface AnonymousUserAttributes
    {
        [Export("initWithFirstName:lastName:languageCode:timeZone:address:fields:")]
        IntPtr Constructor([NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string languageCode, [NullAllowed] string timeZone, [NullAllowed] Address address, UserCustomField[] fields);
    }

    // @interface AppInbox : NSObject
    [BaseType(typeof(NSObject))]
    interface AppInbox
    {
        [NullAllowed, Export("onUnreadMessagesCountChanged", ArgumentSemantic.Copy)]
        Action<nint> OnUnreadMessagesCountChanged { get; set; }

        [Export("downloadMessagesWithPage:pageSize:success:failure:")]
        void DownloadMessagesWithPage(nint page, nint pageSize, Action<MessagesResult> success, Action<NSError> failure);

        [Export("getUnreadMessagesCountWithSuccess:failure:")]
        void GetUnreadMessagesCount(Action<nint> success, Action<NSError> failure);

        [Export("markAsOpenedWithMessageIds:success:failure:")]
        void MarkAsOpened(string[] messageIds, Action success, Action<NSError> failure);

        [Export("markAllAsOpenedWithSuccess:failure:")]
        void MarkAllAsOpened(Action success, Action<NSError> failure);
    }

    // @interface AppInboxMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface AppInboxMessage
    {
        [Export("id", ArgumentSemantic.Copy)]
        string Id { get; }

        [Export("title", ArgumentSemantic.Copy)]
        string Title { get; }

        [NullAllowed, Export("content", ArgumentSemantic.Copy)]
        string Content { get; }

        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageURL { get; }

        [NullAllowed, Export("linkURL", ArgumentSemantic.Copy)]
        NSUrl LinkURL { get; }

        [Export("isNew")]
        bool IsNew { get; }

        [NullAllowed, Export("category", ArgumentSemantic.Copy)]
        string Category { get; }

        [NullAllowed, Export("customData", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> CustomData { get; }

        [NullAllowed, Export("expiryDate", ArgumentSemantic.Copy)]
        NSDate ExpiryDate { get; }
    }

    // ... Add more class bindings following this pattern

    // @interface Reteno : NSObject
    [BaseType(typeof(NSObject))]
    interface Reteno
    {
        [Static]
        [Export("startWithApiKey:configuration:")]
        void Start(string apiKey, RetenoConfiguration configuration);

        [Static]
        [Export("updateUserAttributesWithExternalUserId:userAttributes:subscriptionKeys:groupNamesInclude:groupNamesExclude:")]
        void UpdateUserAttributes([NullAllowed] string externalUserId, [NullAllowed] UserAttributes userAttributes, string[] subscriptionKeys, string[] groupNamesInclude, string[] groupNamesExclude);

        [Static]
        [Export("inbox")]
        AppInbox Inbox { get; }

        [Static]
        [Export("recommendations")]
        Recommendations Recommendations { get; }

        [Static]
        [Export("ecommerce")]
        Ecommerce Ecommerce { get; }
    }

    // @interface RetenoConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface RetenoConfiguration
    {
        [Export("initWithIsAutomaticScreenReportingEnabled:isAutomaticAppLifecycleReportingEnabled:isAutomaticPushSubsriptionReportingEnabled:isAutomaticSessionReportingEnabled:isPausedInAppMessages:inAppMessagesPauseBehaviour:isDebugMode:")]
        IntPtr Constructor(bool isAutomaticScreenReportingEnabled, bool isAutomaticAppLifecycleReportingEnabled, bool isAutomaticPushSubsriptionReportingEnabled, bool isAutomaticSessionReportingEnabled, bool isPausedInAppMessages, PauseBehaviour inAppMessagesPauseBehaviour, bool isDebugMode);
    }
}
