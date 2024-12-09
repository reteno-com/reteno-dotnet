#!/bin/sh
# RetenoSDK.xcodeproj xcframework target runs this script

# config
IOS_PATH="./build/ios/ios.xcarchive"
IOS_SIM_PATH="./build/ios/ios_sim.xcarchive"
XCFRAMEWORK_PATH="./build/RetenoSDK.xcframework"

# delete previous build
rm -rf "./build" 

# build iOS framework
xcodebuild archive \
    -project RetenoSDK.xcodeproj\
    -scheme Reteno \
    -configuration Release \
    -destination "generic/platform=iOS" \
    -archivePath "${IOS_PATH}" \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
    SKIP_INSTALL=NO 

# build iOS simulator framework
xcodebuild archive \
    -project RetenoSDK.xcodeproj \
    -scheme Reteno \
    -configuration Release \
    -destination "generic/platform=iOS Simulator" \
    -archivePath "${IOS_SIM_PATH}" \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
    SKIP_INSTALL=NO

# package frameworks
xcodebuild -create-xcframework \
    -framework "${IOS_PATH}/Products/Library/Frameworks/RetenoSDK.framework" \
    -framework "${IOS_SIM_PATH}/Products/Library/Frameworks/RetenoSDK.framework" \
    -output "${XCFRAMEWORK_PATH}"
