using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using CocosSharp;
using Microsoft.Xna.Framework;

namespace BouncingGame.Android
{
    [Activity(
        Label = "BouncingGame.Android", MainLauncher = true, Icon = "@drawable/icon",
        AlwaysRetainTaskState = true, LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : AndroidGameActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var application = new CCApplication();

            application.ApplicationDelegate = new GameAppDelegate();

            // Set our view from the "main" layout resource
            SetContentView(application.AndroidContentView);

            application.StartGame();
        }
    }
}

