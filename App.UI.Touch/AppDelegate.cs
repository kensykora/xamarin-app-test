﻿using Foundation;

using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;

using UIKit;

namespace App.UI.Touch
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, new MvxIosViewPresenter(this, Window));
            setup.Initialize();

            Mvx.Resolve<IMvxAppStart>().Start();

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}


