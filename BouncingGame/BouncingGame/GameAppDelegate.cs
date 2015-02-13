using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CocosSharp;

namespace BouncingGame
{
    public class GameAppDelegate : CCApplicationDelegate
    {
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            base.ApplicationDidFinishLaunching(application, mainWindow);

            application.PreferMultiSampling = false;
            application.ContentRootDirectory = "Content";

            // メインウィンドウの解像度を取得
            var bounds = mainWindow.WindowSizeInPixels;

            // デフォルトの描画シーンを設定する
            CCScene.SetDefaultDesignResolution(bounds.Width, bounds.Height, CCSceneResolutionPolicy.ShowAll);

            // ゲームシーンを作成する
            GameScene gameScene = new GameScene(mainWindow);

            // ウィンドウを表示する
            mainWindow.RunWithScene(gameScene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            base.ApplicationDidEnterBackground(application);
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            base.ApplicationWillEnterForeground(application);
        }
    }
}
