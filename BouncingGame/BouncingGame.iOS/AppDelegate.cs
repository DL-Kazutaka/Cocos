using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CocosSharp;

namespace BouncingGame.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override void FinishedLaunching(UIApplication application)
        {
            var app = new CCApplication();
            app.ApplicationDelegate = new BouncingGame.GameAppDelegate();
            app.StartGame();
        }
    }
}
